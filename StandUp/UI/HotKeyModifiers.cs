using System;
using System.Collections.Generic;
using System.Text;

namespace StandUp.UI
{
    [Flags]
    public enum HotKeyModifiers : uint
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Win = 8
    }
}
