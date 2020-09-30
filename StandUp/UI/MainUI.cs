using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using StandUp.Properties;
using StandUp.Business;
using System.Drawing;
using System.Runtime.InteropServices;

namespace StandUp.UI
{
    internal class MainUI : IDisposable
    {
        #region Fields

        private StateMachine StateMachine;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip notifyMenuStrip;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem currentTimeToolStripMenuItem;
        private ToolStripMenuItem resetToolStripMenuItem;
        private ToolStripMenuItem standingUpToolStripMenuItem;

        #endregion

        public MainUI()
        {
            InitializeComponent();
            StateMachine = new StateMachine();
            StateMachine.Tick += Timer_Tick;
            StateMachine.StateChanged += StateMachine_StateChanged;

            HotKeys.Register(HotKeyModifiers.Alt | HotKeyModifiers.Control, Keys.S, HotKeyRecieved);
        }

        private void StateMachine_StateChanged(object sender, EventArgs e)
        {
            standingUpToolStripMenuItem.Visible = StateMachine.State == State.Snoozing;

            switch (StateMachine.State)
            {
                case State.RedMode:
                    NotifyEnteredRedMode();
                    break;
                case State.CanSitDown:
                    NotifyCanSitDown();
                    break;
                case State.StandingUp:
                    currentTimeToolStripMenuItem.Text = "Should be standing up";
                    break;
                default:
                    break;
            }
        }

        void HotKeyRecieved(object sender, KeyPressedEventArgs e)
        {
            if (e.Keys == Keys.S && e.Modifiers == (HotKeyModifiers.Alt | HotKeyModifiers.Control))
            {
                ManualReset();
            }
        }

        void NotifyCanSitDown()
        {
            notifyIcon1.ShowBalloonTip(10000, "You can now sit down", "Sit down now or reset the timer when you do so", ToolTipIcon.Info);
        }

        void NotifyEnteredRedMode()
        {
            notifyIcon1.ShowBalloonTip(2000, "Prepair to stand up", "Stand-up time is getting close. So prepare to stand up in " + TimeTranslator.Translate(new TimeSpan(0, 0, Business.Settings.RedSeconds)), ToolTipIcon.Info);
        }

        void Timer_Tick(object sender, TickEventArgs e)
        {
            var time = string.Format("{0:00}:{1:00}", e.Time.Minutes, e.Time.Seconds);

            var snoozing = StateMachine.State == State.Snoozing;

            currentTimeToolStripMenuItem.Text = snoozing ? (time + " (Snoozing)") : time;
            currentTimeToolStripMenuItem.ForeColor = e.Color == ShowTimeColor.Red ? Color.Red : Color.Black;

            notifyIcon1.Text = "You should stand up in " + TimeTranslator.Translate(e.Time);
        }

        private void InitializeComponent()
        {
            this.notifyIcon1 = new NotifyIcon();
            this.notifyMenuStrip = new ContextMenuStrip();
            this.currentTimeToolStripMenuItem = new ToolStripMenuItem();
            this.settingsToolStripMenuItem = new ToolStripMenuItem();
            this.toolStripMenuItem1 = new ToolStripSeparator();
            this.exitToolStripMenuItem = new ToolStripMenuItem();
            this.resetToolStripMenuItem = new ToolStripMenuItem();
            this.standingUpToolStripMenuItem = new ToolStripMenuItem();
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.ContextMenuStrip = notifyMenuStrip;
            notifyIcon1.Icon = Resources.Timer;
            notifyIcon1.Text = "Stand Up";
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;
            // 
            // notifyMenuStrip
            // 
            notifyMenuStrip.Items.AddRange(new ToolStripItem[] {
            currentTimeToolStripMenuItem,
            standingUpToolStripMenuItem,
            resetToolStripMenuItem,
            settingsToolStripMenuItem,
            toolStripMenuItem1,
            exitToolStripMenuItem});
            notifyMenuStrip.Name = "notifyMenuStrip";
            // 
            // currentTimeToolStripMenuItem
            // 
            currentTimeToolStripMenuItem.Text = "CurrentTime";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Text = "Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            //
            // standingUpToolStripMenuItem
            //
            standingUpToolStripMenuItem.Text = "Alright, Standing up";
            standingUpToolStripMenuItem.Visible = false;
            standingUpToolStripMenuItem.Click += standingUpToolStripMenuItem_Click;
            // 
            // resetToolStripMenuItem
            // 
            resetToolStripMenuItem.Text = "Reset";
            resetToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.S;
            resetToolStripMenuItem.Click += resetToolStripMenuItem_Click;
        }

        void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            StateMachine.State = State.ShowingSettings;
        }

        void standingUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateMachine.State = State.StandingUp;
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit stand-up application?", "Exit Stand Up?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            Business.Settings.Save();
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StateMachine.State = State.ShowingSettings;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManualReset();
        }

        public void ManualReset()
        {
            StateMachine.Reset();
            notifyIcon1.ShowBalloonTip(2000, "Timer has been reset", "You should stand-up in " + TimeTranslator.Translate(new TimeSpan(0, 0, StandUp.Business.Settings.TotalSeconds)), ToolTipIcon.Info);
        }

        public void Dispose()
        {
            notifyIcon1.Visible = false;
        }
    }
}
