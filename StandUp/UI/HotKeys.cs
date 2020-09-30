using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace StandUp.UI
{
    class HotKeys
    {
        #region Constants

        private const int WM_HOTKEY = 0x0312;

        #endregion

        #region Fields

        private static bool IsInitialized;
        private static object SyncRoot = new object();
        private static List<HotKey> Items;

        #endregion

        #region Methods

        private static void Initialize()
        {
            if (IsInitialized)
                return;

            lock (SyncRoot)
            {
                if (IsInitialized)
                    return;

                Items = new List<HotKey>();
                Application.AddMessageFilter(new HotKeyMessageFilter());

                IsInitialized = true;
            }
        }

        public static void Register(HotKeyModifiers modifiers, Keys keys, EventHandler<KeyPressedEventArgs> handler)
        {
            Initialize();

            lock (SyncRoot)
            {
                Items.Add(new HotKey(modifiers, keys, handler));
                RegisterHotKey(IntPtr.Zero, Items.Count, modifiers, keys);
            }
        }

        public static bool Unregister(HotKeyModifiers modifiers, Keys keys)
        {
            Initialize();

            lock (SyncRoot)
            {
                for (int i = 0; i < Items.Count; i++)
                {
                    var item = Items[i];
                    if (item != null && item.Keys == keys && item.Modifiers == modifiers)
                    {
                        Items[i] = null;
                        return UnregisterHotKey(IntPtr.Zero, i + 1) == 1;
                    }
                }
            }
            return false;
        }

        private static void OnKeyReceived(Message m)
        {
            var key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
            var modifier = (HotKeyModifiers)((int)m.LParam & 0xFFFF);

            var hotKey = Items.Find(n => n != null && n.Keys == key && n.Modifiers == modifier);
            if (hotKey != null && hotKey.Handler != null)
            {
                hotKey.Handler(m, new KeyPressedEventArgs(modifier, key));
            }
        }

        #endregion

        #region Win32

        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi)]
        private static extern int RegisterHotKey(IntPtr hWnd, int id, HotKeyModifiers fsModifiers, Keys vk);


        [DllImport("user32.dll", CallingConvention = CallingConvention.Winapi)]
        private static extern int UnregisterHotKey(IntPtr hWnd, int id);

        #endregion

        #region Nested Types

        private class HotKeyMessageFilter : IMessageFilter
        {
            public bool PreFilterMessage(ref Message m)
            {
                if (m.Msg == WM_HOTKEY)
                {
                    OnKeyReceived(m);
                    return true;
                }
                return false;
            }
        }

        private class HotKey
        {
            public HotKeyModifiers Modifiers { get; set; }
            public Keys Keys { get; set; }
            public EventHandler<KeyPressedEventArgs> Handler { get; set; }

            public HotKey(HotKeyModifiers modifiers, Keys keys, EventHandler<KeyPressedEventArgs> handler)
            {
                Modifiers = modifiers;
                Keys = keys;
                Handler = handler;
            }
        }

        #endregion
    }
}
