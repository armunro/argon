using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using COSMIC.Elements.Windows.Forms;

namespace COSMIC.Elements.Windows
{
    public static class Program
    {
        
        [STAThread]
        static void Main(string[] args)
        {
            AllocConsole();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(args[0]));
            Console.ReadKey();
        }
        

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
    }
}