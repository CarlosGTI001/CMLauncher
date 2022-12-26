using CMLauncher.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection;
using System.Windows.Markup;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.IO;

namespace CMLauncher.Helper
{
    public class Descargar
    {
        public List<ArchivosAsset> ObtenerIndexAsset(string version, descargarVersion descargarVersion, string minecraftPath)
        {
            var url = descargarVersion.assetIndex.url;
            WebClient webClient = new WebClient();
            var json = webClient.DownloadString(url);
            json = json.Replace("{\"objects\": {", "{\"objects\": [{");
            json = json.Replace("},", "}},{");
            json = json.Replace("}}}", "}}]}");
            var guia = new Regex("\"hash\"[^\"]*\"[A-Za-z0-9]+\"[^\"]*\"size\": [0-9]+", RegexOptions.IgnoreCase);
            MatchCollection matches = guia.Matches(json);
            var filtro1 = "";
            foreach (Match match in matches)
            {
                filtro1 = filtro1 + "{ " + match.Value + " },";
            }
            matches = null;
            webClient = null;
            guia = null;
            descargarVersion = null;
            GC.Collect();
            filtro1 = "[" + filtro1 + "]";
            filtro1 = filtro1.Replace(",]", "]");
            var archivos = JsonConvert.DeserializeObject<List<ArchivosAsset>>(filtro1);
            filtro1 = null;
            //var guia2 = new Regex("\"hash\"[^\"]*\"[A-Za-z0-9]+\"[^\"]*\"size\": [0-9]+", RegexOptions.IgnoreCase);
            //MatchCollection matches2 = guia2.Matches(filtro1);
            //var filtro2 = "";
            //foreach(Match match in matches2)
            //{
            //    filtro2 = " " + match.Value;
            //}
            //var code =  json.Select(a => a.ToString()).ToList<string>();
            //var objeto = JsonConvert.DeserializeObject(json);
            //objeto;
            return archivos;
        }

        public class ArchivosAsset
        {
            public string hash;
            public int size;
        }

        public void Assets()
        {

        }

        public void Libraries()
        {

        }

        public void Version()
        {

        }
    }
}
