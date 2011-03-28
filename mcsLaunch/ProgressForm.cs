using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace mcsLaunch
{
    public partial class ProgressForm : Form
    {
        private string file = "";
        private string localFile = "";

        public ProgressForm(string caption, string label, int min, int max, int val, bool canCancel = false)
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
            this.Text = caption;
            lblInput.Text = label;
            barProgress.Minimum = min;
            barProgress.Maximum = max;
            barProgress.Value = val;
            file = "";
            localFile = "";
        }

        public ProgressForm(string caption, string label, int min, int max, int val, string file, string localFile, bool canCancel = false)
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
            this.Text = caption;
            lblInput.Text = label;
            barProgress.Minimum = min;
            barProgress.Maximum = max;
            barProgress.Value = val;
            this.file = file;
            this.localFile = localFile;
        }

        private void Prompt_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    btnCancel.PerformClick();
                    break;
            }
        }

        public static string AllFilesFilter { get { return "All files|*.*"; } }
        public int Value { get { return barProgress.Value; } set { barProgress.Value = value; } }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        static ProgressForm CurrentProgressForm;
        public static void DownloadFile(string file, char splitType = '/', bool hideForm = false, string localFile = "")
        {
            string[] fSplit = file.Split(splitType);
            if (localFile == "")
            {
                localFile = fSplit[fSplit.Length - 1];
            }
            if (hideForm)
            {
                System.Net.WebClient webClient = new System.Net.WebClient();
                // webClient.Agen
                //webClient.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                //webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                webClient.DownloadFile(new System.Uri(file), localFile);
            }
            else
            {
                ProgressForm pf = new ProgressForm("Download", "Downloading \"" + file + "\"...", 0, 100, 0, file, localFile);
                CurrentProgressForm = pf;
                CurrentProgressForm.Show();
            }
        }

        static void webClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            CurrentProgressForm.Close();
        }

        static void webClient_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            CurrentProgressForm.Value = e.ProgressPercentage;
        }

        private void ProgressForm_Load(object sender, EventArgs e)
        {
            if (file != "")
            {
                try
                {
                    System.Net.WebClient webClient = new System.Net.WebClient();
                    webClient.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(webClient_DownloadProgressChanged);
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(webClient_DownloadFileCompleted);
                    webClient.DownloadFileAsync(new System.Uri(file), localFile);
                }
                catch
                {
                    MessageBox.Show("No internet connection could be established. Downloading \"" + file + "\" failed.");
                }
            }
        }
    }
}