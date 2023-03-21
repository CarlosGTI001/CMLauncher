using CMLauncher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMLauncher.Modelos;
using Newtonsoft.Json;

namespace CMLauncher
{
    public partial class DownloadDialog : Form
    {
        public DownloadDialog()
        {
            InitializeComponent();
        }
        int archivos;
        int i = 0;
        public void descargar()
        {
            //WebClient webClient = new WebClient();
            //var json = webClient.DownloadString("https://launchermeta.mojang.com/v1/products/java-runtime/2ec0cc96c44e5a76b9c8b7c39df7210883d12871/all.json");

            //var java = JsonConvert.DeserializeObject<java>(json);
            //var urlVersion = "";
            //foreach (var e in java.windowsx64.javaruntimealpha)
            //{
            //    urlVersion = e.manifest.url;
            //}

            //var json2 = webClient.DownloadString(urlVersion);

            //var javaVersion = JsonConvert.DeserializeObject<dynamic>(json2);
            //string[] files = new string[0];
            //var Path = "";
            //var j = javaVersion;
            //if (!Directory.Exists("java"))
            //{
            //    Directory.CreateDirectory("java");
            //}
            //List<Item> Files = new List<Item>();
            //foreach (var a in j.files)
            //{
            //    if (a.First.type == "directory")
            //    {
            //        Item it = new Item();
            //        it.type = a.First.type;
            //        it.path = a.Name;
            //        Console.WriteLine(a.Name);
            //        string dir = a.Name;
            //        Files.Add(it);
            //    }
            //    if (a.First.type == "file")
            //    {
            //        Item it = new Item();
            //        Console.WriteLine("|--" + a.Name);
            //        it.url = a.First.downloads.raw.url;
            //        it.path = @"java\" + a.Name;
            //        it.type = a.First.type;
            //        Files.Add(it);
            //    }
            //}

            //i = 0;
            //backgroundWorker1.ReportProgress(i);
            //archivos = Files.Count();
            //foreach (var items in Files)
            //{
            //    if(items.type == "file")
            //    {
            //        Byte[] fileData;
            //        if (!System.IO.File.Exists(items.path))
            //        {
            //            using (WebClient client = new WebClient())
            //            {
            //                fileData = client.DownloadData(items.url);
            //            }
            //            using (FileStream fs = new FileStream(items.path.Replace("/", "\\"), FileMode.Create))
            //            {
            //                foreach (byte b in fileData)
            //                {
            //                    fs.WriteByte(b);
            //                }
            //                fs.Close();
            //            }
            //        }
            //        backgroundWorker1.ReportProgress(i);
            //        i++;
            //    }
            //    else
            //    {
            //        Directory.CreateDirectory(@"java\" + items.path.Replace(@"/", @"\"));
            //        backgroundWorker1.ReportProgress(i);
            //        i++;
            //    }
                
            //}
            //Settings settings = new Settings();
            //settings.javaPath = Directory.GetCurrentDirectory() + "\\java\\";
            //settings.Save();
            //this.DialogResult = DialogResult.OK;
            //this.Close();
        }

        private async void MesaBox_Load(object sender, EventArgs e)
        {
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerAsync();
            Settings settings = new Settings();
            var url = "https://download.oracle.com/java/17/latest/jdk-17_windows-x64_bin.zip";
            if (System.IO.File.Exists("java.zip"))
            {
                var tamaño = GetFileSize(url);
                FileInfo infoArchivo = new FileInfo("java.zip");
                if (infoArchivo.Length < tamaño)
                {
                    using (WebClient client = new WebClient())
                    {
                        // Habilitamos la opción de "descarga resumible"
                        client.Headers.Add("Accept-Ranges", "bytes");

                        // Establecemos el evento que se disparará cada vez que se descargue un trozo del archivo
                        client.DownloadProgressChanged += Client_DownloadProgressChanged;

                        // Descargamos el archivo
                        await client.DownloadFileTaskAsync(new Uri(url), "java.zip");
                    }
                    ZipFile.ExtractToDirectory("java.zip", "runtime");
                    if (Directory.GetDirectories("runtime").Count() > 0)
                    {
                        string[] carpetas = Directory.GetDirectories("runtime");
                        string directorio;
                        foreach (string dir in carpetas)
                        {
                            settings.javaPath = Directory.GetCurrentDirectory() + "\\" + dir;
                        }
                        //foreach (var m in Directory.GetDirectories("runtime"))
                        //{
                        //    m.ToString();
                        //}
                    }
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    if (!Directory.Exists("runtime") || Directory.GetDirectories("runtime").Count() < 1)
                    {
                        ZipFile.ExtractToDirectory("java.zip", "runtime");
                        this.DialogResult = DialogResult.OK;
                    }
                    if (Directory.GetDirectories("runtime").Count() > 0)
                    {
                        string[] carpetas = Directory.GetDirectories("runtime");
                        string directorio;
                        foreach (string dir in carpetas)
                        {
                            settings.javaPath = Directory.GetCurrentDirectory() + "\\" + dir;
                        }
                        //foreach (var m in Directory.GetDirectories("runtime"))
                        //{
                        //    m.ToString();
                        //}
                    }
                    this.DialogResult = DialogResult.OK;
                }
            }
            else
            {
                using (WebClient client = new WebClient())
                {
                    // Habilitamos la opción de "descarga resumible"
                    client.Headers.Add("Accept-Ranges", "bytes");

                    // Establecemos el evento que se disparará cada vez que se descargue un trozo del archivo
                    client.DownloadProgressChanged += Client_DownloadProgressChanged;

                    // Descargamos el archivo
                    await client.DownloadFileTaskAsync(new Uri(url), "java.zip");
                }

                //descomprimir java
                ZipFile.ExtractToDirectory("java.zip", "runtime");
                if (Directory.GetDirectories("runtime").Count() > 0)
                {
                    string[] carpetas = Directory.GetDirectories("runtime");
                    string directorio;
                    foreach (string dir in carpetas)
                    {
                        settings.javaPath = Directory.GetCurrentDirectory() + "\\" + dir;
                    }
                    //foreach (var m in Directory.GetDirectories("runtime"))
                    //{
                    //    m.ToString();
                    //}
                }

                settings.Save();
                this.DialogResult = DialogResult.OK;
            }
            settings.Save();
            this.DialogResult = DialogResult.OK;

        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progresoLbl.Text = "Descargando : " + byteToMB(e.BytesReceived) + " / " + byteToMB(e.TotalBytesToReceive);
            descargaProgreso.Value = e.ProgressPercentage;
        }

        public double byteToMB(long bytes)
        {
            double MB = ((double)bytes / 1024) / 1024;
            MB = Math.Round(MB, 2);
            return MB;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private long GetFileSize(string url)
        {
            // Creamos una solicitud HTTP de tipo HEAD
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "HEAD";

            // Enviamos la solicitud y obtenemos la respuesta del servidor
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                // Obtenemos el tamaño del archivo a partir de la respuesta del servidor
                return response.ContentLength;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            descargar();
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            descargaProgreso.Maximum = archivos;
            descargaProgreso.Minimum = 0;
            progresoLbl.Text = "Descargando: " + i + " de " + archivos + " Archivos...";
            descargaProgreso.Value = i;
        }
    }
}
