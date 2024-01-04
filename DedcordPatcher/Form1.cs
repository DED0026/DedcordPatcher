using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DedcordPatcher
{
    public partial class Form1 : Form
    {
        string ClientFolder;
        public Form1()
        {
            InitializeComponent();
            if (File.Exists("ClientRepoTempDedcord"))
            {
                RepoLink.Text = File.ReadAllText("ClientRepoTempDedcord");
            }
            updatechecks(false);
            Logbox.Text += "\nPlanned client folder: " + ClientFolder + "\n\n";
        }

        StreamWriter cmd;
        Process process = new Process();
        private void startprocess()
        {
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.FileName = "cmd";
            process.OutputDataReceived += output;
            process.ErrorDataReceived += output;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            process.BeginOutputReadLine();
            //process.BeginErrorReadLine();
            cmd = process.StandardInput;
            process.WaitForExit();
            process.OutputDataReceived -= output;
            process.ErrorDataReceived -= output;
            process.CancelErrorRead();
            process.CancelOutputRead();
            startprocess();
        }

        private void output(object sender, DataReceivedEventArgs e)
        {
            Logbox.Text += e.Data + "\n";
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await Task.Run(() => startprocess());
            updatechecks();
        }

        private void GitClone_Click(object sender, EventArgs e)
        {
            if (GitClone.Text != "Working..")
                if (GitClone.Text == "Delete")
                {
                    GitClone.Text = "Working..";
                    cmd.WriteLine("rd /s /q " + ClientFolder);
                    updatechecks();
                }
                else
                {
                    GitClone.Text = "Working..";
                    cmd.WriteLine("cd " + Directory.GetCurrentDirectory());
                    cmd.WriteLine("git clone " + RepoLink.Text);
                    updatechecks();
                }
        }

        private async void updatechecks(bool wait = true)
        {
            await Task.Run(() =>
            {
                if (wait)
                    Thread.Sleep(1000);
                ClientFolder = Directory.GetCurrentDirectory() + "\\" + Functions.GetLastDirectoryName(RepoLink.Text.Replace('/', Path.DirectorySeparatorChar));
                ClientDetector.Text = Directory.Exists(ClientFolder) ? "Client: Found" : "Client: Not found";
                GitClone.Text = ClientDetector.Text == "Client: Found" ? "Delete" : "Git clone";

            });
        }

        private void InstallPackages_Click(object sender, EventArgs e)
        {
            cmd.WriteLine("cd " + ClientFolder);
            cmd.WriteLine("pnpm install --frozen-lockfile");
        }

        private void RebuildClient_Click(object sender, EventArgs e)
        {
            cmd.WriteLine("cd " + ClientFolder);
            cmd.WriteLine("pnpm build");
        }

        private void LaunchInstaller_Click(object sender, EventArgs e)
        {
            ProcessStartInfo meow = new ProcessStartInfo();
            meow.WorkingDirectory = ClientFolder;
            meow.FileName = "pnpm";
            meow.Arguments = "inject";
            Process.Start(meow);
        }

        private void RepoLink_TextChanged(object sender, EventArgs e)
        {
            updatechecks();
            File.WriteAllText("ClientRepoTempDedcord", RepoLink.Text);
        }

        private void Logbox_TextChanged(object sender, EventArgs e)
        {
            Logbox.SelectionStart = Logbox.Text.Length;
            Logbox.ScrollToCaret();
        }

        private void PluginsFetch_Click(object sender, EventArgs e)
        {
            FetchPluh();
        }

        string[] namelist;
        string[] downloadlist;

        WebClient Wc = new WebClient();
        private void FetchPluh()
        {
            string RawPluginString = Wc.DownloadString(Pluginlistlink.Text).Replace("Âµ", "µ");
            string[] RawPluginList = RawPluginString.Split('\n');
            namelist = RawPluginList[0].Split('µ');
            downloadlist = RawPluginList[1].Split('µ');
            PluginList.Items.Clear();
            foreach (string plugin in namelist)
            {
                PluginList.Items.Add(plugin);
            }
        }
    }

    class Functions
    {
        public static string GetLastDirectoryName(string path)
        {
            string[] pathParts = path.TrimEnd(Path.DirectorySeparatorChar).Split(Path.DirectorySeparatorChar);
            if (pathParts.Length > 0)
                return pathParts[pathParts.Length - 1];
            return null;
        }

        public static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            if (!Directory.Exists(targetPath))
                Directory.CreateDirectory(targetPath);
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
        }
    }
}