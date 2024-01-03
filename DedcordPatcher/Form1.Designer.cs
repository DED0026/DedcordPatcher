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
            this.DMTab = new System.Windows.Forms.TabPage();
            this.DVTab = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AppTabs = new System.Windows.Forms.TabControl();
            this.VCInstall = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Logtab = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.DVTab.SuspendLayout();
            this.AppTabs.SuspendLayout();
            this.VCInstall.SuspendLayout();
            this.Logtab.SuspendLayout();
            this.SuspendLayout();
            // 
            // DMTab
            // 
            this.DMTab.Location = new System.Drawing.Point(4, 25);
            this.DMTab.Name = "DMTab";
            this.DMTab.Padding = new System.Windows.Forms.Padding(3);
            this.DMTab.Size = new System.Drawing.Size(792, 421);
            this.DMTab.TabIndex = 1;
            this.DMTab.Text = "Download plugins";
            this.DMTab.UseVisualStyleBackColor = true;
            // 
            // DVTab
            // 
            this.DVTab.Controls.Add(this.button1);
            this.DVTab.Controls.Add(this.label1);
            this.DVTab.Controls.Add(this.textBox1);
            this.DVTab.Location = new System.Drawing.Point(4, 25);
            this.DVTab.Name = "DVTab";
            this.DVTab.Padding = new System.Windows.Forms.Padding(3);
            this.DVTab.Size = new System.Drawing.Size(792, 421);
            this.DVTab.TabIndex = 0;
            this.DVTab.Text = "Download Vencord";
            this.DVTab.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(247, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "https://github.com/Vendicated/Vencord";
            // 
            // AppTabs
            // 
            this.AppTabs.Controls.Add(this.DVTab);
            this.AppTabs.Controls.Add(this.DMTab);
            this.AppTabs.Controls.Add(this.VCInstall);
            this.AppTabs.Controls.Add(this.Logtab);
            this.AppTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AppTabs.Location = new System.Drawing.Point(0, 0);
            this.AppTabs.Name = "AppTabs";
            this.AppTabs.SelectedIndex = 0;
            this.AppTabs.Size = new System.Drawing.Size(800, 450);
            this.AppTabs.TabIndex = 1;
            // 
            // VCInstall
            // 
            this.VCInstall.Controls.Add(this.button4);
            this.VCInstall.Controls.Add(this.button3);
            this.VCInstall.Controls.Add(this.button2);
            this.VCInstall.Location = new System.Drawing.Point(4, 25);
            this.VCInstall.Name = "VCInstall";
            this.VCInstall.Size = new System.Drawing.Size(792, 421);
            this.VCInstall.TabIndex = 2;
            this.VCInstall.Text = "Install and Rebuild Vencord";
            this.VCInstall.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Client: found";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Git clone";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(122, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(212, 253);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "button2";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(95, 296);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(174, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Launch Vencord installer";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // Logtab
            // 
            this.Logtab.Controls.Add(this.richTextBox1);
            this.Logtab.Location = new System.Drawing.Point(4, 25);
            this.Logtab.Name = "Logtab";
            this.Logtab.Padding = new System.Windows.Forms.Padding(3);
            this.Logtab.Size = new System.Drawing.Size(792, 421);
            this.Logtab.TabIndex = 3;
            this.Logtab.Text = "Log";
            this.Logtab.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(127, 66);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(100, 96);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AppTabs);
            this.Name = "Form1";
            this.Text = "Form1";
            this.DVTab.ResumeLayout(false);
            this.DVTab.PerformLayout();
            this.AppTabs.ResumeLayout(false);
            this.VCInstall.ResumeLayout(false);
            this.Logtab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage DMTab;
        private System.Windows.Forms.TabPage DVTab;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl AppTabs;
        private System.Windows.Forms.TabPage VCInstall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage Logtab;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

