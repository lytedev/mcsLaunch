using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Xml;

namespace mcsLaunch
{
    public partial class MainForm : Form
    {
        public static Settings Settings = new Settings();

        public MainForm(string[] args)
        {
            InitializeComponent();
            webNotchBlog.Navigate("about:blank");
            Settings = Settings.Load();

            if (File.Exists("version.txt"))
            {

            }
            else
            {
                // Settings.Servers.Add(new Server("server info", "server nickname"));
                // None!
                // End Sponsored Servers
                StreamWriter sw = new StreamWriter(new FileStream("version.txt", FileMode.Create, FileAccess.Write));
                sw.Write(Updater.VersionString);
                sw.Close();
            }

            if (File.Exists(Settings.LauncherFile))
            {

            }
            else
            {
                Setup();
            }

            if (Settings.RememberUsername)
            {
                txtUsername.Text = Settings.Username;
                if (Settings.RememberPassword)
                {
                    txtPassword.Text = Settings.Password;
                }
            }

            this.Text += " " + Updater.VersionString;
            RefreshServers();

            if (Settings.LaunchOnStartup)
            {
                Launch();
            }
        }

        private void lblUsername_Click(object sender, EventArgs e)
        {
            txtUsername.Focus();
            txtUsername.SelectAll();
        }

        public static void LoadDefaultSettings()
        {
            Settings = Settings.Defaults;
            Setup();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text != "" && txtUsername.Text != "")
            {
                cbxServers.Enabled = true;
            }
            else
            {
                
            }
        }

