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

namespace CMLauncher
{
    public partial class Inicio : Form
    {
        private int ex;
        private int ey;

        public bool Arrastre { get; private set; }

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
            //cargar url en el webview novedades
            novedades.Source = new Uri("https://www.minecraft.net/es-es");
            var listadoPrincipal = obtenerVersiones();
            versionesCbx.DataSource = listadoPrincipal.versions;
            versionesCbx.SelectedIndex = 0;
            versionesCbx.ValueMember = "id";
            versionesCbx.DisplayMember = "id";
            
        }

        public descargas obtenerVersiones()
        {
            var uri = "https://launchermeta.mojang.com/mc/game/version_manifest.json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                //string json = "[";
                //json = json + reader.ReadToEnd();
                //json = json + "]";
                descargas desc = JsonConvert.DeserializeObject<descargas>(json);
                return desc;
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
            if(Arrastre == true)
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

        private void novedades_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            
        }

        private void jugarMC_Click(object sender, EventArgs e)
        {
            //si existe la version entonces cambia a jugar, de lo contrario Cambia
        }

        private void arrastrar_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
