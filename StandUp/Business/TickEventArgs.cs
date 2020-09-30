using System;
using System.Collections.Generic;
using System.Text;

namespace StandUp.Business
{
    class TickEventArgs : EventArgs
    {
        public TimeSpan Time { get; private set; }
        public ShowTimeColor Color { get;  private set; }

        public TickEventArgs(TimeSpan time, ShowTimeColor color)
        {
            Time = time;
            Color = color;
        }
    }
}
