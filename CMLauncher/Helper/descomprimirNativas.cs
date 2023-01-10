using CMLauncher.Modelos;
using CMLauncher.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CMLauncher.Helper
{
    public class LibreriasNativas
    {
        public void descomprimirNativas(descargarVersion Version)
        {
            List<Library> Lib = new List<Library>();
            Settings settings = new Settings();
        volver:
            if (Directory.Exists(settings.minecraftPath + "versions\\" + Version.id + "\\natives\\"))
            {

                if (Directory.GetFiles(settings.minecraftPath + "versions\\" + Version.id + "\\natives\\").Length < 1)
                {
                    foreach (var librerias in Version.libraries)
                    {
                        if (librerias.name.Contains("windows"))
                        {
                            Lib.Add(librerias);
                        }
                    }
                    Directory.CreateDirectory("temp");
                    var directorioLibrerias = settings.minecraftPath + "libraries\\";
                    foreach (var lib in Lib)
                    {
                        var directorio = directorioLibrerias + lib.downloads.artifact.path.Replace("/", "\\");
                        ZipFile.ExtractToDirectory(directorio, "temp");
                    }
                    //foreach (var lib in Lib)
                    //{

                    //    ZipFile.ExtractToDirectory("", "");
                    //}
                }
            }
            else
            {
                Directory.CreateDirectory(settings.minecraftPath + Version.id + "\\natives\\");
                goto volver;
            }
        }
    }
}
