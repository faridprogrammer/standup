using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using StandUp.UI;

namespace StandUp.Business
{
    class StandUpTimer
    {
        private DateTime StartTime;
        private TimeSpan Length;
        private readonly TimeSpan OneSecond = new TimeSpan(0, 0, 1);
        private TimeSpan RedThreshold;
        private Timer MainTimer;
        private Timer StandTimer;
        private int StandingUpSeconds;
        private NowStandUp NowStandUp;


        public StateMachine StateMachine { get; private set; }

        public StandUpTimer(StateMachine stateMachine)
        {
            StateMachine = stateMachine;

            InitTimers();

            ApplySettings();
            Reset();
        }

        private void InitTimers()
        {
            MainTimer = new Timer();
            MainTimer.Interval = 1000;
            MainTimer.Tick += MainTimer_Tick;
        }

        public event EventHandler<TickEventArgs> Tick;

        private void OnTick(TickEventArgs e)
        {
            if (Tick != null)
                Tick(this, e);
        }

        private void StandTimer_Tick(object sender, EventArgs e)
        {
            StandTimer.Stop();

            if (StateMachine.State == State.StandingUp)
            {
                StateMachine.State = State.CanSitDown;
            }
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            var time = OneSecond + Length - (DateTime.Now - StartTime);
            if (time.TotalSeconds > 0)
            {
                ShowTime(time);
            }
            else if (time.TotalSeconds < -2 * Settings.TotalSeconds)
            {
                Reset();
            }
            else
            {
                ShowStandUpNow(true);
            }
        }

        public void ApplySettings()
        {
            RedThreshold = new TimeSpan(0, 0, Settings.RedSeconds);
        }


        public void ShowStandUpNow(bool allowSnooze)
        {
            MainTimer.Stop();

            try
            {
                NowStandUp = new NowStandUp(allowSnooze);
                NowStandUp.ShowDialog();
                if (NowStandUp.ClosedReset)
                {
                    return;
                }

                if (NowStandUp.Snooze)
                {
                    StateMachine.State = State.Snoozing;
                }
                else if (NowStandUp.ShowDesktop && NowStandUp.ShowDesktopSeconds > 0)
                {
                    StandingUpSeconds = NowStandUp.ShowDesktopSeconds;
                    StateMachine.State = State.StandingUp;
                }
                else
                {
                    StateMachine.State = State.Ready;
                }
            }
            finally
            {
                NowStandUp.Dispose();
                NowStandUp = null;
            }
        }

        public void AlrightStandingUp()
        {
            AlrightStandingUp(StandingUpSeconds);
        }

        public void AlrightStandingUp(int seconds)
        {
            if (seconds <= 0)
            {
                Reset();
                return;
            }

            MainTimer.Stop();

            StandTimer = new Timer();
            StandTimer.Interval = seconds * 1000;
            StandTimer.Tick += StandTimer_Tick;
            StandTimer.Start();
        }


        public void Reset()
        {
            if (NowStandUp != null)
            {
                NowStandUp.CloseReset();
            }

            Reset(Settings.TotalSeconds);
        }

        public void Reset(int seconds)
        {

            StartTime = DateTime.Now;
            Length = new TimeSpan(0, 0, seconds);
            ShowTime(Length);
            MainTimer.Start();
        }


        private void ShowTime(TimeSpan timeSpan)
        {
            var args = new TickEventArgs(timeSpan, timeSpan < RedThreshold ? ShowTimeColor.Red : ShowTimeColor.Normal);
            OnTick(args);
            if (timeSpan < RedThreshold)
            {
                if (StateMachine.State != State.RedMode && Settings.AllowPrepareNotification)
                {
                    StateMachine.State = State.RedMode;
                }
            }
        }

        public void ShowSettings()
        {
            MainTimer.Stop();

            using (var form = new SettingsForm())
            {
                if (form.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    MainTimer.Start();
                }
                else
                {
                    ApplySettings();
                    Reset();
                }
            }
        }
    }
}
