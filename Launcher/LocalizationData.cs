// Decompiled with JetBrains decompiler
// Type: Launcher.LocalizationData
// Assembly: Launcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6AA362FF-B506-4D02-B128-5EAE460AD817
// Assembly location: C:\Program Files (x86)\Ubisoft\Rabbids Go Home - DVD\Launcher.exe

using System.Globalization;
using System.Threading;

#nullable disable
namespace Launcher
{
    public class LocalizationData
    {
        private static bool resetAppCulture = true;

        public static bool ResetAppCulture
        {
            get => LocalizationData.resetAppCulture;
            set => LocalizationData.resetAppCulture = value;
        }

        public static bool SetThreadUICulture(Configuration.Lang language)
        {
            if (!LocalizationData.resetAppCulture)
                return false;
            string name = "en";
            switch (language)
            {
                case Configuration.Lang.French:
                    name = "fr";
                    break;
                case Configuration.Lang.German:
                    name = "de";
                    break;
                case Configuration.Lang.Italian:
                    name = "it";
                    break;
                case Configuration.Lang.Spanish:
                    name = "es";
                    break;
                case Configuration.Lang.Dutch:
                    name = "nl";
                    break;
            }
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(name);
            LocalizationData.resetAppCulture = false;
            return true;
        }
    }
}
