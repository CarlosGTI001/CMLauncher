using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMLauncher.Modelos
{
    public class versiones
    {
        public string id { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public DateTime time { get; set; }
        public DateTime releaseTime { get; set; }
        public bool descargado { get; set; } = false;
    }
}
