// Decompiled with JetBrains decompiler
// Type: Launcher.ConfigSection
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6AA362FF-B506-4D02-B128-5EAE460AD817
// Assembly location: C:\Program Files (x86)\Ubisoft\Rabbids Go Home - DVD\Launcher.exe

using System;
using System.Configuration;
using System.Windows.Forms;

#nullable disable
namespace Launcher
{
  public sealed class ConfigSection : ConfigurationSection
  {
    private Launcher.Configuration parent;
    private static ConfigurationPropertyCollection propertyBag;
    private static readonly ConfigurationProperty videoMode = new ConfigurationProperty(nameof (VideoMode), typeof (string), (object) " ", ConfigurationPropertyOptions.IsRequired);
    private static readonly ConfigurationProperty multiSample = new ConfigurationProperty("Multi-Sampling", typeof (string), (object) "None", ConfigurationPropertyOptions.IsRequired);
    private static readonly ConfigurationProperty vSync = new ConfigurationProperty("V-Sync", typeof (bool), (object) true, ConfigurationPropertyOptions.IsRequired);
    private static readonly ConfigurationProperty windowed = new ConfigurationProperty(nameof (Windowed), typeof (bool), (object) false, ConfigurationPropertyOptions.IsRequired);
    private static readonly ConfigurationProperty language = new ConfigurationProperty(nameof (Language), typeof (Launcher.Configuration.Lang), (object) Launcher.Configuration.Lang.English, ConfigurationPropertyOptions.IsRequired);

    public ConfigSection()
    {
      this.parent = (Launcher.Configuration) null;
      ConfigSection.propertyBag = new ConfigurationPropertyCollection();
      ConfigSection.propertyBag.Add(ConfigSection.videoMode);
      ConfigSection.propertyBag.Add(ConfigSection.multiSample);
      ConfigSection.propertyBag.Add(ConfigSection.vSync);
      ConfigSection.propertyBag.Add(ConfigSection.windowed);
      ConfigSection.propertyBag.Add(ConfigSection.language);
    }

    protected override ConfigurationPropertyCollection Properties => ConfigSection.propertyBag;

    public Launcher.Configuration Parent
    {
      get => this.parent;
      set => this.parent = value;
    }

    public string VideoMode
    {
      get
      {
        string mode = (string) this[nameof (VideoMode)];
        if (this.parent.DisplayInfo.IsModeSupported(mode))
          return mode;
        string supportedMode = this.parent.DisplayInfo.GetSupportedMode(true);
        if (supportedMode == null)
        {
          int num = (int) MessageBox.Show((IWin32Window) null, "An error occurred while selecting compatible display modes! Please check your display driver is up to date!", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
          Environment.Exit(0);
        }
        return (string) (this[nameof (VideoMode)] = (object) supportedMode);
      }
      set => this[nameof (VideoMode)] = (object) value;
    }

    public string MultiSample
    {
      get
      {
        string sampling = (string) this["Multi-Sampling"];
        return this.parent.DisplayInfo.IsSamplingSupported(sampling) ? sampling : (string) (this["Multi-Sampling"] = (object) this.parent.DisplayInfo.GetSupportedSampling());
      }
      set => this["Multi-Sampling"] = (object) value;
    }

    public bool VSync
    {
      get => (bool) this["V-Sync"];
      set => this["V-Sync"] = (object) value;
    }

    public bool Windowed
    {
      get => (bool) this[nameof (Windowed)];
      set => this[nameof (Windowed)] = (object) value;
    }

    public Launcher.Configuration.Lang Language
    {
      get => (Launcher.Configuration.Lang) this[nameof (Language)];
      set => this[nameof (Language)] = (object) value;
    }
  }
}
