using System;
using System.Windows.Forms;

namespace mcsLaunch
{
    public partial class SettingsForm : Form
    {
        Settings Settings = MainForm.Settings;
        bool checknow = true;

        public SettingsForm()
        {
            InitializeComponent();

            LoadSettings();
        }

        private void LoadSettings()
        {
            Settings = MainForm.Settings;
            checknow = false;
            chkRemUser.Checked = Settings.RememberUsername;
            if (chkRemUser.Checked)
            {
                chkRemPass.Checked = Settings.RememberPassword;
                chkRemPass.Enabled = true;
            }
            else
            {
                chkRemPass.Enabled = false;
                chkRemPass.Checked = false;
            }
            txtLauncher.Text = Settings.LauncherFile;
            if (Settings.SpecifiedOldLauncher)
            {
                txtOldLaunch.Text = Settings.OldLauncherFile;
                chkUseOldLaunch.Enabled = true;
                chkUseOldLaunch.Checked = Settings.UseOldLauncher;
            }
            else
            {
                txtOldLaunch.Text = "N/A";
                chkUseOldLaunch.Enabled = false;
                chkUseOldLaunch.Checked = false;
            }
            chkCloseOnLaunch.Checked = Settings.CloseOnLaunch;
            checknow = true;
            chkLaunchOnStartup.Checked = false;
            chkLaunchOnStartup.Checked = Settings.LaunchOnStartup;
            chkNotchBlog.Checked = Settings.ShowNotchBlog;
            txtToShow.Text = "" + Settings.NotchPostsToShow;
            RefreshServers();
        }

        private void chkRemUser_CheckedChanged(object sender, EventArgs e)
        {
            chkRemPass.Enabled = chkRemUser.Checked;
            if (chkRemPass.Enabled == false)
            {
                chkRemPass.Checked = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Save();
            Close();
        }

        private void Save()
        {
            Settings.LaunchOnStartup = chkLaunchOnStartup.Checked;
            Settings.RememberPassword = chkRemPass.Checked;
            Settings.RememberUsername = chkRemUser.Checked;
            Settings.UseOldLauncher = chkUseOldLaunch.Checked;
            Settings.CloseOnLaunch = chkCloseOnLaunch.Checked;
            Settings.ShowNotchBlog = chkNotchBlog.Checked;
            if (Settings.ShowNotchBlog && Settings.NotchPostsToShow < 1)
            {
                Settings.NotchPostsToShow = 5;
            }
            try
            {
                Settings.NotchPostsToShow = Convert.ToInt32(txtToShow.Text);
                if (Settings.NotchPostsToShow > 20)
                {
                    txtToShow.Text = "20";
                    Settings.NotchPostsToShow = 20;
                }
            }
            catch
            {
                txtToShow.Text = "5";
                Settings.NotchPostsToShow = 5;
            }
            MainForm.Settings = Settings;
        }

        private void btnSetup_Click(object sender, EventArgs e)
        {
            Save();
            MainForm.Setup();
            Save();
            LoadSettings();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            MainForm.LoadDefaultSettings();
            Save();
            LoadSettings();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Save();
        }

        private void chkRemPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRemPass.Checked == true && checknow)
            {
                if (MessageBox.Show("Warning: This will cause your password to be stored on your filesystem. If you still want to save your password, click OK.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Cancel)
                {

                }
                else
                {
                    chkRemPass.Checked = false;
                }
            }
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

        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            if (txtServer.Enabled && txtNickname.Enabled)
            {
                Server s = new Server(txtServer.Text, txtNickname.Text);
                string serverData = ServerToString(s);
                lstServers.SelectedItem = serverData;
                if (txtServer.Text != "" && txtNickname.Text != "")
                {
                    btnSave.Enabled = true;
                    btnRemove.Enabled = true;
                }
                else
                {
                    // btnSave.Enabled = false;
                    // btnRemove.Enabled = false;
                }
            }
            else
            {
                // btnSave.Enabled = false;
                // btnRemove.Enabled = false;
            }
        }

        private void lstServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string serverData = lstServers.SelectedItem.ToString();
                Server s = StringToServer(serverData);
                txtNickname.Text = s.Nickname;
                txtServer.Text = s.IP;
                txtNickname.Enabled = true;
                txtServer.Enabled = true;
                btnRemove.Enabled = true;
                btnSave.Enabled = true;
                Settings.DefaultServerIndex = lstServers.SelectedIndex;
            }
            catch
            {

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstServers.SelectedIndex > 0)
            {
                int x = lstServers.SelectedIndex;
                lstServers.Items.RemoveAt(lstServers.SelectedIndex);
                lstServers.SelectedIndex = x - 1;
                Settings.Servers.RemoveAt(x - 1);
            }
            else
            {

            }
            Save();
            RefreshServers();
        }

        private void RefreshServers()
        {
            lstServers.Items.Clear();
            lstServers.Items.Add("Don't auto-join (None)");
            for (int i = 0; i < Settings.Servers.Count; i++)
            {
                lstServers.Items.Add(ServerToString(Settings.Servers[i]));
            }

            try
            {
                lstServers.SelectedIndex = Settings.DefaultServerIndex;
            }
            catch
            {
                lstServers.SelectedIndex = 0;
            }
        }

        private void SaveServer()
        {
            int index = -1;
            if (txtServer.Text.Contains("."))
            {
                string ip = txtServer.Text;
                string nickname = txtNickname.Text;
                for (int i = 0; i < Settings.Servers.Count; i++)
                {
                    if (Settings.Servers[i].IP == ip)
                    {
                        index = i;
                        break;
                    }
                    if (Settings.Servers[i].Nickname == nickname)
                    {
                        index = i;
                    }
                }
                if (index != -1)
                {
                    Settings.Servers[index].IP = ip.Trim();
                    Settings.Servers[index].Nickname = nickname.Trim();
                }
                else
                {
                    Settings.Servers.Add(new Server(ip, nickname));
                    index = Settings.Servers.Count - 1;
                }
                Save();
                RefreshServers();
                if (index != -1)
                {
                    lstServers.SelectedIndex = index + 1;
                }
                else
                {
                    lstServers.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("Invalid server address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveServer();
        }

        private void txtServer_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SaveServer();
            }
        }

        private void chkLaunchOnStartup_CheckedChanged(object sender, EventArgs e)
        {
            chkCloseOnLaunch.Checked = chkCloseOnLaunch.Enabled = !chkLaunchOnStartup.Checked;
        }

        private void chkNotchBlog_CheckedChanged(object sender, EventArgs e)
        {
            txtToShow.Enabled = chkNotchBlog.Checked;
        }
    }
}