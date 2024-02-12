using KNET_Instalator;
using System.Net;

namespace KNET_Instalator
{
    internal static class KNET_Instalator
    {
        public static void Main()
        {
            Console.WriteLine("Witam!");
            Config? config = ConfigReader.ReadConfiguration();
            if (config != null && config.InstallerLinks!=null && config.SavePaths!=null)
            {
                Console.WriteLine("Dostępne aplikacje:");
                foreach (var app in config.InstallerLinks)
                {
                    Console.WriteLine(app.Key);
                }
                string? choice;
                do Console.WriteLine("Wybierz aplikacje, które chcesz zainstalować. Wypisz nazwy po przecinku.");
                while ((choice = Console.ReadLine()) == null);
                var apps = choice.Split(',');
                foreach (var chosenApp in apps)
                {
                    if (config.SavePaths.ContainsKey(chosenApp))
                    {
                        Downloader.DownloadInstaller(config.InstallerLinks[chosenApp], config.SavePaths[chosenApp], chosenApp);
                        Console.WriteLine($"Pobrano instalator {chosenApp}");
                        Console.WriteLine("Czy chcesz zainstalować tę aplikację w trybie cichym? [y/n]");
                        var mode = Console.ReadLine() == "y" ? Installer.InstalationMode.Silent : Installer.InstalationMode.Normal;
                        Installer.InstallApp($"{config.SavePaths[chosenApp]}\\{chosenApp}installer.exe", chosenApp, mode);
                        //idk czy usuwac instalator po instalacji?
                        Console.WriteLine($"Zainstalowano {chosenApp}");
                    }
                    else Console.WriteLine("Wybrano niedostępną aplikację");
                }
            }
            else Console.WriteLine("Brak aplikacji dostępnych w konfiguracji");
        }
    }

}

