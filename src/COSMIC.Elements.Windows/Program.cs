using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace COSMIC.Elements.Windows
{
    public static class Program
    {
        
        [STAThread]
        static void Main(string[] args)
        {
            AllocConsole();

            System.Windows.Forms.Application.SetHighDpiMode(HighDpiMode.SystemAware);
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new MainForm(args[0]));
            
            Console.ReadKey();
        }
        

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();
    }
}