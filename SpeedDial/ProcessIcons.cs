using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using SpeedDial.Properties;

namespace SpeedDial
{
    class ProcessIcons : IDisposable
    {
        NotifyIcon ni;

        public ProcessIcons()
        {
            ni = new NotifyIcon();

            //Convert the Bitmap to an icon and use for icon picture
            //Credit: Muhammad Ali Didar's answer at http://stackoverflow.com/questions/8174393/convert-bitmap-to-icon
            Bitmap bit = Resources.Icon;
            IntPtr ptr = bit.GetHicon();
            ni.Icon = Icon.FromHandle(ptr);
            ni.Text = "SpeedDial";
            ni.MouseDoubleClick += Ni_MouseDoubleClick;
        }

        private void Ni_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Settings s = new Settings();
            s.Show();
        }

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
