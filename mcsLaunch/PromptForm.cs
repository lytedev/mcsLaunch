using System;
using System.Windows.Forms;

namespace mcsLaunch
{
    public partial class PromptForm : Form
    {
        public PromptForm(string caption, string label, string def = "", bool browse = false, string filter = "", bool canCancel = true)
        {
            InitializeComponent();
            if (!canCancel)
            {
                btnCancel.Enabled = false;
            }
            else
            {
                btnCancel.Enabled = true;
            }
            if (filter == "")
            {
                filter = AllFilesFilter;
            }
            if (browse)
            {
                btnBrowse.Visible = true;
                btnBrowse.Enabled = true;
            }
            else
            {
                btnBrowse.Visible = false;
                btnBrowse.Enabled = false;
            }
            this.Text = caption;
            lblInput.Text = label;
            txtInput.Text = def;
            ofd.Filter = filter;
            txtInput.Focus();
            txtInput.SelectAll();
        }

        private void Prompt_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    btnOk.PerformClick();
                    break;
                case Keys.Escape:
                    btnCancel.PerformClick();
                    break;
            }
        }

        private void Browse()
        {
            ofd.FileName = txtInput.Text;
            if (ofd.ShowDialog() != DialogResult.Cancel)
            {
                txtInput.Text = ofd.FileName;
            }
            txtInput.SelectAll();
            txtInput.Focus();
        }

        public static string AllFilesFilter { get { return "All files|*.*"; } }
        public string Value { get { return txtInput.Text; } }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            Browse();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void Prompt_Load(object sender, EventArgs e)
        {

        }
    }
}