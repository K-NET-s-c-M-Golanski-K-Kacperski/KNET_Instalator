using KNET_Instalator;
using System.Net;

namespace KNET_Instalator
{
    internal static class KNET_Instalator
    {
        public static void Main()
        {
            Console.WriteLine("Witam!");
            Config config = ConfigReader.ReadConfiguration();
            if (config != null)
            {
                Console.WriteLine("Dostępne aplikacje:");
                foreach(var app in config.installerLinks) 
                {
                    Console.WriteLine(app.Key);
                }
                Console.WriteLine("Wybierz aplikacje, które chcesz zainstalować. Wypisz nazwy po przecinku.");
                var choice = Console.ReadLine();
                var apps = choice.Split(',');
                foreach (var chosenApp in apps)
                {
                    if (config.savePaths.ContainsKey(chosenApp))
                    {
                        Downloader.DownloadInstaller(config.installerLinks[chosenApp], config.savePaths[chosenApp],chosenApp);
                        Console.WriteLine($"Pobrano instalator {chosenApp}");
                        Console.WriteLine("Czy chcesz zainstalować tę aplikację w trybie cichym? [y/n]");
                        var mode = Console.ReadLine() == "y" ? true : false;
                        //true == silent
                        Installer.InstallApp($"{config.savePaths[chosenApp]}\\{chosenApp}installer.exe", chosenApp, mode);
                        Console.WriteLine($"Zainstalowano {chosenApp}");
                    }
                    else Console.WriteLine("aaa");
                }


            }

        }
    }

}

