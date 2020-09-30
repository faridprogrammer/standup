using System;
using System.Collections.Generic;
using System.Text;

namespace StandUp.Business
{
    class TimeTranslator
    {
        public static string Translate(TimeSpan time)
        {
            if (time.Days > 1)
                return time.Days + " Days";

            if (time.Days > 0)
                return "1 Day";

            if (time.Hours > 1)
                return time.Hours + " hours";

            if (time.Hours > 0)
                return "1 hour";

            if (time.Minutes > 1)
                return time.Minutes + " minutes";

            if (time.Minutes > 0)
                return "1 minute";

            if (time.Seconds > 30)
                return "less than a minute";

            if (time.Seconds > 10)
                return "less than 30 seconds";

            if (time.Seconds > 0)
                return "less than 10 seconds";

            return "no time";
        }
    }
}
