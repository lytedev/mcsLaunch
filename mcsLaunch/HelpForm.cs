using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mcsLaunch
{
    public partial class HelpForm : Form
    {
        const string helpFile = "http://lytedev.flansite.com/files/mcsLaunch/";

        public HelpForm()
        {
            InitializeComponent();
            this.Text = "mcsLaunch Help " + Settings.VersionString;
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            webHelp.Navigate(helpFile);
            webHelp.Focus();
            webHelp.Select();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HelpForm_KeyUp(object sender, KeyEventArgs e)
        {
            MessageBox.Show("");
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void webHelp_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.ToString() != helpFile)
            {
                e.Cancel = true;
                System.Diagnostics.Process.Start(e.Url.ToString());
            }
        }

        private void webHelp_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
