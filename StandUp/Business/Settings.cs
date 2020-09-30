using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;

namespace StandUp.Business
{
    class Settings
    {
        public static int TotalSeconds { get; set; }
        public static int RedSeconds { get; set; }
        public static int StandUpSeconds { get; set; }
        public static string Message { get; set; }
        public static bool AllowEscapingMessage { get; set; }
        public static bool AllowSnooze { get; set; }
        public static bool AllowPrepareNotification { get; set; }
        public static int MessageFadeInSeconds { get; set; }
        public static int SnoozeSeconds { get; set; }

        public static string FilePath { get; set; }

        public static void Save()
        {
            if (File.Exists(FilePath))
                File.Delete(FilePath);

            Registry.SetValue(@"HKEY_CURRENT_USER\Software\StandUp", "SettingsPath", FilePath);

            using (var writer = new StreamWriter(FilePath, false, Encoding.UTF8))
            {
                writer.Write("TotalSeconds=");
                writer.WriteLine(TotalSeconds);
                writer.Write("StandUpSeconds=");
                writer.WriteLine(StandUpSeconds);
                writer.Write("AllowEscapingMessage=");
                writer.WriteLine(AllowEscapingMessage);
                writer.Write("Message=");
                writer.WriteLine(Message);
                writer.Write("RedSeconds=");
                writer.WriteLine(RedSeconds);
                writer.Write("AllowSnooze=");
                writer.WriteLine(AllowSnooze);
                writer.Write("AllowPrepareNotification=");
                writer.WriteLine(AllowPrepareNotification);
                writer.Write("MessageFadeInSeconds=");
                writer.WriteLine(MessageFadeInSeconds);
                writer.Write("SnoozeSeconds=");
                writer.WriteLine(SnoozeSeconds);
            }
        }

        static Settings()
        {
            SnoozeSeconds = 60;

            if (!TryGetFilePathFromRegistry())
            {
                var appDir = Path.GetDirectoryName(Application.ExecutablePath);
                FilePath = Path.Combine(appDir, "settings.txt");
            }
            if (!File.Exists(FilePath))
            {
                TotalSeconds = 1200;
                RedSeconds = 60;
                Message = "Stand Up Now ...";
                AllowSnooze = true;
                AllowPrepareNotification = true;
                StandUpSeconds = 30;
                MessageFadeInSeconds = 3;
            }
            else
            {
                LoadSettings();
            }
        }

        private static bool TryGetFilePathFromRegistry()
        {
            try
            {
                FilePath = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\StandUp", "SettingsPath", null);
                return !string.IsNullOrEmpty(FilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private static void LoadSettings()
        {
            var lines = File.ReadAllLines(FilePath);
            var dic = Enumerables.ToDictionary(Enumerables.Select(lines, GetKeyValuePair), KeySelector, ValueSelector);
            TotalSeconds = int.Parse(dic["TotalSeconds"]);

            string value;
            Message = dic.TryGetValue("Message", out value) ? value : "Stand Up Now ...";
            AllowEscapingMessage = dic.TryGetValue("AllowEscapingMessage", out value) ? value.Equals("true", StringComparison.InvariantCultureIgnoreCase) : false;
            RedSeconds = dic.TryGetValue("RedSeconds", out value) ? int.Parse(value) : 60;
            StandUpSeconds = dic.TryGetValue("StandUpSeconds", out value) ? int.Parse(value) : 30;
            AllowSnooze = dic.TryGetValue("AllowSnooze", out value) ? !value.Equals("false", StringComparison.InvariantCultureIgnoreCase) : true;
            AllowPrepareNotification = dic.TryGetValue("AllowPrepareNotification", out value) ? !value.Equals("false", StringComparison.InvariantCultureIgnoreCase) : true;
            MessageFadeInSeconds = dic.TryGetValue("MessageFadeInSeconds", out value) ? int.Parse(value) : 3;
            SnoozeSeconds = dic.TryGetValue("SnoozeSeconds", out value) ? int.Parse(value) : 60;

        }

        private static KeyValuePair<string, string> GetKeyValuePair(string line)
        {
            var parts = line.Split('=');
            return new KeyValuePair<string, string>(parts[0], parts[1]);
        }
        private static string KeySelector(KeyValuePair<string, string> pair)
        {
            return pair.Key;
        }
        private static string ValueSelector(KeyValuePair<string, string> pair)
        {
            return pair.Value;
        }




    }
}
