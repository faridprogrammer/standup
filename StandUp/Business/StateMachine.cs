using System;
using System.Collections.Generic;
using System.Text;

namespace StandUp.Business
{
    class StateMachine
    {
        private State _State;

        public State State
        {
            get { return _State; }
            set
            {
                if (SetState(value))
                {
                    OnStateChanged(EventArgs.Empty);
                }
            }
        }


        private StandUpTimer Timer;

        public StateMachine()
        {
            _State = State.Ready;

            Timer = new StandUpTimer(this);
            Timer.Tick += Timer_Tick;
        }

        private bool SetState(State state)
        {
            if ((_State == Business.State.Snoozing && state == Business.State.RedMode))
            {
                return false;
            }

            switch (state)
            {
                case State.Ready:
                    Timer.Reset();
                    break;
                case State.RedMode:
                    break;
                case State.Snoozing:
                    Timer.Reset(Settings.SnoozeSeconds);
                    break;
                case State.StandingUp:
                    if (this._State == Business.State.Snoozing)
                    {
                        Timer.AlrightStandingUp(Settings.StandUpSeconds);
                    }
                    else //ShowingStandUp
                    {
                        Timer.AlrightStandingUp();
                    }
                    break;
                case State.ShowingStandUp:
                    break;
                case State.ShowingSettings:
                    Timer.ShowSettings();
                    break;
                case State.CanSitDown:
                    _State = Business.State.CanSitDown;
                    OnStateChanged(EventArgs.Empty);
                    state = Business.State.Ready;
                    Timer.Reset();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("state");
            }

            _State = state;
            return true;
        }

        public event EventHandler StateChanged;
        private void OnStateChanged(EventArgs e)
        {
            if (StateChanged != null)
                StateChanged(this, e);
        }

        public event EventHandler<TickEventArgs> Tick;
        private void OnTick(TickEventArgs e)
        {
            if (Tick != null)
                Tick(this, e);
        }

        private void Timer_Tick(object sender, TickEventArgs e)
        {
            OnTick(e);
        }

        public void Reset()
        {
            this._State = Business.State.CanSitDown;
            State = Business.State.Ready;
        }
    }

    enum State
    {
        Ready,
        RedMode,
        Snoozing,
        StandingUp,
        CanSitDown,
        ShowingStandUp,
        ShowingSettings,
    }
}
