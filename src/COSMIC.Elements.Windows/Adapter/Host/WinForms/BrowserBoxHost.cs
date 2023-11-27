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

        public Box Box { get; set; }
        public Guid InstanceId { get; set; }
        public WebView2 Browser;

        public BrowserBoxHost()
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            DoubleBuffered = true;
            Move += OnMove;
            Resize += OnResize;
        }

        public void InitializeComponent()
        {
            this.Width = 500;
            Height = 400;
  
            Browser = new WebView2();
            this.DoubleBuffered = true;
          

            
            Browser.Top = 0;
            
            
            Controls.Add(Browser);
        }

        
        public void ResizeBrowser()
        {
            Box.State.Host.Height = Height;
            Box.State.Host.Width = Width;
            Browser.Height = Height;
            Browser.Width = Width;
        }

        private void OnResize(object? sender, EventArgs e)
        {
           ResizeBrowser();
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



        public void SetHostBox(Box box)
        {
            Box = box;
            Browser.Source = new Uri(box.StartUrl);
            Browser.Width = ClientSize.Width - 4;
            Browser.Height = ClientSize.Height - 26;
            ResizeBrowser();
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