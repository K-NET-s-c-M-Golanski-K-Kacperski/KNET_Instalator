using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KNET_Instalator
{
    internal static class Downloader
    {
        public static async Task DownloadInstaller(string source, string path, string appName)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string tempFileName = Path.Combine(Path.GetTempPath(), Path.ChangeExtension(Path.GetRandomFileName(), "tmp"));

            try
            {
                using HttpClient client = new();
                var uri = new Uri(source);
                var result = await client.GetAsync(uri);
                using FileStream fs = new(tempFileName, FileMode.OpenOrCreate, FileAccess.Write);
                await result.Content.CopyToAsync(fs);
                fs.Close();
                //nazwa instalatorów ujednolicona
                string destinationFileName = Path.Combine(path, $"{appName}installer.exe");
                if (File.Exists(destinationFileName)) File.Delete(destinationFileName);
                File.Move(tempFileName, destinationFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
