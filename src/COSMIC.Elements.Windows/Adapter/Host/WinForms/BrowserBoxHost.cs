using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Forms;
using COSMIC.Elements.Web.Domain.Box;
using COSMIC.Elements.Web.Domain.Box.Host;
using COSMIC.Elements.Web.Domain.Box.Host.State;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Label = System.Windows.Forms.Label;

namespace COSMIC.Elements.Windows.Adapter.Host.WinForms
{
    public sealed class BrowserBoxHost : Form, IBoxHost
    {
        private bool _mouseDown;
        private Point _lastLocation;

        public Box Box { get; set; }
        public Guid InstanceId { get; set; }
        public WebView2 Browser;
        public WebView2 TitleBrowser;
        public TransparentLabel lblTitle;

        public BrowserBoxHost()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
            Move += OnMove;
            Resize += OnResize;
        }

        public void InitializeComponent()
        {
            this.Width = 500;
            Height = 400;
            Browser = new WebView2();

            TitleBrowser = new WebView2();
            TitleBrowser.Width = Width;
            TitleBrowser.Height = 25;
            TitleBrowser.Dock = DockStyle.Top;

            Browser.Height = Height - 25;
            Browser.Width = Width;
            Browser.Top = 26;


            lblTitle = new TransparentLabel();
            lblTitle.MouseDown += lblTitle_MouseDown;
            lblTitle.MouseUp += lblTitle_MouseUp;
            lblTitle.MouseMove += lblTitle_MouseMove;
            lblTitle.DoubleClick += lblTitle_DoubleClick;
            lblTitle.Top = 0;
            lblTitle.Left = 0;

            this.lblTitle.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular,
                System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(100, 0);

            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(Width -200, 25);
            this.lblTitle.TabIndex = 9;


            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.DoubleClick += new System.EventHandler(this.lblTitle_DoubleClick);
            this.lblTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseDown);
            this.lblTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseMove);
            this.lblTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblTitle_MouseUp);


            Controls.Add(TitleBrowser);
            Controls.Add(Browser);
            Controls.Add(lblTitle);

            Controls.SetChildIndex(lblTitle, 999);
            lblTitle.BringToFront();
        }

        private void TitleBrowserOnNavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            lblTitle.Text = ((WebView2)TitleBrowser).Source.ToString();
            lblTitle.Refresh();
        }

        private void OnResize(object? sender, EventArgs e)
        {
            Box.State.Host.Height = Height;
            Box.State.Host.Width = Width;
            Browser.Height = Height - 25 - 2;
            Browser.Width = Width - 2;
            Browser.Top = 25;
        }

        private void OnMove(object? sender, EventArgs e)
        {
            Box.State.Host.X = Left;
            Box.State.Host.Y = Top;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }

        private void lblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDown = true;
            _lastLocation = e.Location;
        }

        private void lblTitle_MouseUp(object sender, MouseEventArgs e) => _mouseDown = false;

        private void lblTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown)
            {
                Location = new Point(
                    (Location.X - _lastLocation.X) + e.X, (Location.Y - _lastLocation.Y) + e.Y);

                Update();
            }
        }

        private void lblTitle_DoubleClick(object sender, EventArgs e)
        {
            if (base.WindowState == FormWindowState.Normal)
                base.WindowState = FormWindowState.Maximized;
            else
                base.WindowState = FormWindowState.Normal;
        }

        public void SetHostBox(Box box)
        {
            Box = box;

            Browser.Source = new Uri(box.StartUrl);
            TitleBrowser.Source = new Uri("http://localhost:4301/Titlebar/" + InstanceId.ToString());
            Browser.Width = ClientSize.Width - 4;
            Browser.Height = ClientSize.Height - 26;
        }

        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084 /*NCHITTEST*/:
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01 /*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13 /*HTTOPLEFT*/;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12 /*HTTOP*/;
                            else
                                m.Result = (IntPtr)14 /*HTTOPRIGHT*/;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10 /*HTLEFT*/;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2 /*HTCAPTION*/;
                            else
                                m.Result = (IntPtr)11 /*HTRIGHT*/;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16 /*HTBOTTOMLEFT*/;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15 /*HTBOTTOM*/;
                            else
                                m.Result = (IntPtr)17 /*HTBOTTOMRIGHT*/;
                        }
                    }

                    return;
            }

            base.WndProc(ref m);
        }


        public void OpenWindow() => Show();

        public void CloseBox() => Hide();

        public void ChangeWindowState(BoxHostFormState formState)
        {
            Console.WriteLine("Form state is " + formState.ToString());
            switch (formState)
            {
                case BoxHostFormState.Maximized:
                    this.WindowState = FormWindowState.Maximized;
                    break;
                case BoxHostFormState.Minimized:
                    this.WindowState = FormWindowState.Minimized;
                    break;
                case BoxHostFormState.Normal:
                    this.WindowState = FormWindowState.Normal;
                    break;
            }
        }
    }
}