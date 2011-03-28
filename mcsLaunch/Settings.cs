using System;
using System.Collections.Generic;

namespace mcsLaunch
{
    [Serializable]
    public class Settings
    {
        public static string SettingsFile { get { return "./mcsLaunch.settings"; } }
        
        public void Save(string file = "")
        {
            if (file == "")
            {
                file = SettingsFile;
            }
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.FileStream fs = new System.IO.FileStream(file, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            bf.Serialize(fs, this);
            fs.Close();
        }

        public static Settings Load(string file = "")
        {
            if (file == "")
            {
                file = SettingsFile;
            }
            if (System.IO.File.Exists(file))
            {
                System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                System.IO.FileStream fs = new System.IO.FileStream(file, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                Settings s = (Settings)bf.Deserialize(fs);
                fs.Close();
                return s;
            }
            return Defaults;
        }

        public Settings()
        {
            
        }

        public static Settings Defaults 
        {
            get 
            {
                Settings s = new Settings();

                s.Servers = new List<Server>();
                s.RememberPassword = false;
                s.RememberUsername = false;
                s.SpecifiedOldLauncher = false;
                s.UseOldLauncher = false;
                s.CloseOnLaunch = true;
                s.LaunchOnStartup = false;
                s.ShowNotchBlog = true;

                s.LauncherFile = "";
                s.OldLauncherFile = "";
                s.Username = "";
                s.Password = "";

                s.DefaultServerIndex = 0;
                s.NotchPostsToShow = 5;
                return s;
            }
        }

        public System.Drawing.Size Size { get; set; }
        public System.Drawing.Point Location { get; set; }

        public bool RememberUsername { get; set; }
        public bool RememberPassword { get; set; }
        public bool SpecifiedOldLauncher { get; set; }
        public bool UseOldLauncher { get; set; }
        public bool CloseOnLaunch { get; set; }
        public bool LaunchOnStartup { get; set; }
        public bool ShowNotchBlog { get; set; }

        public string LauncherFile { get; set; }
        public string OldLauncherFile { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public int DefaultServerIndex { get; set; }
        public int NotchPostsToShow { get; set; }

        public List<Server> Servers { get; set; }
    }
}
