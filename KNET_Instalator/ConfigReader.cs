using System.Reflection;
using System.Text.Json;


namespace KNET_Instalator
{
    internal static class ConfigReader
    {
        public static Config? ReadConfiguration()
        {
            string pathToConfig = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"config.json");
            Config? config = new();
            try
            {
                string json = File.ReadAllText(pathToConfig);
                config = JsonSerializer.Deserialize<Config>(json);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading configuration: {ex.Message}");
            }
            return config;
        }

    }
}
