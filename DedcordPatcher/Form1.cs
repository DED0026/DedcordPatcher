using System;
using System.Diagnostics;
using System.IO;
using System.Net;
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
            boykisser();
            if (File.Exists("ClientRepoTempDedcord"))
            {
                RepoLink.Text = File.ReadAllText("ClientRepoTempDedcord");
            }
            updatechecks(false);
            Logbox.Text += "\nPlanned client folder: " + ClientFolder + "\n\n";
        }

        bool ClientDownloaded;

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
            process.BeginErrorReadLine();
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
                    cmd.WriteLine("rd /s /q \"" + ClientFolder + "\"");
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
                ClientDownloaded = Directory.Exists(ClientFolder);
                ClientDetector.Text = ClientDownloaded ? "Client: Found" : "Client: Not found";
                GitClone.Text = ClientDownloaded ? "Delete" : "Git clone";

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
            updatechecks(false);
            FetchPluh();
        }

        string[] namelist;
        string[] downloadlist;
        bool respond;
        WebClient Wc = new WebClient();
        private void FetchPluh()
        {
            if (!ClientDownloaded)
            {
                MessageBox.Show("Client not installed.");
                return;
            }

            if (!Directory.Exists(ClientFolder + CustomPluginsPath.Text))
                Directory.CreateDirectory(ClientFolder + CustomPluginsPath.Text);

            string RawPluginString = Wc.DownloadString(Pluginlistlink.Text).Replace("Âµ", "µ");
            string[] RawPluginList = RawPluginString.Split('\n');
            namelist = RawPluginList[0].Split('µ');
            downloadlist = RawPluginList[1].Split('µ');

            PluginList.Items.Clear();
            respond = false;
            foreach (string plugin in namelist)
            {
                PluginList.Items.Add(plugin);
                string download = downloadlist[PluginList.Items.Count - 1];
                string foldername = Functions.GetLastDirectoryName(download.Replace('/', Path.DirectorySeparatorChar));

                if (Directory.Exists(ClientFolder + CustomPluginsPath.Text + "\\" + foldername))
                    PluginList.SetItemChecked(PluginList.Items.Count - 1, true);
            }
            respond = true;
        }

        private void PluginList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!respond)
            {
                return;
            }

            string download = downloadlist[PluginList.SelectedIndex];
            string foldername = Functions.GetLastDirectoryName(download.Replace('/', Path.DirectorySeparatorChar));
            if (e.NewValue == CheckState.Checked)
            {
                cmd.WriteLine("cd " + ClientFolder + CustomPluginsPath.Text);
                cmd.WriteLine("git clone " + download);
            }
            else
            {
                cmd.WriteLine("cd " + ClientFolder + CustomPluginsPath.Text);
                cmd.WriteLine("rd /s /q \"" + ClientFolder + CustomPluginsPath.Text + "\\" + foldername + "\"");
            }
        }

        private void RebuildAndRestart_Click(object sender, EventArgs e)
        {
            RebuildClient.PerformClick();
            if (Discord.Checked)
                Functions.KillProcess("Discord");
            if (DiscordPTB.Checked)
                Functions.KillProcess("DiscordPTB");
            if (DiscordCanary.Checked)
                Functions.KillProcess("DiscordCanary");
        }

        public bool boykisser()
        {
            return true;
        }


        private void Watcher_Error(object sender, ErrorEventArgs e) => reload();

        private void Watcher_event(object sender, FileSystemEventArgs e) => reload();

        string LookPath;

        FileSystemWatcher Folderwatcher;
        public void reload()
        {
            if (!Directory.Exists(LookPath))
            {
                LookPath = Path.GetDirectoryName(LookPath);
                reload();
                return;
            }

            LookPath = Path.GetFullPath(LookPath);

            try { Folderwatcher.Dispose(); }
            catch { }

            Folderwatcher = new FileSystemWatcher(LookPath, "*.*")
            {
                NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size,
                EnableRaisingEvents = true
            };

            Folderwatcher.Created += Watcher_event;
            Folderwatcher.Deleted += Watcher_event;
            Folderwatcher.Renamed += Watcher_event;
            Folderwatcher.Changed += Watcher_event;
            Folderwatcher.Error += Watcher_Error;

            InstalledPluginList.Items.Clear();
            InstalledPluginList.Items.Add("..");
            foreach (string file in Directory.GetFiles(LookPath))
                InstalledPluginList.Items.Add(file.Remove(0, LookPath.Length).Trim('\\'));
            foreach (string directory in Directory.GetDirectories(LookPath))
                InstalledPluginList.Items.Add(directory.Remove(0, LookPath.Length).Trim('\\'));
        }


        private void AppTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AppTabs.SelectedIndex == 1)
            {
                if (ClientDownloaded)
                {
                    if (Directory.Exists(ClientFolder + CustomPluginsPath.Text))
                    {
                        LookPath = ClientFolder + CustomPluginsPath.Text;
                        reload();
                        Clickable = true;
                    }
                }
                else
                {
                    InstalledPluginList.Items.Add("Not installed.");
                    Clickable = false;
                }
            }
        }

        int LastIndex;
        private void InstalledPluginList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LastIndex = InstalledPluginList.SelectedIndex;
        }

        bool Clickable;
        private void InstalledPluginList_DoubleClick(object sender, EventArgs e)
        {
            if (InstalledPluginList.SelectedIndex == -1 || !Clickable)
                return;

            if (InstalledPluginList.SelectedIndex == LastIndex)
            {
                string selection = LookPath + "\\" + InstalledPluginList.SelectedItem.ToString();
                if (Directory.Exists(selection))
                {
                    LookPath = selection;
                    reload();
                }
                else
                {
                    ProcessStartInfo Launchedprocess = new ProcessStartInfo();
                    Launchedprocess.WorkingDirectory = Path.GetDirectoryName(selection);
                    Launchedprocess.FileName = selection;
                    Process.Start(Launchedprocess);
                }
            }
        }
    }

    class Functions
    {
        public static void KillProcess(string processName)
        {
            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                process.Kill();
            }
        }


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