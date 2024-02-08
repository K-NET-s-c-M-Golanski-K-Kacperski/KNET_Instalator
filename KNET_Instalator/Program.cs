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
                        Installer.InstallApp($"{config.savePaths[chosenApp]}\\{chosenApp}installer.exe");
                    }
                    else Console.WriteLine("aaa");
                }


            }

        }
        static List<int> ParseNumbers(string input)
        {
            List<int> numbers = new();

            string[] parts = input.Split(',');

            foreach (string part in parts)
            {
                if (int.TryParse(part.Trim(), out int number))
                {
                    numbers.Add(number);
                }
                else
                {
                    Console.WriteLine($"Nie udało się przekonwertować '{part.Trim()}' na liczbę.");
                }
            }

            return numbers;
        }
    }

}

