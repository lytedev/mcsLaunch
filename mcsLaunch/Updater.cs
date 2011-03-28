using System;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace mcsLaunch
{
    public class Updater
    {
        public static string ExecutableUrl { get { return "http://lytedev.flansite.com/files/mcsLaunch/mcsLaunch.exe"; } }
        public static string VersionUrl { get { return "http://lytedev.flansite.com/files/mcsLaunch/version.txt"; } }
        public static string UpdaterUrl { get { return "http://lytedev.flansite.com/files/mcsLaunch/mcsLaunchUpdater.exe"; } }
        public static string UpdaterLocalName { get { return "mcsLaunchUpdater.exe"; } }
        public static Version VersionData = new Version(System.Windows.Forms.Application.ProductVersion);
        public static string VersionString { get { return VersionData.Major + "." + VersionData.Minor + "." + VersionData.Build; } }

        public static void CheckForUpdates()
        {
            if (File.Exists(UpdaterLocalName))
            {
                File.Delete(UpdaterLocalName);
            }

            Version versionData = new Version(System.Windows.Forms.Application.ProductVersion);
            string latestVersion = new WebClient().DownloadString(VersionUrl);

            if (VersionString.ToLower().Trim() != latestVersion.ToLower().Trim())
            {
                Program.MarkedForUpdate = true;
                Program.MainForm.BeginInvoke(new System.Windows.Forms.MethodInvoker(delegate() { Program.MainForm.Text += "*"; }));
            }
            else
            {

            }
        }

        public static void UpdateApplication(bool dontRun)
        {
            WebClient wc = new WebClient();
            wc.DownloadFile(UpdaterUrl, UpdaterLocalName);
            Process mcslu = new Process();
            Process mcslp = Process.GetCurrentProcess();
            ProcessModule mcsl = mcslp.MainModule;
            mcslu.StartInfo.FileName = UpdaterLocalName;

            string fn = mcsl.FileName;
            string[] fns = mcsl.FileName.Split('\\');
            fn = fns[fns.Length - 1];
            string[] fnns = fn.Split('.');
            string fpn = "";
            for (int i = 0; i < fnns.Length - 1; i++)
            {
                fpn += fnns[i] + ".";
            }
            fpn = fpn.Remove(fpn.Length - 1);
            mcslu.StartInfo.Arguments = fpn + " " + fn;

            if (dontRun)
            {
                mcslu.StartInfo.Arguments += " dontrun";
            }
            mcslu.Start();
        }
    }
}
