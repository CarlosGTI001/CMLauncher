using CMLauncher.Modelos;
using CMLauncher.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMLauncher.Helper
{
    public class Minecraft
    {
        Settings Settings = new Settings();
        public void ejecutar(argumentos _argumentos)
        {
            string carpetaLibreria = Settings.minecraftPath + "libraries\\";
            string[] argumentos = new string[0];
            argumentos = argumentos.Append(_argumentos.javapath + "javaw.exe").ToArray();
            argumentos = argumentos.Append(" -XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump \"-Dos.name=Windows 10\"").ToArray();
            argumentos = argumentos.Append(" -Dos.version="+ _argumentos.verWindows).ToArray();
            argumentos = argumentos.Append(" -Xss1M").ToArray();
            argumentos = argumentos.Append(" -Dminecraft.launcher.brand="+ _argumentos.LauncherBrand).ToArray();
            argumentos = argumentos.Append(" -Dminecraft.launcher.version=" + _argumentos.LauncherVersion).ToArray();
            argumentos = argumentos.Append(" -cp ").ToArray();
            foreach (Library library in _argumentos.Librerias)
            {
                argumentos = argumentos.Append(carpetaLibreria + library.downloads.artifact.path + ";").ToArray();
            }
            argumentos = argumentos.Append(" -Xmx" + _argumentos.Xmx + "M").ToArray();
            argumentos = argumentos.Append(" -Xmn" + _argumentos.Xmn + "M").ToArray();
            argumentos = argumentos.Append(" -XX:+UnlockExperimentalVMOptions").ToArray();
            argumentos = argumentos.Append(" -XX:+UseG1GC -XX:G1NewSizePercent=20 -XX:G1ReservePercent=20 -XX:MaxGCPauseMillis=50 -XX:G1HeapRegionSize=32M").ToArray();
            argumentos = argumentos.Append(" -Dlog4j.configurationFile="+_argumentos.clientX_XML+ " net.minecraft.client.main.Main").ToArray();
            argumentos = argumentos.Append(" --userName "+_argumentos.UserName).ToArray();
            argumentos = argumentos.Append(" --version " +_argumentos.version).ToArray();
            argumentos = argumentos.Append(" --gameDir " + _argumentos.minecraftPath).ToArray();
            argumentos = argumentos.Append(" --assetsDir" + " " + _argumentos.minecraftPath + "\\assets\\").ToArray();
            argumentos = argumentos.Append(" --assetIndex" + _argumentos.assetIndex).ToArray();
            argumentos = argumentos.Append(" --uuid" + _argumentos.uuid).ToArray();
            argumentos = argumentos.Append(" --accessToken --userType msa").ToArray();
            argumentos = argumentos.Append(" --versionType " + _argumentos.tipoVersion).ToArray();
        }

        public class argumentos {
            public string javapath { get; set; }
            public string minecraftPath { get; set; }
            public string verWindows { get; set; }
            public string LauncherBrand { get; set; } 
            public string LauncherVersion { get;set; }
            
            //Ram Maxima
            public int Xmx { get; set; }
            
            //Ram Minima
            public int Xmn { get; set; }

            public List<Library> Librerias { get; set; }
            public string clientX_XML { get; set; }
            public string UserName { get; set; }
            public string version { get; set;  }
            public string tipoVersion { get; set; }
            public int assetIndex { get; set; }
            public string uuid { get; set; }
        }

    }
}
