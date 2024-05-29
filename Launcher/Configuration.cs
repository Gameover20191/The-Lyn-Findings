// Decompiled with JetBrains decompiler
// Type: Launcher.Configuration
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6AA362FF-B506-4D02-B128-5EAE460AD817
// Assembly location: C:\Program Files (x86)\Ubisoft\Rabbids Go Home - DVD\Launcher.exe

using Microsoft.Win32;
using System;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace Launcher
{
    public class Configuration
    {
        private System.Configuration.Configuration config;
        private ConfigSection section;
        private DisplayInformation displayInfo;
        private static Launcher.Configuration globalInstance = (Launcher.Configuration)null;
        private static string[] regLocations = new string[2]
        {
      "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\",
      "SOFTWARE\\Wow6432Node\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\"
        };
        private static string[] installationGUID = new string[5]
        {
      "{0E065330-E9AD-4FB2-96BB-1EB08971C3E2}",
      "{8D598F02-4381-458A-BABD-A04479A65CD5}",
      "{B82BE3D3-70BC-48C1-8DB2-5F63184E0765}",
      "{BD74619D-38CD-4A3D-AAFA-D29B6FA1EF3D}",
      "{41899391-E156-4166-9DD3-DDDB76B45895}"
        };

        public Configuration()
        {
            this.config = (System.Configuration.Configuration)null;
            this.section = (ConfigSection)null;
            this.displayInfo = new DisplayInformation();
        }

        public static string GetConfigFileName(int versionIndex)
        {
            string configFileName = (string)null;
            if (versionIndex != -1)
                configFileName = Application.CommonAppDataPath + "\\Launcher_" + versionIndex.ToString() + ".exe.config";
            return configFileName;
        }

        public static int GetVersionIndex()
        {
            foreach (string regLocation in Launcher.Configuration.regLocations)
            {
                for (int index = 0; index < Launcher.Configuration.installationGUID.Length; ++index)
                {
                    RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(regLocation + Launcher.Configuration.installationGUID[index]);
                    if (registryKey != null && (string)registryKey.GetValue("InstallLocation", (object)"NONE") == Launcher.Configuration.GetExecutablePath())
                        return index + 1;
                }
            }
            return -1;
        }

        public static bool WriteRegLanguage(Launcher.Configuration.Lang language)
        {
            int index = Launcher.Configuration.GetVersionIndex() - 1;
            foreach (string regLocation in Launcher.Configuration.regLocations)
            {
                RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(regLocation + Launcher.Configuration.installationGUID[index], true);
                if (registryKey != null)
                {
                    try
                    {
                        registryKey.SetValue("Language", (object)Launcher.Configuration.LangToRegLang(language));
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        continue;
                    }
                    return true;
                }
            }
            return false;
        }

        public void OpenConfigurationObject(string fileName)
        {
            if (this.config != null)
                this.CloseConfigurationObject();
            this.config = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap()
            {
                ExeConfigFilename = fileName
            }, ConfigurationUserLevel.None);
            if ((this.section = this.config.GetSection("Launcher.Settings") as ConfigSection) == null)
            {
                this.section = new ConfigSection();
                this.config.Sections.Add("Launcher.Settings", (ConfigurationSection)this.section);
                Launcher.Configuration.Lang lang = Launcher.Configuration.Lang.English;
                foreach (string regLocation in Launcher.Configuration.regLocations)
                {
                    for (int index = 0; index < Launcher.Configuration.installationGUID.Length; ++index)
                    {
                        RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(regLocation + Launcher.Configuration.installationGUID[index]);
                        if (registryKey != null && registryKey.GetValue("InstallLocation", (object)"NONE").ToString() == Launcher.Configuration.GetExecutablePath())
                        {
                            lang = Launcher.Configuration.RegLangToLang((int)registryKey.GetValue("Language", (object)1033));
                            break;
                        }
                    }
                }
                this.section.Parent = this;
                this.section.Language = lang;
            }
            else
                this.section.Parent = this;
        }

        public void CloseConfigurationObject()
        {
            DialogResult dialogResult = DialogResult.None;
            do
            {
                try
                {
                    this.config.Save(ConfigurationSaveMode.Full);
                }
                catch (ConfigurationErrorsException ex)
                {
                    dialogResult = MessageBox.Show((IWin32Window)null, "An error occurred while saving configuration file!", "Error...", MessageBoxButtons.RetryCancel, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
            }
            while (dialogResult == DialogResult.Retry);
            this.section = (ConfigSection)null;
            this.config = (System.Configuration.Configuration)null;
        }

        public static string GetExecutablePath() => Path.GetDirectoryName(Application.ExecutablePath);

        public static string GetMediaPath() => Launcher.Configuration.GetExecutablePath() + "\\Media";

        public ConfigSection Settings => this.section;

        public DisplayInformation DisplayInfo => this.displayInfo;

        public static Launcher.Configuration Global
        {
            get => Launcher.Configuration.globalInstance;
            set => Launcher.Configuration.globalInstance = value;
        }

        private static Launcher.Configuration.Lang RegLangToLang(int lang)
        {
            switch (lang)
            {
                case 1031:
                    return Launcher.Configuration.Lang.German;
                case 1033:
                    return Launcher.Configuration.Lang.English;
                case 1034:
                    return Launcher.Configuration.Lang.Spanish;
                case 1036:
                    return Launcher.Configuration.Lang.French;
                case 1040:
                    return Launcher.Configuration.Lang.Italian;
                case 1043:
                    return Launcher.Configuration.Lang.Dutch;
                default:
                    return Launcher.Configuration.Lang.English;
            }
        }

        private static int LangToRegLang(Launcher.Configuration.Lang lang)
        {
            switch (lang)
            {
                case Launcher.Configuration.Lang.English:
                    return 1033;
                case Launcher.Configuration.Lang.French:
                    return 1036;
                case Launcher.Configuration.Lang.German:
                    return 1031;
                case Launcher.Configuration.Lang.Italian:
                    return 1040;
                case Launcher.Configuration.Lang.Spanish:
                    return 1034;
                case Launcher.Configuration.Lang.Dutch:
                    return 1043;
                default:
                    return 1033;
            }
        }

        public enum Lang
        {
            English,
            French,
            German,
            Italian,
            Spanish,
            Dutch,
        }
    }
}
