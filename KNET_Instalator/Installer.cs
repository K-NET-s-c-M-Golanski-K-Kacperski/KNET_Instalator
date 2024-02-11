using System.Diagnostics;

namespace KNET_Instalator
{
    internal static class Installer 
    {
        public static void InstallApp(string path, string appName, bool mode)
        {
            var arguments = "";
            // troche hard coded??
            if (mode) arguments = $"/S /D=\"C:\\Program Files\\{appName}\"";
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

