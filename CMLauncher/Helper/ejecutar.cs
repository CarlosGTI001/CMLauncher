using CMLauncher.Modelos;
using CMLauncher.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMLauncher.Helper
{
    public class Minecraft
    {
        Settings Settings = new Settings();
        public string ejecutar(argumentos _argumentos)
        {
            var log_configs = Directory.GetFiles(Settings.minecraftPath + "assets\\log_configs");
            string carpetaLibreria = Settings.minecraftPath + "libraries\\";
            string[] argumentos = new string[0];
            argumentos = argumentos.Append("-XX:HeapDumpPath=MojangTricksIntelDriversForPerformance_javaw.exe_minecraft.exe.heapdump \"-Dos.name=Windows 10\"").ToArray();
            argumentos = argumentos.Append(" -Dos.version="+ _argumentos.verWindows).ToArray();
            argumentos = argumentos.Append(" -Xss1M").ToArray();
            argumentos = argumentos.Append(" -Dminecraft.launcher.brand="+ _argumentos.LauncherBrand).ToArray();
            argumentos = argumentos.Append(" -Dminecraft.launcher.version=" + _argumentos.LauncherVersion).ToArray();
            argumentos = argumentos.Append(" -cp ").ToArray();
            foreach (Library library in _argumentos.Librerias)
            {
                if(!library.downloads.artifact.path.Contains("linux") )
                {
                    if (!library.downloads.artifact.path.Contains("macos"))
                    {
                        argumentos = argumentos.Append((carpetaLibreria + library.downloads.artifact.path + ";").Replace('/', '\\')).ToArray();
                    }
                }
            }
            argumentos = argumentos.Append(_argumentos.gameJar).ToArray();
            argumentos = argumentos.Append(" -Xmx" + _argumentos.Xmx + "M").ToArray();
            argumentos = argumentos.Append(" -Xmn" + _argumentos.Xmn + "M").ToArray();
            argumentos = argumentos.Append(" -XX:+UnlockExperimentalVMOptions").ToArray();
            argumentos = argumentos.Append(" -XX:+UseG1GC -XX:G1NewSizePercent=20 -XX:G1ReservePercent=20 -XX:MaxGCPauseMillis=50 -XX:G1HeapRegionSize=32M").ToArray();
            argumentos = argumentos.Append(" -Dlog4j.configurationFile=" + log_configs[0] + " net.minecraft.client.main.Main").ToArray();
            argumentos = argumentos.Append(" --username "+_argumentos.UserName).ToArray();
            argumentos = argumentos.Append(" --version " +_argumentos.version).ToArray();
            argumentos = argumentos.Append(" --gameDir " + _argumentos.minecraftPath).ToArray();
            argumentos = argumentos.Append(" --assetsDir " + _argumentos.minecraftPath + "assets\\").ToArray();
            argumentos = argumentos.Append(" --assetIndex " + _argumentos.assetIndex).ToArray();
            argumentos = argumentos.Append(" --uuid " + _argumentos.uuid).ToArray();
            argumentos = argumentos.Append(" --accessToken --userType msa").ToArray();
            var __arg = argumentos.Append(" --versionType " + _argumentos.tipoVersion).ToArray();
            
            var comando = "";
            foreach(var argumento in __arg)
            {
                comando = comando + argumento.ToString();
            }
            return comando;
        }

        static public void ExecuteCommand(string _Command)
        {
            //Indicamos que deseamos inicializar el proceso cmd.exe junto a un comando de arranque. 
            //(/C, le indicamos al proceso cmd que deseamos que cuando termine la tarea asignada se cierre el proceso).
            //Para mas informacion consulte la ayuda de la consola con cmd.exe /? 
            System.Diagnostics.ProcessStartInfo procStartInfo = new System.Diagnostics.ProcessStartInfo("cmd", _Command);
            // Indicamos que la salida del proceso se redireccione en un Stream
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            //Indica que el proceso no despliegue una pantalla negra (El proceso se ejecuta en background)
            procStartInfo.CreateNoWindow = false;
            //Inicializa el proceso
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo = procStartInfo;
            proc.Start();
            //Consigue la salida de la Consola(Stream) y devuelve una cadena de texto
            string result = proc.StandardOutput.ReadToEnd();
            //Muestra en pantalla la salida del Comando
            Console.WriteLine(result);
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
            public string gameJar { get; set; }
            public string UserName { get; set; }
            public string version { get; set;  }
            public string tipoVersion { get; set; }
            public string assetIndex { get; set; }
            public string uuid { get; set; }
        }

    }
}
