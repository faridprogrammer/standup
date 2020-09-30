using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StandUp.Business;
using System.IO;

namespace StandUp.UI
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            txtDuration.Text = Settings.TotalSeconds.ToString();
            txtMessage.Text = Settings.Message;
            txtRedColor.Text = Settings.RedSeconds.ToString();
            chkEscapeMessage.Checked = Settings.AllowEscapingMessage;
            chkSnooze.Checked = Settings.AllowSnooze;
            chkAllowPrepareNotification.Checked = Settings.AllowPrepareNotification;
            txtStandUpSeconds.Text = Settings.StandUpSeconds.ToString();
            txtFilePath.Text = Settings.FilePath;
            txtFadeInSeconds.Text = Settings.MessageFadeInSeconds.ToString();
            txtSnoozeTime.Text = Settings.SnoozeSeconds.ToString();
        }

        private void CloseOK()
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void CloseCancel()
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Close();
        }

        private void btnSaveDuration_Click(object sender, EventArgs e)
        {
            int seconds, redSeconds, standUpSeconds, fadeInSeconds, snoozeSeconds;
            if (!int.TryParse(txtDuration.Text, out seconds) 
                || !int.TryParse(txtRedColor.Text, out redSeconds)
                || !int.TryParse(txtFadeInSeconds.Text, out fadeInSeconds)
                || !int.TryParse(txtStandUpSeconds.Text, out standUpSeconds)
                || !int.TryParse(txtSnoozeTime.Text, out snoozeSeconds))
            {
                MessageBox.Show("Enter number of seconds");
                return;
            }

            if (!CheckFilePath())
            {
                return;
            }

            Settings.TotalSeconds = seconds;
            Settings.AllowEscapingMessage = chkEscapeMessage.Checked;
            Settings.Message = txtMessage.Text;
            Settings.RedSeconds = redSeconds;
            Settings.AllowSnooze = chkSnooze.Checked;
            Settings.AllowPrepareNotification = chkAllowPrepareNotification.Checked;
            Settings.StandUpSeconds = standUpSeconds;
            Settings.FilePath = txtFilePath.Text;
            Settings.MessageFadeInSeconds = fadeInSeconds;
            Settings.SnoozeSeconds = snoozeSeconds;

            Settings.Save();

            CloseOK();
        }

        private bool CheckFilePath()
        {
            try
            {
                new StreamWriter(txtFilePath.Text, true, Encoding.UTF8).Dispose();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            CloseCancel();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var openFile = new OpenFileDialog())
            {
                try
                {
                    openFile.InitialDirectory = Path.GetDirectoryName(txtFilePath.Text);
                }
                catch 
                { }
                openFile.Filter = "*.txt|Text files";
                openFile.DefaultExt = "txt";
                openFile.AddExtension = true;
                if (openFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    txtFilePath.Text = openFile.FileName;
            }
        }

        private void chkSnooze_CheckedChanged(object sender, EventArgs e)
        {
            txtSnoozeTime.Enabled = chkSnooze.Checked;
        }
    }
}
