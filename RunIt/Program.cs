using System;
using System.Threading;
using System.Windows.Forms;

namespace RunIt
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        private static string appGuid = "40a66c33-14ab-42c5-a53a-8633f2a667b2";

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (!mutex.WaitOne(0, false))
                {
                    NativeMethods.SendMessage((IntPtr)NativeMethods.HWND_BROADCAST, NativeMethods.WM_AK_START_SHOWME, IntPtr.Zero, IntPtr.Zero);
                    return;
                }

                Application.Run(new Form1(args));
            }

        }

        
        /*
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
        */
        
    }
}