        public static void Setup()
        {
            bool manual = false;
            if (MessageBox.Show("Run auto-setup? If you choose not to, you must setup manually.", "Setup", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                manual = true;
            }
            if (manual)
            {
                PromptForm p = new PromptForm("Minecraft Launcher", "The location of \"Minecraft.exe\" (the launcher):", Properties.Settings.Default.LauncherFile, true, PromptForm.AllFilesFilter);
                DialogResult dr = p.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    Settings.LauncherFile = p.Value;
                    if (MessageBox.Show("Would you like to have the old Minecraft launcher as an option?", "Use old MC launcher?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                    {
                        Settings.SpecifiedOldLauncher = false;
                    }
                    else
                    {
                        p = new PromptForm("Old Minecraft Launcher", "The location of the old \"Minecraft.exe\":", Properties.Settings.Default.OldLauncherFile, true, PromptForm.AllFilesFilter);
                        if (p.ShowDialog() != DialogResult.Cancel)
                        {
                            Settings.SpecifiedOldLauncher = false;
                        }
                        else
                        {
                            Settings.OldLauncherFile = p.Value;
                            Settings.SpecifiedOldLauncher = true;
                        }
                    }
                }
                else
                {
                    Setup();
                }
            }
            else
            {
                ProgressForm.DownloadFile("http://www.minecraft.net/download/Minecraft.exe");
                Settings.LauncherFile = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\Minecraft.exe";
                Settings.OldLauncherFile = "N/A";
                Settings.SpecifiedOldLauncher = false;
                Settings.UseOldLauncher = false;
            }
            Settings.Save();
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {
            txtPassword.Focus();
            txtPassword.SelectAll();
        }

        private void RefreshServers()
        {
            cbxServers.Items.Clear();
            cbxServers.Items.Add("Don't auto-join (None)");
            for (int i = 0; i < Settings.Servers.Count; i++)
            {
                cbxServers.Items.Add(ServerToString(Settings.Servers[i]));
            }
            try
            {
                cbxServers.SelectedIndex = Settings.DefaultServerIndex;
            }
            catch
            {
                cbxServers.SelectedIndex = 0;
            }


            if (Settings.ShowNotchBlog)
            {
                this.MinimumSize = new Size(188, 250);
                this.MaximumSize = new Size(0, 0);
                webNotchBlog.Visible = true;
                webNotchBlog.Navigate("about:blank");
                webNotchBlog.Document.OpenNew(true);
                new System.Threading.Thread(new System.Threading.ThreadStart(LoadNotchBlog)).Start();
            }
            else
            {
                this.MinimumSize = new Size(200, 190);
                this.MaximumSize = new Size(9001, 190); 
                webNotchBlog.Visible = false;
            }
        }

        public void SaveSettings()
        {
            if (Settings.RememberUsername)
            {
                Settings.Username = txtUsername.Text;
            }
            else
            {
                Settings.Username = "";
            }
            if (Settings.RememberPassword)
            {
                Settings.Password = txtPassword.Text;
            }            
            else
            {
                Settings.Password = "";
            }
            Settings.DefaultServerIndex = cbxServers.SelectedIndex;
            Settings.Size = this.Size;
            Settings.Location = this.Location;
            Settings.Save();
        }

        private string ServerToString(Server server)
        {
            return server.Nickname + " (" + server.IP + ")";
        }

        private Server StringToServer(string str)
        {
            try
            {
                Server s = new Server();
                string[] split = str.Split('(');
                s.Nickname = split[0].Trim();
                s.IP = split[1].Substring(0, split[1].Length - 1);
                return s;
            }
            catch
            {
                return null;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                SaveSettings();
            }
            catch
            {

            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SaveSettings();
            new SettingsForm().ShowDialog();
            RefreshServers();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Launch();
        }

        private void Launch()
        {
            string file = Settings.LauncherFile;
            if (Settings.UseOldLauncher)
            {
                file = Settings.OldLauncherFile;
            }
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = file;
                p.StartInfo.Arguments = "";
                if (txtUsername.Text != "")
                {
                    p.StartInfo.Arguments += txtUsername.Text;
                    if (txtPassword.Text != "")
                    {
                        p.StartInfo.Arguments += " " + txtPassword.Text;
                        Server s = StringToServer(cbxServers.SelectedItem.ToString());
                        if (s.IP != "" && (s.IP.Contains(".") || s.IP.Contains("localhost")))
                        {
                            p.StartInfo.Arguments += " " + s.IP;
                        }
                    }
                }
                // process.StartInfo.Arguments 
                p.Start();
                if (Settings.CloseOnLaunch)
                {
                    Application.Exit();
                }
            }
            catch (Exception e)
            {
                if (MessageBox.Show("Error: Could not run \"" + file + "\".\n\n" + e.Message + "\n\nRe-setup? (Recommended)", "Error - Re-setup?", MessageBoxButtons.YesNo, MessageBoxIcon.Error) != System.Windows.Forms.DialogResult.Yes)
                {

                }
                else
                {
                    Setup();
                }
            }
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Launch();
            }
        }

        private void lstServers_DoubleClick(object sender, EventArgs e)
        {
            Launch();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load and check Size
            if (Settings.Size == new Size())
            {
                Settings.Size = this.DefaultSize;
            }
            this.Size = Settings.Size;
            if (this.Size.Width > Screen.PrimaryScreen.Bounds.Width)
            {
                this.Size = MinimumSize;
            }
            if (this.Size.Height > Screen.PrimaryScreen.Bounds.Height)
            {
                this.Size = MinimumSize;
            }

            // Load and check Location
            if (Settings.Location == new Point())
            {
                Settings.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - (this.Width / 2), (Screen.PrimaryScreen.Bounds.Height / 2) - (this.Height / 2));
            }
            this.Location = Settings.Location;
            if (this.Location.X > Screen.PrimaryScreen.Bounds.Width)
            {
                this.Location = new Point((Screen.PrimaryScreen.Bounds.Width / 2) - (this.Width / 2), this.Location.Y);
            }
            if (this.Location.Y > Screen.PrimaryScreen.Bounds.Height)
            {
                this.Location = new Point(this.Location.X, (Screen.PrimaryScreen.Bounds.Height / 2) - (this.Height / 2));
            }
            new System.Threading.Thread(new System.Threading.ThreadStart(Updater.CheckForUpdates)).Start();
            this.BringToFront();
        }

