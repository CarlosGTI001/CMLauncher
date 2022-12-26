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
        
        public static List<versionCarpeta> obtenerVersionesInstaladas()
        {
            Settings Settings = new Settings();
            generador.generarCarpetas();
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
                var carpeta = Path.Combine(Settings.minecraftPath, "versions", directorioVersion);
                var DirectoriosRevisar = Directory.GetFiles(carpeta);
                if(DirectoriosRevisar.Length > 1)
                {
                    var json = System.IO.File.ReadAllText(string.Format("{0}{1}.json", directorioVersion, version));
                        versionCarpetas.Add(new versionCarpeta
                        {
                            version = version,
                            carpeta = Directorios[i],
                            json = JsonConvert.DeserializeObject<descargarVersion>(json)
                        }
                    );
                }
            }
            return versionCarpetas;
        }

        static public string[] obtenerLibrerias(descargarVersion versionJSON)
        {
            List<Library> Librerias = versionJSON.libraries.Select(a => a).ToList<Library>();
            string[] librerias = new string[0];
            foreach(Library lib in Librerias)
            {
                librerias = librerias.Append(lib.downloads.artifact.path).ToArray();
            }
            return librerias;
        }

        public class versionCarpeta
        {
            public string version { get; set; }
            public string carpeta { get; set; }
            public descargarVersion json { get; set; }
        }
    }
}
