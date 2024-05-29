// Decompiled with JetBrains decompiler
// Type: Launcher.Settings
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6AA362FF-B506-4D02-B128-5EAE460AD817
// Assembly location: C:\Program Files (x86)\Ubisoft\Rabbids Go Home - DVD\Launcher.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace Launcher
{
  public class Settings : Form
  {
    private IContainer components;
    private Button cancelBtn;
    private Button okBtn;
    private ComboBox langCombo;
    private ComboBox rezCombo;
    private CheckBox vSyncCheck;
    private CheckBox windowedCheck;
    private PictureBox rabbidPicture;
    private Button joyCalibrate;

    public Settings()
    {
      this.InitializeComponent();
      this.SuspendLayout();
      this.rabbidPicture.Image = this.GetEmbededRabbid();
      this.langCombo.Items.Clear();
      foreach (object name in Enum.GetNames(typeof (Configuration.Lang)))
        this.langCombo.Items.Add(name);
      this.rezCombo.Items.Clear();
      for (int index = 0; index < DisplayInformation.DesiredModes.Length; ++index)
      {
        string desiredMode = DisplayInformation.DesiredModes[index];
        if (Configuration.Global.DisplayInfo.IsModeSupported(desiredMode))
          this.rezCombo.Items.Add((object) desiredMode);
      }
      this.joyCalibrate.Visible = false;
      this.ResumeLayout();
    }

    protected override void OnShown(EventArgs e)
    {
      if (this.Owner is MainForm owner)
        owner.Enabled = false;
      this.langCombo.SelectedIndex = (int) Configuration.Global.Settings.Language;
      this.rezCombo.SelectedItem = (object) Configuration.Global.Settings.VideoMode;
      this.vSyncCheck.Checked = Configuration.Global.Settings.VSync;
      this.windowedCheck.Checked = Configuration.Global.Settings.Windowed;
      base.OnShown(e);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
      if (this.Owner is MainForm owner)
      {
        owner.Enabled = true;
        owner.SettingsForm = (Form) null;
        owner.Activate();
      }
      base.OnClosing(e);
    }

    private void okBtn_Click(object sender, EventArgs e)
    {
      Configuration.Global.Settings.VideoMode = (string) this.rezCombo.SelectedItem;
      Configuration.Global.Settings.VSync = this.vSyncCheck.Checked;
      Configuration.Global.Settings.Windowed = this.windowedCheck.Checked;
      if (Configuration.Global.Settings.Language != (Configuration.Lang) this.langCombo.SelectedIndex)
      {
        Configuration.Global.Settings.Language = (Configuration.Lang) this.langCombo.SelectedIndex;
        LocalizationData.ResetAppCulture = true;
        if (this.Owner is MainForm owner)
          owner.Close();
      }
      this.Close();
    }

    private void cancelBtn_Click(object sender, EventArgs e) => this.Close();

    private Image GetEmbededRabbid()
    {
      return Image.FromStream(Assembly.GetExecutingAssembly().GetManifestResourceStream("Launcher.Images.rabbid.png"));
    }

    private void joyCalibrate_Click(object sender, EventArgs e) => new JoystickCalibration().Show();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Settings));
      this.windowedCheck = new CheckBox();
      this.vSyncCheck = new CheckBox();
      this.rezCombo = new ComboBox();
      this.langCombo = new ComboBox();
      this.cancelBtn = new Button();
      this.okBtn = new Button();
      this.rabbidPicture = new PictureBox();
      this.joyCalibrate = new Button();
      GroupBox groupBox1 = new GroupBox();
      Label label = new Label();
      GroupBox groupBox2 = new GroupBox();
      groupBox1.SuspendLayout();
      groupBox2.SuspendLayout();
      ((ISupportInitialize) this.rabbidPicture).BeginInit();
      this.SuspendLayout();
      groupBox1.AccessibleDescription = (string) null;
      groupBox1.AccessibleName = (string) null;
      componentResourceManager.ApplyResources((object) groupBox1, "displayGroup");
      groupBox1.BackgroundImage = (Image) null;
      groupBox1.Controls.Add((Control) this.windowedCheck);
      groupBox1.Controls.Add((Control) this.vSyncCheck);
      groupBox1.Controls.Add((Control) label);
      groupBox1.Controls.Add((Control) this.rezCombo);
      groupBox1.Font = (Font) null;
      groupBox1.Name = "displayGroup";
      groupBox1.TabStop = false;
      this.windowedCheck.AccessibleDescription = (string) null;
      this.windowedCheck.AccessibleName = (string) null;
      componentResourceManager.ApplyResources((object) this.windowedCheck, "windowedCheck");
      this.windowedCheck.BackgroundImage = (Image) null;
      this.windowedCheck.Font = (Font) null;
      this.windowedCheck.Name = "windowedCheck";
      this.windowedCheck.UseVisualStyleBackColor = true;
      this.vSyncCheck.AccessibleDescription = (string) null;
      this.vSyncCheck.AccessibleName = (string) null;
      componentResourceManager.ApplyResources((object) this.vSyncCheck, "vSyncCheck");
      this.vSyncCheck.BackgroundImage = (Image) null;
      this.vSyncCheck.Font = (Font) null;
      this.vSyncCheck.Name = "vSyncCheck";
      this.vSyncCheck.UseVisualStyleBackColor = true;
      label.AccessibleDescription = (string) null;
      label.AccessibleName = (string) null;
      componentResourceManager.ApplyResources((object) label, "rezLabel");
      label.Font = (Font) null;
      label.Name = "rezLabel";
      this.rezCombo.AccessibleDescription = (string) null;
      this.rezCombo.AccessibleName = (string) null;
      componentResourceManager.ApplyResources((object) this.rezCombo, "rezCombo");
      this.rezCombo.BackgroundImage = (Image) null;
      this.rezCombo.DropDownStyle = ComboBoxStyle.DropDownList;
      this.rezCombo.Font = (Font) null;
      this.rezCombo.Name = "rezCombo";
      groupBox2.AccessibleDescription = (string) null;
      groupBox2.AccessibleName = (string) null;
      componentResourceManager.ApplyResources((object) groupBox2, "langGroup");
      groupBox2.BackgroundImage = (Image) null;
      groupBox2.Controls.Add((Control) this.langCombo);
      groupBox2.Font = (Font) null;
      groupBox2.Name = "langGroup";
      groupBox2.TabStop = false;
      this.langCombo.AccessibleDescription = (string) null;
      this.langCombo.AccessibleName = (string) null;
      componentResourceManager.ApplyResources((object) this.langCombo, "langCombo");
      this.langCombo.BackgroundImage = (Image) null;
      this.langCombo.DropDownStyle = ComboBoxStyle.DropDownList;
      this.langCombo.Font = (Font) null;
      this.langCombo.Name = "langCombo";
      this.cancelBtn.AccessibleDescription = (string) null;
      this.cancelBtn.AccessibleName = (string) null;
      componentResourceManager.ApplyResources((object) this.cancelBtn, "cancelBtn");
      this.cancelBtn.BackgroundImage = (Image) null;
      this.cancelBtn.DialogResult = DialogResult.Cancel;
      this.cancelBtn.Font = (Font) null;
      this.cancelBtn.Name = "cancelBtn";
      this.cancelBtn.UseVisualStyleBackColor = true;
      this.cancelBtn.Click += new EventHandler(this.cancelBtn_Click);
      this.okBtn.AccessibleDescription = (string) null;
      this.okBtn.AccessibleName = (string) null;
      componentResourceManager.ApplyResources((object) this.okBtn, "okBtn");
      this.okBtn.BackgroundImage = (Image) null;
      this.okBtn.Font = (Font) null;
      this.okBtn.Name = "okBtn";
      this.okBtn.UseVisualStyleBackColor = true;
      this.okBtn.Click += new EventHandler(this.okBtn_Click);
      this.rabbidPicture.AccessibleDescription = (string) null;
      this.rabbidPicture.AccessibleName = (string) null;
      componentResourceManager.ApplyResources((object) this.rabbidPicture, "rabbidPicture");
      this.rabbidPicture.BackgroundImage = (Image) null;
      this.rabbidPicture.BorderStyle = BorderStyle.Fixed3D;
      this.rabbidPicture.Font = (Font) null;
      this.rabbidPicture.ImageLocation = (string) null;
      this.rabbidPicture.Name = "rabbidPicture";
      this.rabbidPicture.TabStop = false;
      this.joyCalibrate.AccessibleDescription = (string) null;
      this.joyCalibrate.AccessibleName = (string) null;
      componentResourceManager.ApplyResources((object) this.joyCalibrate, "joyCalibrate");
      this.joyCalibrate.BackgroundImage = (Image) null;
      this.joyCalibrate.Font = (Font) null;
      this.joyCalibrate.Name = "joyCalibrate";
      this.joyCalibrate.UseVisualStyleBackColor = true;
      this.joyCalibrate.Click += new EventHandler(this.joyCalibrate_Click);
      this.AcceptButton = (IButtonControl) this.okBtn;
      this.AccessibleDescription = (string) null;
      this.AccessibleName = (string) null;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) null;
      this.CancelButton = (IButtonControl) this.cancelBtn;
      this.Controls.Add((Control) this.joyCalibrate);
      this.Controls.Add((Control) this.rabbidPicture);
      this.Controls.Add((Control) this.okBtn);
      this.Controls.Add((Control) this.cancelBtn);
      this.Controls.Add((Control) groupBox2);
      this.Controls.Add((Control) groupBox1);
      this.Font = (Font) null;
      this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
      this.Icon = (Icon) null;
      this.Name = nameof (Settings);
      this.ShowInTaskbar = false;
      groupBox1.ResumeLayout(false);
      groupBox1.PerformLayout();
      groupBox2.ResumeLayout(false);
      ((ISupportInitialize) this.rabbidPicture).EndInit();
      this.ResumeLayout(false);
    }
  }
}
