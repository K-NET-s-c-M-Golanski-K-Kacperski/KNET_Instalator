using KNET_Instalator;
using System.Net;
using System.Text;

namespace KNET_Instalator
{
    internal static class KNET_Instalator
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Witam!");
            Config? config = ConfigReader.ReadConfiguration();
            if (config != null && config.InstallerLinks!=null && config.SavePaths!=null)
            {
                bool IsActve = true;
                while(IsActve)
                {
                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine("Dostępne aplikacje:");
                    foreach (var app in config.InstallerLinks)
                    {
                        Console.WriteLine("• " + app.Key);
                    }
                    Console.WriteLine(new string('-', 50));
                    string? choice;
                    do Console.WriteLine("Wybierz aplikacje, które chcesz zainstalować. Wypisz nazwy po przecinku.\nNapisz \"wszystkie\" aby wybrać wszystkie aplikacje z listy\nNapisz \"exit\" aby wyjść.");
                    while ((choice = Console.ReadLine()) == null);
                    switch (choice)
                    {
                        case "wszystkie":
                            foreach (var app in config.InstallerLinks)
                            {
                                //powtórzenie kodu - do naprawy
                                Downloader.DownloadInstaller(app.Value, config.SavePaths[app.Key], app.Key).Wait();
                                Console.WriteLine($"Pobrano instalator {app.Key}");
                                Console.WriteLine("Czy chcesz zainstalować tę aplikację w trybie cichym? [y/n]");
                                var mode = Console.ReadLine() == "y" ? Installer.InstalationMode.Silent : Installer.InstalationMode.Normal;
                                Installer.InstallApp($"{config.SavePaths[app.Key]}\\{app.Key}installer.exe", app.Key, mode);
                                Console.WriteLine($"Zainstalowano {app.Key}");
                            }
                            break;
                        case "exit":
                            IsActve = false;
                            break;
                        default:
                            var apps = choice.Split(',');
                            foreach (var chosenApp in apps)
                            {
                                if (config.SavePaths.ContainsKey(chosenApp))
                                {
                                    Downloader.DownloadInstaller(config.InstallerLinks[chosenApp], config.SavePaths[chosenApp], chosenApp).Wait();
                                    Console.WriteLine($"Pobrano instalator {chosenApp}");
                                    Console.WriteLine("Czy chcesz zainstalować tę aplikację w trybie cichym? [y/n]");
                                    var mode = Console.ReadLine() == "y" ? Installer.InstalationMode.Silent : Installer.InstalationMode.Normal;
                                    Installer.InstallApp($"{config.SavePaths[chosenApp]}\\{chosenApp}installer.exe", chosenApp, mode);
                                    //idk czy usuwac instalator po instalacji?
                                    Console.WriteLine($"Zainstalowano {chosenApp}");
                                }
                                else Console.WriteLine("\nWybrano niedostępną aplikację\n");
                            }
                            break;
                    }
                }
            }
            else Console.WriteLine("Brak aplikacji dostępnych w konfiguracji");
        }
    }
}

