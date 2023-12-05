using System;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Forms;
using COSMIC.Elements.Web.Domain.Screen;
using COSMIC.Elements.Web.Domain.Screen.Host;
using COSMIC.Elements.Web.Domain.Screen.Host.State;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using Label = System.Windows.Forms.Label;

namespace COSMIC.Elements.Windows.Adapter.Host.WinForms
{
    public sealed class BrowserScreenHost : Form, IScreenHost
    {

        public ScreenModel ScreenModel { get; set; }
        public Guid InstanceId { get; set; }
        public WebView2 Browser;

        public BrowserScreenHost()
        {
            InitializeComponent();

           
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
            ScreenModel.State.Host.Height = Height;
            ScreenModel.State.Host.Width = Width;
            Browser.Height = Height;
            Browser.Width = Width;
        }

        private void OnResize(object? sender, EventArgs e)
        {
           ResizeBrowser();
        }

        private void OnMove(object? sender, EventArgs e)
        {
            ScreenModel.State.Host.X = Left;
            ScreenModel.State.Host.Y = Top;
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



        public void SetHostBox(ScreenModel screenModel)
        {
            ScreenModel = screenModel;
            Browser.Source = new Uri(screenModel.StartUrl);
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