        private void LoadNotchBlog()
        {
            try
            {
                webNotchBlog.BeginInvoke(new MethodInvoker(delegate() { webNotchBlog.Document.OpenNew(true); }));
                string fmt = "X";
                string bg = "#" + this.BackColor.R.ToString(fmt) + this.BackColor.G.ToString(fmt) + this.BackColor.B.ToString(fmt);
                while (bg.Length < 7)
                    bg += "0";
                string loadingHtml = @"<!doctype html>
<style>
html,body{
margin:0;
margin-top:5px;
padding:0;
font-size:7pt;
text-align:center;background-color:" + bg + @";
font-family:'" + this.Font.FontFamily + @"','Lucida Grande',Verdana,Helvetica,Arial,sans-serif;}
</style>Loading...<br /><br /><img src=" + "\"http://i.imgur.com/HPIqf.gif\"" + @" />";
                webNotchBlog.BeginInvoke(new MethodInvoker(delegate() { webNotchBlog.Document.Write(loadingHtml); }));
                webNotchBlog.BeginInvoke(new MethodInvoker(delegate() { webNotchBlog.AllowNavigation = false; ; }));

                // webNotchBlog.Document.OpenNew(true);
                WebClient wc = new WebClient();
                wc.Encoding = System.Text.Encoding.UTF8;
                string rss = wc.DownloadString("http://notch.tumblr.com/rss");

                XmlDocument xml = new XmlDocument();
                xml.InnerXml = rss;

                XmlNode siteTitleData = xml.GetElementsByTagName("title")[0];
                XmlNodeList posts = xml.GetElementsByTagName("item");

                string bgl = "#" + (this.BackColor.R + 20).ToString(fmt) + (this.BackColor.G + 20).ToString(fmt) + (this.BackColor.B + 20).ToString(fmt);
                string bgd = "#" + (this.BackColor.R - 20).ToString(fmt) + (this.BackColor.G - 20).ToString(fmt) + (this.BackColor.B - 20).ToString(fmt);
                string fg = "#" + this.ForeColor.R.ToString(fmt) + this.ForeColor.G.ToString(fmt) + this.ForeColor.B.ToString(fmt);
                while (bgl.Length < 7)
                    bgl += "0";
                while (bgd.Length < 7)
                    bgd += "0";
                while (fg.Length < 7)
                    fg += "0";
                string siteTitle = siteTitleData.InnerText;
                string innerHtml = @"<!doctype html>
<style>
html,body{
font-size:7pt;
background-color:" + bg + @";
margin:0;
padding:0;
font-family:'" + this.Font.FontFamily + @"','Lucida Grande',Verdana,Helvetica,Arial,sans-serif;
color:" + fg + @";}
h1{
font-weight:normal;
font-size:9pt;
text-align:center;
margin:0;
padding:0;}
.hr {
border-top:solid 1px " + bgd + @";
margin:5px 0;
padding:0;
height:1px;
background-color:" + bgl + @";}
</style>
<h1>" + siteTitle + @"</h1>
<div class=" + "\"hr\"" + @">&nbsp;</div>";
                for (int i = 0; i < Math.Min(posts.Count, Settings.NotchPostsToShow); i++)
                {
                    string url = "http://notch.tumblr.com";
                    string title = "Title";
                    string date = "1 day ago";
                    string description = "This is the description.";
                    try
                    {
                        System.Text.Encoding ascii = System.Text.Encoding.ASCII;
                        System.Text.Encoding utf8 = System.Text.Encoding.UTF8;
                        XmlNode currentPost = posts.Item(i);
                        title = currentPost.ChildNodes.Item(0).InnerText;
                        description = currentPost.ChildNodes.Item(1).InnerText;
                        url = currentPost.ChildNodes.Item(2).InnerText;
                        // guid is next
                        date = currentPost.ChildNodes.Item(4).InnerText;
                        string[] dateData = date.Split(' ');
                        string monthString = dateData[2].ToLower();
                        int month = 1;
                        switch (monthString)
                        {
                            case "jan":
                                month = 1;
                                break;
                            case "feb":
                                month = 2;
                                break;
                            case "mar":
                                month = 3;
                                break;
                            case "apr":
                                month = 4;
                                break;
                            case "may":
                                month = 5;
                                break;
                            case "jun":
                                month = 6;
                                break;
                            case "jul":
                                month = 7;
                                break;
                            case "aug":
                                month = 8;
                                break;
                            case "sep":
                                month = 9;
                                break;
                            case "oct":
                                month = 10;
                                break;
                            case "nov":
                                month = 11;
                                break;
                            case "dec":
                                month = 12;
                                break;
                        }
                        string[] timeData = dateData[4].Split(':');
                        int notchTimeOffset = Convert.ToInt32(date.Substring(date.Length - 5, 3));
                        TimeSpan currentOffset = TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now);
                        DateTime currentDate = DateTime.Now;
                        DateTime postDateTime = new DateTime(Convert.ToInt32(dateData[3]), month, Convert.ToInt32(dateData[1]), Convert.ToInt32(timeData[0]), Convert.ToInt32(timeData[1]), Convert.ToInt32(timeData[2]));
                        postDateTime = postDateTime.AddHours(-(notchTimeOffset - currentOffset.Hours));
                        if (currentDate.Year - postDateTime.Year > 1)
                        {
                            int difference = currentDate.Year - postDateTime.Year;
                            date = difference + " years ago";
                        }
                        else if (currentDate.Year - postDateTime.Year == 1)
                        {
                            date = "last year";
                        }
                        else if (currentDate.Month - postDateTime.Month > 1)
                        {
                            int difference = currentDate.Month - postDateTime.Month;
                            date = difference + " months ago";
                        }
                        else if (currentDate.Month - postDateTime.Month == 1)
                        {
                            date = "last month";
                        }
                        else if (currentDate.Day - postDateTime.Day > 28)
                        {
                            date = "4 weeks ago";
                        }
                        else if (currentDate.Day - postDateTime.Day > 21)
                        {
                            date = "3 weeks ago";
                        }
                        else if (currentDate.Day - postDateTime.Day > 14)
                        {
                            date = "2 weeks ago";
                        }
                        else if (currentDate.Day - postDateTime.Day > 7)
                        {
                            date = "last week";
                        }
                        else if (currentDate.Day - postDateTime.Day > 1)
                        {
                            int difference = currentDate.Day - postDateTime.Day;
                            date = difference + " days ago";
                        }
                        else if (currentDate.Day - postDateTime.Day == 1)
                        {
                            date = "a day ago";
                        }
                        else if (currentDate.Hour - postDateTime.Hour > 1)
                        {
                            int difference = currentDate.Hour - postDateTime.Hour;
                            date = difference + " hours ago";
                        }
                        else if (currentDate.Hour - postDateTime.Hour == 1)
                        {
                            date = "an hour ago";
                        }
                        else if (currentDate.Minute - postDateTime.Minute > 1)
                        {
                            int difference = currentDate.Minute - postDateTime.Minute;
                            date = difference + " minutes ago";
                        }
                        else if (currentDate.Minute - postDateTime.Minute == 1)
                        {
                            date = "a minute ago";
                        }
                        else if (currentDate.Second - postDateTime.Second > 1)
                        {
                            int difference = currentDate.Second - postDateTime.Second;
                            date = difference + " seconds ago";
                        }
                        else if (currentDate.Second - postDateTime.Second == 1)
                        {
                            date = "a second ago";
                        }
                        else
                        {
                            date = "just now";
                        }
                    }
                    catch (Exception e)
                    {
                        date = "date fmt error";
                    }
                    innerHtml += @"<a href=" + "\"" + url + "\"" + @">" + title + @"</a><br />posted " + date + @"<br /><br />
" + description;
                    if (i < Math.Min(posts.Count, Settings.NotchPostsToShow) - 1)
                    {
                        innerHtml += @"<div class=" + "\"hr\"" + @">&nbsp;</div>";
                    }
                }
                try
                {
                    webNotchBlog.BeginInvoke(new MethodInvoker(delegate() { webNotchBlog.Document.OpenNew(true); }));
                    webNotchBlog.BeginInvoke(new MethodInvoker(delegate() { webNotchBlog.Document.Write(innerHtml); }));
                    webNotchBlog.BeginInvoke(new MethodInvoker(delegate() { webNotchBlog.AllowNavigation = false; ; }));
                }
                catch
                {
                    LoadNotchBlog();
                }
            }
            catch
            {

            }
        }

        private void webNotchBlog_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.ToString().ToLower().Trim() != "about:blank")
            {
                e.Cancel = true;
                System.Diagnostics.Process.Start(e.Url.ToString());
            }
        }
    }
}
