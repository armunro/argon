using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace COSMIC.Elements.Windows.Adapter.Host.WinForms
{
    public sealed partial class LaunchDialog : Form
    {
        private WebView2 _browser;

        public LaunchDialog()
        {
            Width = 400;
            Height = 960;
                
            _browser = new WebView2();
            _browser.Source = new Uri("http://localhost:4301/launchdialog");
            _browser.Dock = DockStyle.Fill;
            _browser.Width = Width;
            _browser.Height = Height;
            
            

            _browser.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

            InitializeComponent();

            Rectangle workingArea = Screen.GetWorkingArea(this);
            Location = new Point(workingArea.Right - Width,
                workingArea.Bottom - Height);


            WindowState = FormWindowState.Normal;


            TopMost = true;        
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
            Controls.Add(_browser);
        }

      
    }
}