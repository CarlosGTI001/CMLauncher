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

namespace CMLauncher
{
    public partial class DownloadDialog : Form
    {
        public DownloadDialog()
        {
            InitializeComponent();
        }
        private async void MesaBox_Load(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            var url = "https://download.oracle.com/java/17/latest/jdk-17_windows-x64_bin.zip";
            if (File.Exists("java.zip"))
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
                            settings.javaPath = Path.GetFileName(dir) + "\\";
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
                    if(!Directory.Exists("runtime") || Directory.GetDirectories("runtime").Count() < 1)
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
                            settings.javaPath = dir;
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
                if(Directory.GetDirectories("runtime").Count() > 0)
                {
                    string[] carpetas = Directory.GetDirectories("runtime");
                    string directorio;
                    foreach(string dir in carpetas)
                    {
                        settings.javaPath = Path.GetFileName(dir);
                    }
                    //foreach (var m in Directory.GetDirectories("runtime"))
                    //{
                    //    m.ToString();
                    //}
                }

                settings.Save();
                this.DialogResult = DialogResult.OK;
            }
            settings.javaPath = Directory.GetCurrentDirectory() + "\\" + settings.javaPath;
            settings.Save();
            this.DialogResult = DialogResult.OK;

        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progresoLbl.Text = "Descargando : "+ byteToMB(e.BytesReceived) + " / " + byteToMB(e.TotalBytesToReceive);
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
    }
}
