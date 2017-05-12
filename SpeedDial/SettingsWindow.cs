using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SpeedDial
{
    public partial class SettingsWindow : Form
    {
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hwnd, int id, int fsModifers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hwnd, int id);

        int id0 = 0;
        int id1 = 1;
        int id2 = 2;
        int id3 = 3;
        int id4 = 4;
        int id5 = 5;
        int id6 = 6;
        int id7 = 7;
        int id8 = 8;
        int id9 = 9;
        SettingsHelper sh;

        public SettingsWindow()
        {
            InitializeComponent();
            // The third parameter is the hot key to be pushed. 0x0001 is the ALT key.
            // The last parameter is the second key pushed, 0x30 is 0.
            RegisterHotKey(Handle, id0, 0x0001, 0x30);
            RegisterHotKey(Handle, id1, 0x0001, 0x31);
            RegisterHotKey(Handle, id2, 0x0001, 0x32);
            RegisterHotKey(Handle, id3, 0x0001, 0x33);
            RegisterHotKey(Handle, id4, 0x0001, 0x34);
            RegisterHotKey(Handle, id5, 0x0001, 0x35);
            RegisterHotKey(Handle, id6, 0x0001, 0x36);
            RegisterHotKey(Handle, id7, 0x0001, 0x37);
            RegisterHotKey(Handle, id8, 0x0001, 0x38);
            RegisterHotKey(Handle, id9, 0x0001, 0x39);

            sh = new SettingsHelper();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                try
                {
                    string ThisLaunchLink = sh.GetLink((int)m.WParam);
                    Process.Start(ThisLaunchLink);
                }
                catch (NullReferenceException)
                {
                    //TODO: Add the ability to not see errors anymore
                    if (sh.GetShowError())
                        MessageBox.Show("Link" + (int)m.WParam + " does not have a link assigned to it.");
                }

            }
            base.WndProc(ref m);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

    }
}
