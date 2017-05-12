using System;
using System.Windows.Forms;
using System.Drawing;
using SpeedDial.Properties;
using System.Runtime.InteropServices;

namespace SpeedDial
{
    class ProcessIcons : IDisposable
    {
        NotifyIcon ni;
        ContextMenu menu = new ContextMenu();
        SettingsWindow s = new SettingsWindow();

        public ProcessIcons()
        {
            ni = new NotifyIcon();

            //Convert the Bitmap to an icon and use for icon picture
            //Credit: Muhammad Ali Didar's answer at http://stackoverflow.com/questions/8174393/convert-bitmap-to-icon
            Bitmap bit = Resources.Icon;
            IntPtr ptr = bit.GetHicon();
            ni.Icon = Icon.FromHandle(ptr);
            ni.Text = "SpeedDial";
            ni.MouseDoubleClick += OpenSettings;

            menu.MenuItems.Add(new MenuItem("Quit", Quit));
            menu.MenuItems.Add(new MenuItem("Key Binding Settings", OpenSettings));
            ni.ContextMenu = menu;
        }

        private void Quit(object sender, EventArgs e)
        {
            Dispose();
            Environment.Exit(0);
        }

        private void OpenSettings(object sender, EventArgs e)
        {
            ShowSettings();
        }

        private void ShowSettings()
        {
            if (!s.Visible) s.Show();
        }

        //Methods to implement IDisposable
        public void Display()
        {
            ni.Visible = true;
        }

        public void Dispose()
        {
            ni.Visible = false;
        }
    }
}
