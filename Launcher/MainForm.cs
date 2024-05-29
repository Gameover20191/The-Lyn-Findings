// Decompiled with JetBrains decompiler
// Type: Launcher.MainForm
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6AA362FF-B506-4D02-B128-5EAE460AD817
// Assembly location: C:\Program Files (x86)\Ubisoft\Rabbids Go Home - DVD\Launcher.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace Launcher
{
    public class MainForm : Form
    {
        private IContainer components;
        private PictureBox splashContainer;
        private Button playBtn;
        private Button settingsBtn;
        private Button exitBtn;
        private int versionIndex;
        private Form settingsForm;
        private static string[] splashFormats = new string[1]
        {
      "bmp"
        };

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainForm));
            this.splashContainer = new PictureBox();
            this.playBtn = new Button();
            this.settingsBtn = new Button();
            this.exitBtn = new Button();
            ((ISupportInitialize)this.splashContainer).BeginInit();
            this.SuspendLayout();
            this.splashContainer.AccessibleDescription = (string)null;
            this.splashContainer.AccessibleName = (string)null;
            componentResourceManager.ApplyResources((object)this.splashContainer, "splashContainer");
            this.splashContainer.BackgroundImage = (Image)null;
            this.splashContainer.BorderStyle = BorderStyle.Fixed3D;
            this.splashContainer.Font = (Font)null;
            this.splashContainer.ImageLocation = (string)null;
            this.splashContainer.Name = "splashContainer";
            this.splashContainer.TabStop = false;
            this.playBtn.AccessibleDescription = (string)null;
            this.playBtn.AccessibleName = (string)null;
            componentResourceManager.ApplyResources((object)this.playBtn, "playBtn");
            this.playBtn.BackgroundImage = (Image)null;
            this.playBtn.Font = (Font)null;
            this.playBtn.Name = "playBtn";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new EventHandler(this.playBtn_Click);
            this.settingsBtn.AccessibleDescription = (string)null;
            this.settingsBtn.AccessibleName = (string)null;
            componentResourceManager.ApplyResources((object)this.settingsBtn, "settingsBtn");
            this.settingsBtn.BackgroundImage = (Image)null;
            this.settingsBtn.Font = (Font)null;
            this.settingsBtn.Name = "settingsBtn";
            this.settingsBtn.UseVisualStyleBackColor = true;
            this.settingsBtn.Click += new EventHandler(this.settingsBtn_Click);
            this.exitBtn.AccessibleDescription = (string)null;
            this.exitBtn.AccessibleName = (string)null;
            componentResourceManager.ApplyResources((object)this.exitBtn, "exitBtn");
            this.exitBtn.BackgroundImage = (Image)null;
            this.exitBtn.DialogResult = DialogResult.Cancel;
            this.exitBtn.Font = (Font)null;
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.MouseClick += new MouseEventHandler(this.exitBtn_MouseClick);
            this.AcceptButton = (IButtonControl)this.playBtn;
            this.AccessibleDescription = (string)null;
            this.AccessibleName = (string)null;
            componentResourceManager.ApplyResources((object)this, "$this");
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImage = (Image)null;
            this.CancelButton = (IButtonControl)this.exitBtn;
            this.Controls.Add((Control)this.exitBtn);
            this.Controls.Add((Control)this.settingsBtn);
            this.Controls.Add((Control)this.playBtn);
            this.Controls.Add((Control)this.splashContainer);
            this.DoubleBuffered = true;
            this.Font = (Font)null;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = nameof(MainForm);
            ((ISupportInitialize)this.splashContainer).EndInit();
            this.ResumeLayout(false);
        }

        public MainForm(int versionIndex)
        {
            this.InitializeComponent();
            if (versionIndex == 5)
            {
                this.Text += " - DVD";
            }
            else
            {
                MainForm mainForm = this;
                mainForm.Text = mainForm.Text + " - Chapter " + versionIndex.ToString();
            }
            this.versionIndex = versionIndex;
            List<string> splashFiles = this.GetSplashFiles();
            Image image = (Image)null;
            Image splash;
            if (splashFiles.Count != 0)
            {
                int index = new Random().Next(0, splashFiles.Count - 1);
                splash = Image.FromFile(splashFiles[index]);
            }
            else
                splash = this.GetEmbededSplash();
            this.SuspendLayout();
            if (!this.SetupFromSplash(splash))
                this.SetupFromSplash(image = this.GetEmbededSplash());
            this.ResumeLayout();
        }

        public Size GetMinSplashSize()
        {
            int num1 = Math.Max(this.playBtn.Width, Math.Max(this.settingsBtn.Width, this.exitBtn.Width));
            int num2 = num1 / 4 * 5;
            return new Size(num1 * 3 + num2, 1);
        }

        public bool IsValidSplash(Image splash)
        {
            Size minSplashSize = this.GetMinSplashSize();
            return splash != null && splash.Width > minSplashSize.Width && splash.Height > minSplashSize.Height;
        }

        public bool SetupFromSplash(Image splash)
        {
            if (!this.IsValidSplash(splash))
                return false;
            int num1 = Math.Max(this.playBtn.Height, Math.Max(this.settingsBtn.Height, this.exitBtn.Height));
            int num2 = this.Height - this.ClientSize.Height - 2 * ((this.Width - this.ClientSize.Width) / 2);
            this.Width = splash.Width;
            this.Height = splash.Height + num1 * 2 + num2;
            this.splashContainer.Image = splash;
            this.splashContainer.Width = splash.Width;
            this.splashContainer.Height = splash.Height;
            int y = this.splashContainer.Height + num1 / 2;
            this.playBtn.Location = new Point(this.playBtn.Location.X, y);
            int x = this.Width - this.exitBtn.Width - this.exitBtn.Width / 4;
            this.settingsBtn.Location = new Point(x - this.settingsBtn.Width - this.settingsBtn.Width / 4, y);
            this.exitBtn.Location = new Point(x, y);
            return true;
        }

        private Image GetEmbededSplash()
        {
            return Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("Launcher.Images.bunnies.png"));
        }

        public List<string> GetSplashFiles()
        {
            List<string> splashFiles = new List<string>();
            foreach (string splashFormat in MainForm.splashFormats)
            {
                string[] files;
                try
                {
                    files = Directory.GetFiles(Configuration.GetMediaPath(), "*." + splashFormat);
                }
                catch (DirectoryNotFoundException ex)
                {
                    continue;
                }
                foreach (string str in files)
                    splashFiles.Add(str);
            }
            return splashFiles;
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = DialogResult.None;
            do
            {
                if (!ApplicationLauncher.Launch(this.versionIndex))
                    dialogResult = MessageBox.Show((IWin32Window)null, "An error occurred while launching the game!", "Error...", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            while (dialogResult == DialogResult.Retry);
            this.Close();
        }

        private void exitBtn_MouseClick(object sender, MouseEventArgs e) => this.Close();

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            if (this.settingsForm != null)
                return;
            this.settingsForm = (Form)new Settings();
            this.settingsForm.Show((IWin32Window)this);
        }

        public Form SettingsForm
        {
            get => this.settingsForm;
            set => this.settingsForm = value;
        }
    }
}
