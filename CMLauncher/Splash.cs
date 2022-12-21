using CMLauncher.Helper;
using CMLauncher.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using File = System.IO.File;

namespace CMLauncher
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            EsperaDeCargaPesada esperaDeCargaPesada = new EsperaDeCargaPesada();
            esperaDeCargaPesada.Callback1 += CargaAV;
            esperaDeCargaPesada.Start();
        }

        private void CargaAV(object sender, EsperaDeCarga esperaDeCarga)
        {
            Task cargar = Task.Run(() =>
            {
                StreamReader Lector;
                var uri = "https://launchermeta.mojang.com/mc/game/version_manifest.json";
                HttpWebRequest Solicitud = (HttpWebRequest)WebRequest.Create(uri);
                using (HttpWebResponse Respuesta = (HttpWebResponse)Solicitud.GetResponse())
                {
                    using (Stream Archivo = Respuesta.GetResponseStream())
                    {
                        Lector = new StreamReader(Archivo);
                        var PreJson = Lector.ReadToEnd();
                        if (File.Exists("versiones.json"))
                        {
                            string json = System.IO.File.ReadAllText("versiones.json");
                            if (PreJson == json)
                            {
                                Versiones = JsonConvert.DeserializeObject<descargas>(json);
                            }
                            else
                            {
                                StreamWriter file = new StreamWriter("versiones.json");
                                file.Write(PreJson);
                                file.Close();
                                Versiones = JsonConvert.DeserializeObject<descargas>(PreJson);
                            }
                        }
                        else
                        {
                            StreamWriter file = new StreamWriter("versiones.json");
                            file.Write(PreJson);
                            file.Close();
                            Versiones = JsonConvert.DeserializeObject<descargas>(PreJson);
                        }
                    }
                }
            }
            );
            cargar.Wait();
            inicio.temp = Versiones;

            inicio.Show();
            this.Hide();
            
        }

        private void Load_Load(object sender, EventArgs e)
        {
            barraDeCarga.Style = ProgressBarStyle.Marquee;
        }
        Inicio inicio = new Inicio();
        descargas Versiones = new descargas();

        private BackgroundWorker bw = new BackgroundWorker();

        private void Load_Shown(object sender, EventArgs e)
        {
            
            
        }
    }
}
