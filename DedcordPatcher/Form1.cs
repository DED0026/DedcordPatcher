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
            OpenFolder.Visible = false;
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
        private void StartCommandListener()
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
            StartCommandListener();
        }

        private void output(object sender, DataReceivedEventArgs e)
        {
            Logbox.Text += e.Data + "\n";
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            await Task.Run(() => StartCommandListener());
            updatechecks();
        }

        private void GitClone_Click(object sender, EventArgs e)
        {
            if (GitClone.Text != "Working..")
                if (ClientDownloaded)
                {
                    GitClone.Text = "Working..";
                    try { Folderwatcher.Dispose(); }
                    catch { }
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
                OpenFolder.Visible = ClientDownloaded;
                TabChangeChecks();
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

        string[] NameList;
        string[] DownloadList;
        string[] FormatList;
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
            NameList = RawPluginList[0].Split('µ');
            DownloadList = RawPluginList[1].Split('µ');
            FormatList = RawPluginList[2].Split('µ');

            PluginList.Items.Clear();
            respond = false;
            foreach (string plugin in NameList)
            {
                PluginList.Items.Add(plugin);
                string download = DownloadList[PluginList.Items.Count - 1];
                string PluginName = Functions.GetLastDirectoryName(download.Replace('/', Path.DirectorySeparatorChar));
                //GithubPluginToggling
                if (Directory.Exists(ClientFolder + CustomPluginsPath.Text + "\\" + PluginName))
                    PluginList.SetItemChecked(PluginList.Items.Count - 1, true);
                //ScriptToggling
                else if (File.Exists(ClientFolder + CustomPluginsPath.Text + "\\" + PluginName))
                    PluginList.SetItemChecked(PluginList.Items.Count - 1, true);

            }
            respond = true;
        }





        private void PluginList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!respond)
                return;

            bool InstallMode = e.NewValue == CheckState.Checked;
            int PluginIndex = PluginList.SelectedIndex;

            switch (FormatList[PluginIndex].ToLower())
            {
                case "github":
                    GithubPlugininstall(InstallMode, DownloadList[PluginIndex]);
                    break;
                case "script":
                    ScriptInstall(InstallMode, DownloadList[PluginIndex]);
                    break;
                default:
                    MessageBox.Show("Format Not Found.");
                    break;
            }
        }

        void ScriptInstall(bool InstallOrUninstall, string Link)
        {
            string FileName = Functions.GetLastDirectoryName(Link.Replace('/', Path.DirectorySeparatorChar));
            string FileLocation = ClientFolder + CustomPluginsPath.Text + "\\" + FileName;

            if (InstallOrUninstall)
                Wc.DownloadFile(Link, FileLocation);
            else
                File.Delete(FileLocation);
        }

        void GithubPlugininstall(bool InstallOrUninstall, string Link)
        {
            if (InstallOrUninstall)
            {
                cmd.WriteLine("cd " + ClientFolder + CustomPluginsPath.Text);
                cmd.WriteLine("git clone " + Link);
            }
            else
            {
                string FolderName = Functions.GetLastDirectoryName(Link.Replace('/', Path.DirectorySeparatorChar));
                cmd.WriteLine("cd " + ClientFolder + CustomPluginsPath.Text);
                cmd.WriteLine("rd /s /q \"" + ClientFolder + CustomPluginsPath.Text + "\\" + FolderName + "\"");
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
                NotifyFilter = NotifyFilters.CreationTime
                                 | NotifyFilters.Attributes
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.Security
                                 //| NotifyFilters.Size
                                 ,
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
            if(InstalledPluginList.Items.Count == 1)
                InstalledPluginList.Items.Add(@"\\\\\ This directory is empty /////");
        }


        private void AppTabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatechecks();
            TabChangeChecks();
        }

        void TabChangeChecks()
        {
            InstalledPluginList.Items.Clear();
            if (!ClientDownloaded)
                PluginList.Items.Clear();
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
                    else
                    {
                        InstalledPluginList.Items.Add("Client installed but plugins folder doesnt exist, please refetch.");
                        Clickable = false;
                    }
                }
                else
                {
                    InstalledPluginList.Items.Add("Client not installed.");
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
            if (InstalledPluginList.SelectedIndex == -1 || !Clickable || (string)InstalledPluginList.SelectedItem == @"\\\\\ This directory is empty /////")
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

        private void OpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start("explorer", ClientFolder);
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