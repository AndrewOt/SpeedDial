using System;
using Newtonsoft.Json;
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Text;

namespace SpeedDial
{
    class SettingsHelper
    {
        private Settings s;

        public SettingsHelper()
        {
            LoadSettings();
        }

        private void LoadSettings()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "settings.json");
            StreamReader r;
            
            try
            {
                r = new StreamReader(path);
                string json = r.ReadToEnd();
                r.Close();
                s = JsonConvert.DeserializeObject<Settings>(json);
            }
            catch (FileNotFoundException)
            {
                //If the file is not found, ask if they can locate it, if not, create a new one.
                DialogResult FileAnswer = MessageBox.Show(@"I'm sorry, the settings file could not be found. 
Would you like to create a new file?", 
                    "File Not Found", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (FileAnswer == DialogResult.Yes)
                {
                    //Create a new settings file in background and open settings page
                    using (FileStream fs = File.Create("settings.json")) { 
                        string BlankSettings = @"{
    Link1 : '',
    Link2 : '',
    Link3 : '',
    Link4 : '',
    Link5 : '',
    Link6 : '',
    Link7 : '',
    Link8 : '',
    Link9 : '',
    ShowError : 'True'
}";

                        Byte[] defaults = new UTF8Encoding(true).GetBytes(BlankSettings);
                        fs.Write(defaults, 0, defaults.Length);

                    }
                    
                    MessageBox.Show("Now you can add links by opening the settings window from the system tray icon.");
                }
                else
                {
                    //Close
                    Environment.Exit(0);
                }
            }
        }

        public string GetLink(int LinkNum)
        {
            switch (LinkNum)
            {
                case 0: return s.Link_0;
                case 1: return s.Link_1;
                case 2: return s.Link_2;
                case 3: return s.Link_3;
                case 4: return s.Link_4;
                case 5: return s.Link_5;
                case 6: return s.Link_6;
                case 7: return s.Link_7;
                case 8: return s.Link_8;
                case 9: return s.Link_9;
                default: return string.Empty;
            }
        }

        public bool GetShowError()
        {
            return s.ShowError;
        }

        public void WriteSettings()
        {
            JsonConvert.SerializeObject(s);
            //Write s to the settings file.
        }

        public void SetLink(string link, string LinkNum)
        {
            var f = typeof(Settings).GetFields();
            foreach (FieldInfo fi in f)
            {
                if (fi.Name.Split('_')[1] == LinkNum)
                {
                    fi.SetValue(s, link);
                    break;
                }
            }
        }

        public void ToggleShowError()
        {
            s.ShowError = !s.ShowError;
        }

    }
}
