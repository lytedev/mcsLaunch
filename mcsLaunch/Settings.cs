using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace mcsLaunch
{
    [Serializable]
    public class Settings
    {
        public static string SettingsFile { get { return "./mcsLaunch.settings"; } }
        public static string EncryptionKey { get { return System.Environment.MachineName + "." + System.Environment.UserName; } }
        public static Version VersionData = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
        public static string VersionString { get { return VersionData.Major + "." + VersionData.Minor + "." + VersionData.Build; } }
        
        public void Save(string file = "")
        {
            if (file == "")
            {
                file = SettingsFile;
            }
            Password = EncryptString(Password, EncryptionKey);
            Username = EncryptString(Username, EncryptionKey);
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            System.IO.FileStream fs = new System.IO.FileStream(file, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            bf.Serialize(fs, this);
            fs.Close();
            Password = DecryptString(Password, EncryptionKey);
            Username = EncryptString(Username, EncryptionKey);
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
                s.Password = DecryptString(s.Password, EncryptionKey);
                s.Username = DecryptString(s.Username, EncryptionKey);
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

        public static string EncryptString(string str, string key)
        {
            if (String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str))
            {
                return "";
            }
            byte[] results;
            System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
            byte[] tdesKey = hashProvider.ComputeHash(utf8.GetBytes(key));
            TripleDESCryptoServiceProvider tdesAlgorithm = new TripleDESCryptoServiceProvider();
            tdesAlgorithm.Key = tdesKey;
            tdesAlgorithm.Mode = CipherMode.ECB;
            tdesAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToEncrypt = utf8.GetBytes(str);
            try
            {
                ICryptoTransform Encryptor = tdesAlgorithm.CreateEncryptor();
                results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }

            return Convert.ToBase64String(results);
        }

        public static string DecryptString(string str, string key)
        {
            if (String.IsNullOrEmpty(str) || String.IsNullOrWhiteSpace(str))
            {
                return "";
            }
            byte[] results;
            System.Text.UTF8Encoding utf8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
            byte[] tdesKey = hashProvider.ComputeHash(utf8.GetBytes(key));
            TripleDESCryptoServiceProvider tdesAlgorithm = new TripleDESCryptoServiceProvider();
            tdesAlgorithm.Key = tdesKey;
            tdesAlgorithm.Mode = CipherMode.ECB;
            tdesAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] dataToDecrypt = Convert.FromBase64String(str);
            try
            {
                ICryptoTransform decryptor = tdesAlgorithm.CreateDecryptor();
                results = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            }
            finally
            {
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }
            return utf8.GetString(results);
        }
    }
}
