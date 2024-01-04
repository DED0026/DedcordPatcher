namespace DedcordPatcher
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DMTab = new System.Windows.Forms.TabPage();
            this.PluginsFetch = new System.Windows.Forms.Button();
            this.Pluginlistlink = new System.Windows.Forms.TextBox();
            this.PluginList = new System.Windows.Forms.CheckedListBox();
            this.DVTab = new System.Windows.Forms.TabPage();
            this.LaunchInstaller = new System.Windows.Forms.Button();
            this.RebuildAndRestart = new System.Windows.Forms.Button();
            this.RebuildClient = new System.Windows.Forms.Button();
            this.InstallPackages = new System.Windows.Forms.Button();
            this.GitClone = new System.Windows.Forms.Button();
            this.ClientDetector = new System.Windows.Forms.Label();
            this.RepoLink = new System.Windows.Forms.TextBox();
            this.AppTabs = new System.Windows.Forms.TabControl();
            this.Logtab = new System.Windows.Forms.TabPage();
            this.Logbox = new System.Windows.Forms.RichTextBox();
            this.DMTab.SuspendLayout();
            this.DVTab.SuspendLayout();
            this.AppTabs.SuspendLayout();
            this.Logtab.SuspendLayout();
            this.SuspendLayout();
            // 
            // DMTab
            // 
            this.DMTab.Controls.Add(this.PluginsFetch);
            this.DMTab.Controls.Add(this.Pluginlistlink);
            this.DMTab.Controls.Add(this.PluginList);
            this.DMTab.Location = new System.Drawing.Point(4, 25);
            this.DMTab.Name = "DMTab";
            this.DMTab.Padding = new System.Windows.Forms.Padding(3);
            this.DMTab.Size = new System.Drawing.Size(792, 421);
            this.DMTab.TabIndex = 1;
            this.DMTab.Text = "Download plugins";
            this.DMTab.UseVisualStyleBackColor = true;
            // 
            // PluginsFetch
            // 
            this.PluginsFetch.Location = new System.Drawing.Point(701, 12);
            this.PluginsFetch.Name = "PluginsFetch";
            this.PluginsFetch.Size = new System.Drawing.Size(75, 23);
            this.PluginsFetch.TabIndex = 2;
            this.PluginsFetch.Text = "Fetch";
            this.PluginsFetch.UseVisualStyleBackColor = true;
            this.PluginsFetch.Click += new System.EventHandler(this.PluginsFetch_Click);
            // 
            // Pluginlistlink
            // 
            this.Pluginlistlink.Location = new System.Drawing.Point(8, 12);
            this.Pluginlistlink.Name = "Pluginlistlink";
            this.Pluginlistlink.Size = new System.Drawing.Size(686, 22);
            this.Pluginlistlink.TabIndex = 1;
            this.Pluginlistlink.Text = "https://raw.githubusercontent.com/DED0026/DedcordPatcher/master/PluginIndex";
            // 
            // PluginList
            // 
            this.PluginList.FormattingEnabled = true;
            this.PluginList.Location = new System.Drawing.Point(8, 40);
            this.PluginList.Name = "PluginList";
            this.PluginList.Size = new System.Drawing.Size(384, 361);
            this.PluginList.TabIndex = 0;
            // 
            // DVTab
            // 
            this.DVTab.Controls.Add(this.LaunchInstaller);
            this.DVTab.Controls.Add(this.RebuildAndRestart);
            this.DVTab.Controls.Add(this.RebuildClient);
            this.DVTab.Controls.Add(this.InstallPackages);
            this.DVTab.Controls.Add(this.GitClone);
            this.DVTab.Controls.Add(this.ClientDetector);
            this.DVTab.Controls.Add(this.RepoLink);
            this.DVTab.Location = new System.Drawing.Point(4, 25);
            this.DVTab.Name = "DVTab";
            this.DVTab.Padding = new System.Windows.Forms.Padding(3);
            this.DVTab.Size = new System.Drawing.Size(792, 421);
            this.DVTab.TabIndex = 0;
            this.DVTab.Text = "Client manager";
            this.DVTab.UseVisualStyleBackColor = true;
            // 
            // LaunchInstaller
            // 
            this.LaunchInstaller.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LaunchInstaller.Location = new System.Drawing.Point(305, 251);
            this.LaunchInstaller.Name = "LaunchInstaller";
            this.LaunchInstaller.Size = new System.Drawing.Size(174, 23);
            this.LaunchInstaller.TabIndex = 3;
            this.LaunchInstaller.Text = "Launch installer";
            this.LaunchInstaller.UseVisualStyleBackColor = true;
            this.LaunchInstaller.Click += new System.EventHandler(this.LaunchInstaller_Click);
            // 
            // RebuildAndRestart
            // 
            this.RebuildAndRestart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RebuildAndRestart.Location = new System.Drawing.Point(305, 222);
            this.RebuildAndRestart.Name = "RebuildAndRestart";
            this.RebuildAndRestart.Size = new System.Drawing.Size(174, 23);
            this.RebuildAndRestart.TabIndex = 4;
            this.RebuildAndRestart.Text = "Rebuild and Restart";
            this.RebuildAndRestart.UseVisualStyleBackColor = true;
            // 
            // RebuildClient
            // 
            this.RebuildClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RebuildClient.Location = new System.Drawing.Point(305, 193);
            this.RebuildClient.Name = "RebuildClient";
            this.RebuildClient.Size = new System.Drawing.Size(174, 23);
            this.RebuildClient.TabIndex = 5;
            this.RebuildClient.Text = "Rebuild";
            this.RebuildClient.UseVisualStyleBackColor = true;
            this.RebuildClient.Click += new System.EventHandler(this.RebuildClient_Click);
            // 
            // InstallPackages
            // 
            this.InstallPackages.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InstallPackages.Location = new System.Drawing.Point(305, 164);
            this.InstallPackages.Name = "InstallPackages";
            this.InstallPackages.Size = new System.Drawing.Size(174, 23);
            this.InstallPackages.TabIndex = 6;
            this.InstallPackages.Text = "Install packages";
            this.InstallPackages.UseVisualStyleBackColor = true;
            this.InstallPackages.Click += new System.EventHandler(this.InstallPackages_Click);
            // 
            // GitClone
            // 
            this.GitClone.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.GitClone.Location = new System.Drawing.Point(464, 99);
            this.GitClone.Name = "GitClone";
            this.GitClone.Size = new System.Drawing.Size(75, 23);
            this.GitClone.TabIndex = 2;
            this.GitClone.Text = "Git clone";
            this.GitClone.UseVisualStyleBackColor = true;
            this.GitClone.Click += new System.EventHandler(this.GitClone_Click);
            // 
            // ClientDetector
            // 
            this.ClientDetector.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ClientDetector.AutoSize = true;
            this.ClientDetector.Location = new System.Drawing.Point(545, 103);
            this.ClientDetector.Name = "ClientDetector";
            this.ClientDetector.Size = new System.Drawing.Size(43, 16);
            this.ClientDetector.TabIndex = 1;
            this.ClientDetector.Text = "Client:";
            // 
            // RepoLink
            // 
            this.RepoLink.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RepoLink.Location = new System.Drawing.Point(211, 100);
            this.RepoLink.Name = "RepoLink";
            this.RepoLink.Size = new System.Drawing.Size(247, 22);
            this.RepoLink.TabIndex = 0;
            this.RepoLink.Text = "https://github.com/Vendicated/Vencord";
            this.RepoLink.TextChanged += new System.EventHandler(this.RepoLink_TextChanged);
            // 
            // AppTabs
            // 
            this.AppTabs.Controls.Add(this.DVTab);
            this.AppTabs.Controls.Add(this.DMTab);
            this.AppTabs.Controls.Add(this.Logtab);
            this.AppTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppTabs.Location = new System.Drawing.Point(0, 0);
            this.AppTabs.Name = "AppTabs";
            this.AppTabs.SelectedIndex = 0;
            this.AppTabs.Size = new System.Drawing.Size(800, 450);
            this.AppTabs.TabIndex = 1;
            // 
            // Logtab
            // 
            this.Logtab.Controls.Add(this.Logbox);
            this.Logtab.Location = new System.Drawing.Point(4, 25);
            this.Logtab.Name = "Logtab";
            this.Logtab.Padding = new System.Windows.Forms.Padding(3);
            this.Logtab.Size = new System.Drawing.Size(792, 421);
            this.Logtab.TabIndex = 3;
            this.Logtab.Text = "Log";
            this.Logtab.UseVisualStyleBackColor = true;
            // 
            // Logbox
            // 
            this.Logbox.BackColor = System.Drawing.Color.Black;
            this.Logbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Logbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Logbox.ForeColor = System.Drawing.Color.Lime;
            this.Logbox.Location = new System.Drawing.Point(3, 3);
            this.Logbox.Name = "Logbox";
            this.Logbox.Size = new System.Drawing.Size(786, 415);
            this.Logbox.TabIndex = 0;
            this.Logbox.Text = resources.GetString("Logbox.Text");
            this.Logbox.TextChanged += new System.EventHandler(this.Logbox_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AppTabs);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DMTab.ResumeLayout(false);
            this.DMTab.PerformLayout();
            this.DVTab.ResumeLayout(false);
            this.DVTab.PerformLayout();
            this.AppTabs.ResumeLayout(false);
            this.Logtab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage DMTab;
        private System.Windows.Forms.TabPage DVTab;
        private System.Windows.Forms.TextBox RepoLink;
        private System.Windows.Forms.TabControl AppTabs;
        private System.Windows.Forms.Label ClientDetector;
        private System.Windows.Forms.Button GitClone;
        private System.Windows.Forms.TabPage Logtab;
        private System.Windows.Forms.RichTextBox Logbox;
        private System.Windows.Forms.Button LaunchInstaller;
        private System.Windows.Forms.Button RebuildAndRestart;
        private System.Windows.Forms.Button RebuildClient;
        private System.Windows.Forms.Button InstallPackages;
        private System.Windows.Forms.CheckedListBox PluginList;
        private System.Windows.Forms.Button PluginsFetch;
        private System.Windows.Forms.TextBox Pluginlistlink;
    }
}

