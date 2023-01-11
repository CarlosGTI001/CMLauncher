using CMLauncher.Modelos;
using CMLauncher.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static CMLauncher.Modelos.libreriasAnteriores;

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
            var directorioNativo = Path.Combine(Settings.minecraftPath, "versions\\" + _argumentos.version + "\\natives");
            argumentos = argumentos.Append(@" -Djava.library.path="+ directorioNativo).ToArray();
            argumentos = argumentos.Append(" -Dminecraft.launcher.brand="+ _argumentos.LauncherBrand).ToArray();
            argumentos = argumentos.Append(" -Dminecraft.launcher.version=" + _argumentos.LauncherVersion).ToArray();
            argumentos = argumentos.Append(" -cp ").ToArray();
            var libreriaAnterior = "";
            var lib = new string[0];
            var directorios = new string[0];
            foreach (Modelos.Library library in _argumentos.Librerias)
            {
                if(!library.downloads.artifact.path.Contains("linux") )
                {
                    if (!library.downloads.artifact.path.Contains("macos"))
                    {
                            var temp = (carpetaLibreria + library.downloads.artifact.path + ";").Replace('/', '\\').ToArray();
                            libreriaAnterior = (carpetaLibreria + library.downloads.artifact.path + ";").Replace('/', '\\');
                        if (!library.downloads.artifact.path.Contains("natives"))
                        {
                            lib = lib.Append(library.name).ToArray();
                        }
                    }
                }
            }
            Dictionary<string, string> libr = new Dictionary<string, string>();
            var i = 0;
            foreach (var l in lib)
            {
                var div = l.Split(':');
                var ver = div[div.Length - 1];
                libr.Add(l, ver);
                i++;
            }
            var libAnterior = "";
            var verAnterior = "";
            Dictionary<string, string> libK = new Dictionary<string, string>();
            foreach (var s in libr)
            {
                if(s.Key.Split(':').Length == 3)
                    
                    if (libAnterior == s.Key.Split(':')[0] + ':' + s.Key.Split(':')[1])
                    {
                        if (s.Value.CompareTo(verAnterior) > 0)
                        {
                            libK.Add(s.Key, s.Value);
                            libK = libK.Where(a => a.Value != verAnterior).ToDictionary(k=>k.Key, k=>k.Value); 
                        }
                    }
                    else
                    {
                        libK.Add(s.Key, s.Value); 
                    }
                else
                    libK.Add(s.Key, s.Value);
                libAnterior = s.Key.Split(':')[0] + ':' + s.Key.Split(':')[1];
                verAnterior = s.Value;
            }
            int f = 0;
            foreach(var s in libK)
            {
                var dir = "";
                foreach(var m in _argumentos.Librerias)
                {
                    if(m.name == s.Key)
                    {
                        dir = m.name;
                        argumentos = argumentos.Append((carpetaLibreria + m.downloads.artifact.path + ";").Replace('/', '\\')).ToArray();
                    }
                }
            }
            //remover el .jar y splite por - y \
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

            public List<Modelos.Library> Librerias { get; set; }
            public string gameJar { get; set; }
            public string UserName { get; set; }
            public string version { get; set;  }
            public string tipoVersion { get; set; }
            public string assetIndex { get; set; }
            public string uuid { get; set; }
        }

    }
}
