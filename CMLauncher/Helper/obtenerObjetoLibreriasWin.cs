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
using System.IO.Compression;
using System.Web.UI.WebControls.WebParts;
using static CMLauncher.Modelos.libreriasAnteriores;
using static System.Net.Mime.MediaTypeNames;

namespace CMLauncher.Helper
{
    public class LibWin
    {
        string[] librerias;
        public void descomprimirLibreriaNativas(List<Artifact> _artifact, string ver)
        {
            Settings settings = new Settings();
            var pa = Path.Combine(Directory.GetCurrentDirectory(), "temp");
            foreach (var artifact in _artifact)
            {
                var test = "temp\\" + artifact.path.Split('/')[artifact.path.Split('/').Length - 1];
                librerias = Directory.GetFiles(pa);
                if (Directory.Exists("temp"))
                {
                    if (!System.IO.File.Exists(test))
                        descargarLib2(artifact.url, test);
                    librerias = Directory.GetFiles(pa);
                }
                else
                {
                    Directory.CreateDirectory("temp");
                    if (!System.IO.File.Exists(test))
                        descargarLib2(artifact.url, test);
                }
            }
            var directorioNativo = Path.Combine(settings.minecraftPath, "versions\\" + ver + "\\natives");
            if (Directory.Exists(directorioNativo))
            {
                Directory.Delete(directorioNativo, true);
                Directory.CreateDirectory(directorioNativo);
            }
            var numero = 1;
            foreach (var lib in librerias)
            {
                var dir = lib.Replace(".jar", ".zip").Split('/');
                var zip = dir[dir.Length - 1];
                System.IO.File.Move(lib, zip);
                try
                {
                    if (Directory.Exists(directorioNativo + "\\META-INF"))
                    {
                        Directory.Delete(directorioNativo + "\\META-INF", true);
                        ZipFile.ExtractToDirectory(zip, directorioNativo);
                    }
                    else
                    {
                        ZipFile.ExtractToDirectory(zip, directorioNativo);
                    }
                }
                catch(Exception e)
                {
                    var mensaje = e.Message;
                    
                }
                numero++;
            }
        }



        public void obtenerLibreriasNativas(string json){
            if (Directory.Exists("temp"))
            {
                Directory.Delete("temp", true);
                Directory.CreateDirectory("temp");
                var obj = JsonConvert.DeserializeObject<dynamic>(json);
                //var classs = obj["libraries"]["clasifiers"];
                var other = obj.libraries;
                string[] Librerias = new string[0];
                List<Modelos.Artifact> LibraryWindows = new List<Modelos.Artifact>();
                int _librerias = 0;
                foreach (var lib in other)
                {
                    int contador = 0;
                    int clasifier = 0;
                    int libp = 0;
                    foreach (var _lib in lib.downloads)
                    {
                        
                            
                            try
                            {

                                foreach (var _class in _lib)
                                {

                                    var classe = _class["natives-windows"];
                                    if (classe != null)
                                    {
                                        var url = classe["url"].ToString();
                                        var test = "temp\\" + classe["path"].ToString().Split('/')[classe["path"].ToString().Split('/').Length - 1];
                                        descargarLib2(url, test);
                                        contador++;
                                    }

                                }

                            }
                            catch
                            {

                            }
                    }
                    if (contador > 0)
                    {
                        try
                        {
                            var libW = lib["downloads"]["classifiers"];
                            int contador2 = 0;
                            foreach (var l in libW)
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
                                _librerias++;
                            }
                        }
                        catch (Exception e)
                        {

                        }
                    }
                    else
                    {
                        var Art = JsonConvert.DeserializeObject<descargarVersion>(json);
                        
                        foreach (var a in Art.libraries.Select(a => a.downloads.artifact).Where(a => a.path.Contains("natives-windows")))
                        {
                            var test = "temp\\" + a.path.Split('/')[a.path.Split('/').Length - 1];
                            descargarLib2(a.url, test);
                        }
                    }
                }
                Settings settings = new Settings();
                foreach (var art in LibraryWindows)
                {
                    var directorioNativo = Path.Combine(settings.minecraftPath, "versions\\" + obj.id.ToString() + "\\natives");
                    string[] cantidadLib = Directory.GetFiles(directorioNativo);
                    if (cantidadLib.Length <= _librerias * 3 + 1)
                    {
                        descargarLib(art.url, art.path);
                    }

                }
                var pa = Path.Combine(Directory.GetCurrentDirectory(), "temp");
                librerias = Directory.GetFiles(pa);
                try
                {
                    descomprimirLibreriaNativas(LibraryWindows, obj.id.ToString());
                }
                catch
                {

                }
            }
            else
            {
                Directory.CreateDirectory("temp");
                var obj = JsonConvert.DeserializeObject<dynamic>(json);
                //var classs = obj["libraries"]["clasifiers"];
                var other = obj.libraries;
                string[] Librerias = new string[0];
                List<Artifact> LibraryWindows = new List<Artifact>();
                int _librerias = 0;
                foreach (var lib in other)
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
                            foreach (var l in libW)
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
                                _librerias++;
                            }
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                Settings settings = new Settings();
                foreach (var art in LibraryWindows)
                {
                    var directorioNativo = Path.Combine(settings.minecraftPath, "versions\\" + obj.id.ToString() + "\\natives");
                    string[] cantidadLib = Directory.GetFiles(directorioNativo);
                    if (cantidadLib.Length <= _librerias)
                    {
                        descargarLib(art.url, art.path);
                    }
                }
                var pa = Path.Combine(Directory.GetCurrentDirectory(), "temp");
                librerias = Directory.GetFiles(pa);
                descomprimirLibreriaNativas(LibraryWindows, obj.id.ToString());
                foreach (var limpiar in librerias)
                {
                    System.IO.File.Delete(limpiar.Replace(".jar", ".zip"));
                }
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
