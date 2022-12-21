using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Web;
using System.Net.Http;
using System.Security.Policy;
using System.IO;
using CMLauncher.Modelos;
using System.Net;
using File = System.IO.File;
using static System.Net.WebRequestMethods;

namespace CMLauncher
{
    public partial class Inicio : Form
    {
        private int ex;
        private int ey;
        public string directorioTrabajo = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public bool Arrastre { get; private set; }
        public descargas temp { get; set; }
        public Inicio()
        {
            InitializeComponent();
        }
    HttpClient httpClient = new HttpClient();
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }


        private void Inicio_Load(object sender, EventArgs e)
        {
            Form form1 = this;
            
                //cargar url en el webview novedades
                //this.Invoke(new MethodInvoker(()=> novedades.Source = new Uri("https://www.minecraft.net/es-es")));
                if (temp != null)
                {
                    versionesCbx.DataSource = temp.versions;
                    versionesCbx.SelectedIndex = 0;
                    versionesCbx.ValueMember = "url";
                    versionesCbx.DisplayMember = "id";
                }
        }

        public void cargar()
        {
            //cargar url en el webview novedades
            //novedades.Source = new Uri("https://www.minecraft.net/es-es");
            temp = obtenerVersiones();
            if (temp != null)
            {
                versionesCbx.DataSource = temp.versions;
                versionesCbx.SelectedIndex = 0;
                versionesCbx.ValueMember = "url";
                versionesCbx.DisplayMember = "id";
            }
        }

        private void Inicio_Shown(object sender, EventArgs e)
        {
            
        }

        public descargas obtenerVersiones()
        {
            try
            {

                StreamReader reader;
                var uri = "https://launchermeta.mojang.com/mc/game/version_manifest.json";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                {
                    reader = new StreamReader(stream);
                    var read = reader.ReadToEnd();
                    if (File.Exists("versiones.json"))
                    {
                        string json = System.IO.File.ReadAllText("versiones.json");
                        if (read == json)
                        {
                            return JsonConvert.DeserializeObject<descargas>(json);
                        }
                        else
                        {
                            StreamWriter file = new StreamWriter("versiones.json");
                            file.Write(read);
                            file.Close();
                            return JsonConvert.DeserializeObject<descargas>(read);
                        }
                    }
                    else
                    {
                        StreamWriter file = new StreamWriter("versiones.json");
                        file.Write(read);
                        file.Close();
                        return JsonConvert.DeserializeObject<descargas>(read);
                    }
                }
            }
            catch
            {
                if (File.Exists("versiones.json"))
                {
                    string json = System.IO.File.ReadAllText("versiones.json");
                    if (string.IsNullOrEmpty(json)) 
                    {
                        return null;
                    }
                    else
                    {
                        return JsonConvert.DeserializeObject<descargas>(json);
                    }
                }
                else
                {
                    return null;
                }
            }
        }



        public descargarVersion obtenerUnaVersion(Uri uri)
        {
            HttpWebRequest solicitud = (HttpWebRequest)WebRequest.Create(uri);
            using (HttpWebResponse response = (HttpWebResponse)solicitud.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                //string json = "[";
                //json = json + reader.ReadToEnd();
                //json = json + "]";
                return JsonConvert.DeserializeObject<descargarVersion>(json);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void arrastrar_MouseDown(object sender, MouseEventArgs e)
        {
            ex = e.X;
            ey = e.Y;
            Arrastre = true;
        }

        private void arrastrar_MouseMove(object sender, MouseEventArgs e)
        {
            if (Arrastre == true)
            {
                Location = PointToScreen(
                    new Point(
                            MousePosition.X - Location.X - ex, MousePosition.Y - Location.Y - ey
                        )
                    );
            }
        }

        private void arrastrar_MouseUp(object sender, MouseEventArgs e)
        {
            Arrastre = false;
        }

        //private void novedades_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        //{

        //}

        private void jugarMC_Click(object sender, EventArgs e)
        {
            //si existe la version entonces cambia a jugar, de lo contrario Cambia
            var version = obtenerUnaVersion(new Uri(versionesCbx.SelectedValue.ToString()));
            //string comandos = "";
            //foreach(object objeto in version.arguments.jvm)
            //{
            //    comandos = comandos + objeto.ToString() + "\n";
            //}
            //MessageBox.Show(comandos);
            //string game = null;
            //foreach (object objeto in version.arguments.game)
            //{
            //    game = game + objeto.ToString() + "\n";
            //}
            //MessageBox.Show(game);
            var archivo = version.downloads.client.file.url;
        }

        private void arrastrar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Inicio_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Inicio_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Inicio_Deactivate(object sender, EventArgs e)
        {

        }
    }
}
