// Decompiled with JetBrains decompiler
// Type: Launcher.Program
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6AA362FF-B506-4D02-B128-5EAE460AD817
// Assembly location: C:\Program Files (x86)\Ubisoft\Rabbids Go Home - DVD\Launcher.exe

using System;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace Launcher
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Mutex mutex = (Mutex)null;
            int versionIndex = Configuration.GetVersionIndex();
            string configFileName = Configuration.GetConfigFileName(versionIndex);
            if (versionIndex != -1 && configFileName != null)
            {
                bool createdNew;
                mutex = new Mutex(true, "RGH_Launcher_" + versionIndex.ToString(), out createdNew);
                if (!createdNew)
                    return;
                Configuration.Global = new Configuration();
                Configuration.Global.OpenConfigurationObject(configFileName);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                while (LocalizationData.SetThreadUICulture(Configuration.Global.Settings.Language))
                    Application.Run((Form)new MainForm(versionIndex));
            }
            else
            {
                int num = (int)MessageBox.Show("An error occurred while starting the game launcher!\nPlease reinstall the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            if (Configuration.Global != null)
                Configuration.Global.CloseConfigurationObject();
            if (mutex == null)
                return;
            GC.KeepAlive((object)mutex);
        }
    }
}
