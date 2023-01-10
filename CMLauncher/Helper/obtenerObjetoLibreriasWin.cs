using CMLauncher.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CMLauncher.Properties;
using System.IO;
using System.Net;

namespace CMLauncher.Helper
{
    public class LibWin
    {
        public void descomprimirLibreriaNativas(Artifact artifact)
        {
            Settings settings = new Settings();
            var jar = artifact.path;
            var dll = jar.Replace(".jar", ".dll");
            var test = "temp\\" + artifact.path.Split('/')[artifact.path.Split('/').Length - 1];
            if (Directory.Exists("temp"))
            {
                if (!System.IO.File.Exists(test))
                    descargarLib2(artifact.url, test);
            }
            else
            {
                Directory.CreateDirectory("temp");
                if(!System.IO.File.Exists("temp\\" + artifact.path.Split('\\')[artifact.path.Split('\\').Length - 1]))
                    descargarLib2(artifact.url, artifact.path.Split('\\')[artifact.path.Split('\\').Length - 1]);
            }
            var librerias = Directory.GetFiles(test);
            foreach(var lib in librerias)
            {
                System.IO.File.Move(lib, lib.Replace(".jar", ".zip"));
            }
        }
        public void obtenerLibreriasNativas(string json){
            var obj = JsonConvert.DeserializeObject<dynamic>(json);
            //var classs = obj["libraries"]["clasifiers"];
            var other = obj.libraries;
            string[] Librerias = new string[0];
            List<Artifact> LibraryWindows = new List<Artifact>();
            
            foreach(var lib in other)
            {
                int contador = 0;
                foreach (var _lib in lib.downloads)
                {
                    contador++;
                }
                if (contador > 1)
                {
                    try
                    {
                        var libW = lib["downloads"]["classifiers"];
                        int contador2 = 0;
                        foreach(var l in libW)
                        {
                            contador2++;
                        }
                        if (contador2 > 1)
                        {
                            var winLib = libW["natives-windows"];
                            string url = winLib.url;
                            string path = winLib.path;
                            LibraryWindows.Add(new Artifact
                            {
                                url = url,
                                path = path,
                                size = winLib.size,
                                sha1 = winLib.sha1
                            });
                        }
                    }
                    catch(Exception e) { 
                    
                    }
                }
            }
            foreach (var art in LibraryWindows)
            {
                descargarLib(art.url, art.path);
                descomprimirLibreriaNativas(art);
            }
        }

        private void descargarLib(string url, string path)
        {
            Settings settings = new Settings();
            byte[] fileData;

            var pathDividido = path.Split('/');
            var archivo = pathDividido[pathDividido.Length - 1];
            var pathTemporal = "";
            var i = 0;
            foreach (string _path in pathDividido)
            {
                if (i < pathDividido.Length - 1)
                {
                    if (Directory.Exists(settings.minecraftPath + "libraries\\" + pathTemporal + _path))
                    {
                        pathTemporal += _path + "\\";
                        i++;
                        continue;
                    }
                    else
                    {
                        var carpeta = settings.minecraftPath + "libraries\\" + pathTemporal + _path;
                        Directory.CreateDirectory(carpeta);
                    }
                    pathTemporal += _path + "\\";
                    i++;
                }
                else
                {
                    continue;
                }
            }
            var pasarArchivo = settings.minecraftPath + "libraries\\" + pathTemporal + archivo;
            if (!System.IO.File.Exists(pasarArchivo))
            {
                using (WebClient client = new WebClient())
                {
                    fileData = client.DownloadData(url);
                }
                using (FileStream fs = new FileStream(pasarArchivo, FileMode.Create))
                {
                    foreach (byte b in fileData)
                    {
                        fs.WriteByte(b);
                    }
                    fs.Close();
                }
            }
        }

        private void descargarLib2(string url, string path)
        {
            Settings settings = new Settings();
            byte[] fileData;

            //var pathDividido = path.Split('/');
            //var archivo = pathDividido[pathDividido.Length - 1];
            //var pathTemporal = "";
            //var i = 0;
            //foreach (string _path in pathDividido)
            //{
            //    if (i < pathDividido.Length - 1)
            //    {
            //        if (Directory.Exists(settings.minecraftPath + "libraries\\" + pathTemporal + _path))
            //        {
            //            pathTemporal += _path + "\\";
            //            i++;
            //            continue;
            //        }
            //        else
            //        {
            //            var carpeta = settings.minecraftPath + "libraries\\" + pathTemporal + _path;
            //            Directory.CreateDirectory(carpeta);
            //        }
            //        pathTemporal += _path + "\\";
            //        i++;
            //    }
            //    else
            //    {
            //        continue;
            //    }
            //}
            //var pasarArchivo = settings.minecraftPath + "libraries\\" + pathTemporal + archivo;
            if (!System.IO.File.Exists(path))
            {
                using (WebClient client = new WebClient())
                {
                    fileData = client.DownloadData(url);
                }
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    foreach (byte b in fileData)
                    {
                        fs.WriteByte(b);
                    }
                    fs.Close();
                }
            }
        }
    }

    
}
