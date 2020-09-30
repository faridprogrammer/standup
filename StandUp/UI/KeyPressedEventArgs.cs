using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace StandUp.UI
{
    public class KeyPressedEventArgs : EventArgs
    {
        private HotKeyModifiers _modifier;
        private Keys _key;

        internal KeyPressedEventArgs(HotKeyModifiers modifier, Keys key)
        {
            _modifier = modifier;
            _key = key;
        }

        public HotKeyModifiers Modifiers
        {
            get { return _modifier; }
        }

        public Keys Keys
        {
            get { return _key; }
        }
    }
}
