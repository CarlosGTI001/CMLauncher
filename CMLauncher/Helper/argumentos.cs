using CLauncher.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static CLauncher.Helper.administradorVersiones;

namespace CLauncher.Helper
{
    public class argumentos
    {
        public class ArgumentosJuegoModelo
        {
            public string userName { get; set; }
            public string uuid { get; set; }
            public string gameDir { get; set; }
            public string assetDir { get; set; }
            public string versionType { get; set; }
            public string clientId { get; set; }
            public string assetIndex { get; set; }
            public string userType { get; set; }
            public string Dlog { get; set; }
        }

        public class ArgumentosJavaModelo
        {
            public int XmX { get; set; }
            public int XmN  { get; set; }
            public string ArgumentoOpcional { get; set; } = "-XX:+UnlockExperimentalVMOptions -XX:+UseG1GC -XX:G1NewSizePercent=20 -XX:G1ReservePercent=20 -XX:MaxGCPauseMillis=50 -XX:G1HeapRegionSize=32M";
            public string LauncherBrand { get; set; }
            public string LauncherVer { get; set; } 
        }

        

        private string ArgumentosJuego(string Path)
        {

            return "";
        }

        private string ArgumentosJava(string Path)
        {

            return "";
        }
    }
}
