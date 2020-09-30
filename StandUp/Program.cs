using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;
using StandUp.UI;
using Microsoft.Win32;

namespace StandUp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (Process.GetProcessesByName("StandUp").Length > 1)
            {
                MessageBox.Show("Another instance is running");
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            EnsureStartUp();

            using (new MainUI())
            {
                Application.Run();
            }
        }

        private static void EnsureStartUp()
        {
            var key = Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "StandUpApp", null);
            if (!Application.ExecutablePath.Equals(key as string))
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Run", "StandUpApp", Application.ExecutablePath);
            }
        }
    }
}
