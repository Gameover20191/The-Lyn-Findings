// Decompiled with JetBrains decompiler
// Type: Launcher.JoystickCalibration
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6AA362FF-B506-4D02-B128-5EAE460AD817
// Assembly location: C:\Program Files (x86)\Ubisoft\Rabbids Go Home - DVD\Launcher.exe

using Launcher.Controlls;
using Launcher.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace Launcher
{
  public class JoystickCalibration : Form
  {
    private CustomPictureBox[] btnControlls;
    private int[] btnIndex;
    private Joypad pad;
    private bool buttonIsClicked;
    private IContainer components;
    private PictureBox xboxController;
    private CustomPictureBox customPictureBox2;
    private CustomPictureBox customPictureBox3;
    private CustomPictureBox ButtonX;
    private CustomPictureBox ButtonA;
    private CustomPictureBox ButtonB;
    private CustomPictureBox customPictureBox7;
    private CustomPictureBox customPictureBox8;
    private CustomPictureBox customPictureBox9;
    private CustomPictureBox customPictureBox11;
    private CustomPictureBox customPictureBox12;
    private CustomPictureBox customPictureBox13;
    private CustomPictureBox customPictureBox14;
    private CustomPictureBox ButtonY;
    private CustomPictureBox customPictureBox10;
    private Label labelPushBtn;

    public JoystickCalibration()
    {
      this.InitializeComponent();
      this.btnControlls = new CustomPictureBox[4];
      this.btnControlls[0] = this.ButtonA;
      this.btnControlls[1] = this.ButtonB;
      this.btnControlls[2] = this.ButtonX;
      this.btnControlls[3] = this.ButtonY;
      this.btnIndex = new int[4];
      for (int index = 0; index < 4; ++index)
        this.btnIndex[index] = -1;
      foreach (CustomPictureBox btnControll in this.btnControlls)
      {
        btnControll.Click += new EventHandler(this.Button_Click);
        btnControll.MouseEnter += new EventHandler(this.ButtonEnter);
        btnControll.MouseLeave += new EventHandler(this.ButtonLeave);
      }
      this.pad = new Joypad();
      this.buttonIsClicked = false;
    }

    public int WaitButtonAssigned()
    {
      this.pad.Update();
      int joypadButtonDown;
      while ((joypadButtonDown = this.pad.GetJoypadButtonDown()) == -1)
      {
        this.pad.Update();
        Application.DoEvents();
      }
      return joypadButtonDown;
    }

    private void ButtonEnter(object sender, EventArgs e)
    {
      if (this.buttonIsClicked)
        return;
      this.Cursor = Cursors.Cross;
    }

    private void ButtonLeave(object sender, EventArgs e) => this.Cursor = Cursors.Arrow;

    private void Button_Click(object sender, EventArgs e)
    {
      if (this.buttonIsClicked)
        return;
      this.labelPushBtn.Visible = true;
      this.Cursor = Cursors.Arrow;
      for (int index = 0; index < this.btnControlls.Length; ++index)
      {
        CustomPictureBox btnControll = this.btnControlls[index];
      }
      this.buttonIsClicked = true;
      this.buttonIsClicked = false;
      this.labelPushBtn.Visible = false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.xboxController = new PictureBox();
      this.labelPushBtn = new Label();
      this.ButtonY = new CustomPictureBox();
      this.customPictureBox14 = new CustomPictureBox();
      this.customPictureBox13 = new CustomPictureBox();
      this.customPictureBox12 = new CustomPictureBox();
      this.customPictureBox11 = new CustomPictureBox();
      this.customPictureBox10 = new CustomPictureBox();
      this.customPictureBox9 = new CustomPictureBox();
      this.customPictureBox8 = new CustomPictureBox();
      this.customPictureBox7 = new CustomPictureBox();
      this.ButtonB = new CustomPictureBox();
      this.ButtonA = new CustomPictureBox();
      this.ButtonX = new CustomPictureBox();
      this.customPictureBox3 = new CustomPictureBox();
      this.customPictureBox2 = new CustomPictureBox();
      ((ISupportInitialize) this.xboxController).BeginInit();
      ((ISupportInitialize) this.ButtonY).BeginInit();
      ((ISupportInitialize) this.customPictureBox14).BeginInit();
      ((ISupportInitialize) this.customPictureBox13).BeginInit();
      ((ISupportInitialize) this.customPictureBox12).BeginInit();
      ((ISupportInitialize) this.customPictureBox11).BeginInit();
      ((ISupportInitialize) this.customPictureBox10).BeginInit();
      ((ISupportInitialize) this.customPictureBox9).BeginInit();
      ((ISupportInitialize) this.customPictureBox8).BeginInit();
      ((ISupportInitialize) this.customPictureBox7).BeginInit();
      ((ISupportInitialize) this.ButtonB).BeginInit();
      ((ISupportInitialize) this.ButtonA).BeginInit();
      ((ISupportInitialize) this.ButtonX).BeginInit();
      ((ISupportInitialize) this.customPictureBox3).BeginInit();
      ((ISupportInitialize) this.customPictureBox2).BeginInit();
      this.SuspendLayout();
      this.xboxController.Dock = DockStyle.Fill;
      this.xboxController.Image = (Image) Resources.padx360;
      this.xboxController.Location = new Point(0, 0);
      this.xboxController.Name = "xboxController";
      this.xboxController.Size = new Size(400, 326);
      this.xboxController.SizeMode = PictureBoxSizeMode.AutoSize;
      this.xboxController.TabIndex = 0;
      this.xboxController.TabStop = false;
      this.labelPushBtn.AutoSize = true;
      this.labelPushBtn.BackColor = SystemColors.ActiveCaptionText;
      this.labelPushBtn.Font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold, GraphicsUnit.Point, (byte) 204);
      this.labelPushBtn.Location = new Point(129, 225);
      this.labelPushBtn.Name = "labelPushBtn";
      this.labelPushBtn.Size = new Size(148, 20);
      this.labelPushBtn.TabIndex = 17;
      this.labelPushBtn.Text = "Push new button.";
      this.ButtonY.BackColor = Color.Transparent;
      this.ButtonY.BackgroundImage = (Image) Resources.padx360;
      this.ButtonY.Image = (Image) Resources.padx360_triangle;
      this.ButtonY.Location = new Point(282, 61);
      this.ButtonY.Name = "ButtonY";
      this.ButtonY.Size = new Size(31, 29);
      this.ButtonY.SizeMode = PictureBoxSizeMode.AutoSize;
      this.ButtonY.TabIndex = 16;
      this.ButtonY.TabStop = false;
      this.customPictureBox14.BackColor = Color.Transparent;
      this.customPictureBox14.BackgroundImage = (Image) Resources.padx360;
      this.customPictureBox14.Image = (Image) Resources.padx360_down;
      this.customPictureBox14.Location = new Point(139, 165);
      this.customPictureBox14.Name = "customPictureBox14";
      this.customPictureBox14.Size = new Size(20, 15);
      this.customPictureBox14.SizeMode = PictureBoxSizeMode.AutoSize;
      this.customPictureBox14.TabIndex = 14;
      this.customPictureBox14.TabStop = false;
      this.customPictureBox13.BackColor = Color.Transparent;
      this.customPictureBox13.BackgroundImage = (Image) Resources.padx360;
      this.customPictureBox13.Image = (Image) Resources.padx360_up;
      this.customPictureBox13.Location = new Point(138, 128);
      this.customPictureBox13.Name = "customPictureBox13";
      this.customPictureBox13.Size = new Size(20, 17);
      this.customPictureBox13.SizeMode = PictureBoxSizeMode.AutoSize;
      this.customPictureBox13.TabIndex = 13;
      this.customPictureBox13.TabStop = false;
      this.customPictureBox12.BackColor = Color.Transparent;
      this.customPictureBox12.BackgroundImage = (Image) Resources.padx360;
      this.customPictureBox12.Image = (Image) Resources.padx360_start;
      this.customPictureBox12.Location = new Point(223, 91);
      this.customPictureBox12.Name = "customPictureBox12";
      this.customPictureBox12.Size = new Size(26, 22);
      this.customPictureBox12.SizeMode = PictureBoxSizeMode.AutoSize;
      this.customPictureBox12.TabIndex = 12;
      this.customPictureBox12.TabStop = false;
      this.customPictureBox11.BackColor = Color.Transparent;
      this.customPictureBox11.BackgroundImage = (Image) Resources.padx360;
      this.customPictureBox11.Image = (Image) Resources.padx360_select;
      this.customPictureBox11.Location = new Point(152, 92);
      this.customPictureBox11.Name = "customPictureBox11";
      this.customPictureBox11.Size = new Size(25, 21);
      this.customPictureBox11.SizeMode = PictureBoxSizeMode.AutoSize;
      this.customPictureBox11.TabIndex = 11;
      this.customPictureBox11.TabStop = false;
      this.customPictureBox10.BackColor = Color.Transparent;
      this.customPictureBox10.BackgroundImage = (Image) Resources.padx360;
      this.customPictureBox10.Image = (Image) Resources.padx360_right;
      this.customPictureBox10.Location = new Point(160, 144);
      this.customPictureBox10.Name = "customPictureBox10";
      this.customPictureBox10.Size = new Size(16, 23);
      this.customPictureBox10.SizeMode = PictureBoxSizeMode.AutoSize;
      this.customPictureBox10.TabIndex = 10;
      this.customPictureBox10.TabStop = false;
      this.customPictureBox9.BackColor = Color.Transparent;
      this.customPictureBox9.BackgroundImage = (Image) Resources.padx360;
      this.customPictureBox9.Image = (Image) Resources.padx360_R2;
      this.customPictureBox9.Location = new Point(272, 9);
      this.customPictureBox9.Name = "customPictureBox9";
      this.customPictureBox9.Size = new Size(27, 30);
      this.customPictureBox9.SizeMode = PictureBoxSizeMode.AutoSize;
      this.customPictureBox9.TabIndex = 9;
      this.customPictureBox9.TabStop = false;
      this.customPictureBox8.BackColor = Color.Transparent;
      this.customPictureBox8.BackgroundImage = (Image) Resources.padx360;
      this.customPictureBox8.Image = (Image) Resources.padx360_R1;
      this.customPictureBox8.Location = new Point(267, 38);
      this.customPictureBox8.Name = "customPictureBox8";
      this.customPictureBox8.Size = new Size(60, 24);
      this.customPictureBox8.SizeMode = PictureBoxSizeMode.AutoSize;
      this.customPictureBox8.TabIndex = 8;
      this.customPictureBox8.TabStop = false;
      this.customPictureBox7.BackColor = Color.Transparent;
      this.customPictureBox7.BackgroundImage = (Image) Resources.padx360;
      this.customPictureBox7.Image = (Image) Resources.padx360_L2;
      this.customPictureBox7.Location = new Point(105, 10);
      this.customPictureBox7.Name = "customPictureBox7";
      this.customPictureBox7.Size = new Size(24, 28);
      this.customPictureBox7.SizeMode = PictureBoxSizeMode.AutoSize;
      this.customPictureBox7.TabIndex = 7;
      this.customPictureBox7.TabStop = false;
      this.ButtonB.BackColor = Color.Transparent;
      this.ButtonB.BackgroundImage = (Image) Resources.padx360;
      this.ButtonB.Image = (Image) Resources.padx360_rond;
      this.ButtonB.Location = new Point(308, 86);
      this.ButtonB.Name = "ButtonB";
      this.ButtonB.Size = new Size(30, 30);
      this.ButtonB.SizeMode = PictureBoxSizeMode.AutoSize;
      this.ButtonB.TabIndex = 6;
      this.ButtonB.TabStop = false;
      this.ButtonA.BackColor = Color.Transparent;
      this.ButtonA.BackgroundImage = (Image) Resources.padx360;
      this.ButtonA.Image = (Image) Resources.padx360_croix;
      this.ButtonA.Location = new Point(283, 111);
      this.ButtonA.Name = "ButtonA";
      this.ButtonA.Size = new Size(30, 29);
      this.ButtonA.SizeMode = PictureBoxSizeMode.AutoSize;
      this.ButtonA.TabIndex = 5;
      this.ButtonA.TabStop = false;
      this.ButtonX.BackColor = Color.Transparent;
      this.ButtonX.BackgroundImage = (Image) Resources.padx360;
      this.ButtonX.Image = (Image) Resources.padx360_carre;
      this.ButtonX.Location = new Point(257, 86);
      this.ButtonX.Name = "ButtonX";
      this.ButtonX.Size = new Size(29, 29);
      this.ButtonX.SizeMode = PictureBoxSizeMode.AutoSize;
      this.ButtonX.TabIndex = 4;
      this.ButtonX.TabStop = false;
      this.customPictureBox3.BackColor = Color.Transparent;
      this.customPictureBox3.BackgroundImage = (Image) Resources.padx360;
      this.customPictureBox3.Image = (Image) Resources.padx360_L1;
      this.customPictureBox3.ImageVisible = true;
      this.customPictureBox3.Location = new Point(80, 37);
      this.customPictureBox3.Name = "customPictureBox3";
      this.customPictureBox3.Size = new Size(55, 18);
      this.customPictureBox3.SizeMode = PictureBoxSizeMode.AutoSize;
      this.customPictureBox3.TabIndex = 3;
      this.customPictureBox3.TabStop = false;
      this.customPictureBox2.BackColor = Color.Transparent;
      this.customPictureBox2.BackgroundImage = (Image) Resources.padx360;
      this.customPictureBox2.Image = (Image) Resources.padx360_left;
      this.customPictureBox2.Location = new Point(122, 144);
      this.customPictureBox2.Name = "customPictureBox2";
      this.customPictureBox2.Size = new Size(14, 23);
      this.customPictureBox2.SizeMode = PictureBoxSizeMode.AutoSize;
      this.customPictureBox2.TabIndex = 2;
      this.customPictureBox2.TabStop = false;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackgroundImage = (Image) Resources.padx360;
      this.ClientSize = new Size(400, 326);
      this.Controls.Add((Control) this.labelPushBtn);
      this.Controls.Add((Control) this.ButtonY);
      this.Controls.Add((Control) this.customPictureBox14);
      this.Controls.Add((Control) this.customPictureBox13);
      this.Controls.Add((Control) this.customPictureBox12);
      this.Controls.Add((Control) this.customPictureBox11);
      this.Controls.Add((Control) this.customPictureBox10);
      this.Controls.Add((Control) this.customPictureBox9);
      this.Controls.Add((Control) this.customPictureBox8);
      this.Controls.Add((Control) this.customPictureBox7);
      this.Controls.Add((Control) this.ButtonB);
      this.Controls.Add((Control) this.ButtonA);
      this.Controls.Add((Control) this.ButtonX);
      this.Controls.Add((Control) this.customPictureBox3);
      this.Controls.Add((Control) this.customPictureBox2);
      this.Controls.Add((Control) this.xboxController);
      this.Name = nameof (JoystickCalibration);
      this.Text = nameof (JoystickCalibration);
      ((ISupportInitialize) this.xboxController).EndInit();
      ((ISupportInitialize) this.ButtonY).EndInit();
      ((ISupportInitialize) this.customPictureBox14).EndInit();
      ((ISupportInitialize) this.customPictureBox13).EndInit();
      ((ISupportInitialize) this.customPictureBox12).EndInit();
      ((ISupportInitialize) this.customPictureBox11).EndInit();
      ((ISupportInitialize) this.customPictureBox10).EndInit();
      ((ISupportInitialize) this.customPictureBox9).EndInit();
      ((ISupportInitialize) this.customPictureBox8).EndInit();
      ((ISupportInitialize) this.customPictureBox7).EndInit();
      ((ISupportInitialize) this.ButtonB).EndInit();
      ((ISupportInitialize) this.ButtonA).EndInit();
      ((ISupportInitialize) this.ButtonX).EndInit();
      ((ISupportInitialize) this.customPictureBox3).EndInit();
      ((ISupportInitialize) this.customPictureBox2).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public enum ButtonCtrl
    {
      ButtonCtrl_A,
      ButtonCtrl_B,
      ButtonCtrl_X,
      ButtonCtrl_Y,
      ButtonCtrl_Count,
    }
  }
}
