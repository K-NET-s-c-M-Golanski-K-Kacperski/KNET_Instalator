using System.Diagnostics;

namespace KNET_Instalator
{
    internal static class Installer 
    {
        public static void InstallApp(string path)
        {
            try
            {
                ProcessStartInfo psi = new()
                {
                    FileName = path
                };

                Process process = new() { StartInfo = psi };
                process.Start();
                process.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            

        }
}
    }

