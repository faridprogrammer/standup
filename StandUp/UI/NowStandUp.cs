using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using StandUp.Business;

namespace StandUp.UI
{
    public partial class NowStandUp : Form
    {
        private DateTime StartTime;
        private bool AllowSnooze;
        private int TotalOpacitySteps;
        private int CurrentOpacityStep;
        RectangleF MessageRect;
        StringFormat MessageFormat;



        public NowStandUp(bool allowSnooze)
        {
            InitializeComponent();

            MessageRect = new RectangleF(Screen.PrimaryScreen.Bounds.Width / 2 - 300, Screen.PrimaryScreen.Bounds.Height / 2 - 150, 600, 300);
            MessageFormat = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };

            StartTime = DateTime.Now;

            AllowSnooze = allowSnooze;

            var bounds = Screen.PrimaryScreen.Bounds;
            Size = new Size(bounds.Width, bounds.Height);
            Location = new Point(0, 0);


            if (Settings.MessageFadeInSeconds == 0)
            {
                ShowRightAway();
            }
            else
            {
                Opacity = 0;
                CurrentOpacityStep = 0;
                TotalOpacitySteps = Settings.MessageFadeInSeconds * 10;
                fadeInTimer.Start();
            }
        }

        private void ShowRightAway()
        {
            StartTime = DateTime.Now;
            ShowTime();
            standTimer.Start();

            Opacity = 1;
            BringToFront();
            Activate();
        }

        private void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            CloseForm();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && Settings.AllowEscapingMessage)
                CloseForm();
        }

        public bool Snooze { get; private set; }
        public bool ShowDesktop { get; private set; }
        public int ShowDesktopSeconds { get; private set; }

        private void CloseForm()
        {
            FormClosing -= NowStandUp_FormClosing;
            Snooze = Settings.AllowSnooze && AllowSnooze && (DateTime.Now - StartTime) < new TimeSpan(0, 0, Settings.StandUpSeconds);
            Close();
        }

        private void btnHideForm_Click(object sender, EventArgs e)
        {
            ShowDesktop = true;
            ShowDesktopSeconds = Settings.StandUpSeconds - (int)(DateTime.Now - StartTime).TotalSeconds;
            FormClosing -= NowStandUp_FormClosing;
            Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowTime();
        }

        private void ShowTime()
        {
            var time = (int)Math.Ceiling((new TimeSpan(0, 0, Settings.StandUpSeconds) - (DateTime.Now - StartTime)).TotalSeconds);
            if (time < 0)
            {
                lblTime.Text = "You can sit down";
                BtnClose.Text = "I'm sitting down";
                btnHideForm.Visible = false;
                standTimer.Stop();
            }
            else
            {
                BtnClose.Text = "Snooze";
                btnHideForm.Visible = true;
                lblTime.Text = string.Format("{0:00}:{1:00}", time / 60, time % 60);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void NowStandUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseForm();
        }

        private void pnlFooter_MouseEnter(object sender, EventArgs e)
        {
            pnlButtons.Visible = true;
        }

        private void fadeInTimer_Tick(object sender, EventArgs e)
        {
            CurrentOpacityStep++;
            if (CurrentOpacityStep < TotalOpacitySteps)
            {
                Opacity = (float)CurrentOpacityStep / TotalOpacitySteps;
            }
            else
            {
                fadeInTimer.Stop();
                ShowRightAway();
            }
        }

        public void CloseReset()
        {
            ClosedReset = true;
            FormClosing -= NowStandUp_FormClosing;
            Close();
        }

        public static bool ClosedReset { get; set; }

        private void NowStandUp_Paint(object sender, PaintEventArgs e)
        {
            using (var font = new Font("Tahoma", 14F))
            {
                e.Graphics.DrawString(Settings.Message, font, Brushes.Lime, MessageRect, MessageFormat);
            }
            var hint = "To close this message, double click on the screen";
            if (Settings.AllowEscapingMessage)
            {
                hint += " or press Esc";
            }
            e.Graphics.DrawString(hint, Font, Brushes.DimGray, 10, 10);
        }
    }
}
