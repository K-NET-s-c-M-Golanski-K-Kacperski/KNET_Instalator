using System.Diagnostics;

namespace KNET_Instalator
{
    internal static class Installer 
    {
        public enum InstalationMode
        {
            Normal,
            Silent
        }
        public static void InstallApp(string path, string appName, InstalationMode mode)
        {
            var arguments = "";
            // troche hard coded??
            if (mode == InstalationMode.Silent) arguments = $"/S /D=\"C:\\Program Files\\{appName}\"";
            try
            {
                ProcessStartInfo psi = new()
                {
                    FileName = path,
                    //arguemnt pozwala na cichą instalację
                    Arguments = arguments
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

