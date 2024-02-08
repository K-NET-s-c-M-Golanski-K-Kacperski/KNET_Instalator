using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KNET_Instalator
{
    internal class Config
    {
        public Dictionary<string, string>? installerLinks { get; set; }
        public Dictionary<string, string>? savePaths { get; set; }
    }
}
