using CMLauncher.Modelos;
using CMLauncher.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMLauncher.Helper
{
    static class administradorVersiones
    {
        static Settings Settings = new Settings();
        public static List<versionCarpeta> obtenerVersionesInstaladas()
        {
            string[] verificarVersiones;
            var path = Path.Combine(Settings.minecraftPath, "versions");
            var Directorios = Directory.GetDirectories(path);
            List<versionCarpeta> versionCarpetas = new List<versionCarpeta>();
            //descargarVersion descargarVersion = new descargarVersion();
            string[] versionesDisponibles = new string[0];
            
            for (var i = 0; i < Directorios.Length; i++)
            {
                var version = Directorios[i].Split('\\')[7];
                var directorioVersion = Directorios[i] + "\\";
                var json = System.IO.File.ReadAllText(string.Format("{0}{1}.json", directorioVersion, version));
                    versionCarpetas.Add(new versionCarpeta {
                        version = version,
                        carpeta = Directorios[i],
                        json = JsonConvert.DeserializeObject<descargarVersion>(json)
                    }
                );
            }
            return versionCarpetas;
        }


        public class versionCarpeta{
            public string version { get; set; }
            public string carpeta { get; set; }
            public descargarVersion json { get; set; }
        }
    }
}
