// Decompiled with JetBrains decompiler
// Type: Launcher.ApplicationLauncher
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6AA362FF-B506-4D02-B128-5EAE460AD817
// Assembly location: C:\Program Files (x86)\Ubisoft\Rabbids Go Home - DVD\Launcher.exe

using System.ComponentModel;
using System.Diagnostics;

#nullable disable
namespace Launcher
{
  public class ApplicationLauncher
  {
    private static string[] strLangCmd = new string[6]
    {
      "/lang/en",
      "/lang/fr",
      "/lang/de",
      "/lang/it",
      "/lang/es",
      "/lang/nl"
    };

    public static bool Launch(int versionIndex)
    {
      string str = string.Format("\"{0}\"", (object) (Configuration.GetExecutablePath() + "\\RGH_defrag.bf"));
      if (str == null)
        return false;
      Process process = new Process();
      process.StartInfo.FileName = ApplicationLauncher.GetEngineExecutable();
      process.StartInfo.WorkingDirectory = Configuration.GetExecutablePath();
      process.StartInfo.Arguments = str + " " + ApplicationLauncher.GetCommandLine(versionIndex);
      process.StartInfo.ErrorDialog = true;
      try
      {
        process.Start();
      }
      catch (Win32Exception ex)
      {
        return false;
      }
      return true;
    }

    public static string GetCommandLine(int versionIndex)
    {
      return "" + "/binload/fe " + ApplicationLauncher.strLangCmd[(int) Configuration.Global.Settings.Language] + " " + (Configuration.Global.Settings.Windowed ? "" : "/fullscreen ") + (Configuration.Global.Settings.VSync ? "/vsync " : "") + "/res" + Configuration.Global.Settings.VideoMode + " " + "/versionIndex:" + versionIndex.ToString();
    }

    public static string GetEngineExecutable() => "LyN_f.exe";
  }
}
