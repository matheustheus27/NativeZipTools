using System;
using System.Windows.Forms;

namespace NativeZipTools
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            if (args.Length > 0)
            {
                CommandLineProcessor.Process(args);
                return;
            }

            Application.Run(new MainForm());
        }
    }
}