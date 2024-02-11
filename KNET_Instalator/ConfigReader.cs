using System.Text.Json;


namespace KNET_Instalator
{
    internal static class ConfigReader
    {
        //hard coded (na razie)
        const string pathToConfig = @"C:\Users\Dell\source\repos\KNET_Instalator\KNET_Instalator\config.json";

        public static Config? ReadConfiguration(string path)
        { 
            Config? config = new();
            try
            {
                string json = File.ReadAllText(path);
                config = JsonSerializer.Deserialize<Config>(json);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading configuration: {ex.Message}");
            }
            return config;
        }
        public static Config? ReadConfiguration() => ReadConfiguration(pathToConfig);
    }
}
