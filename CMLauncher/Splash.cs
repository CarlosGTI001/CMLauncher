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
            //habilitar estilos visuales para que la barra de progreso funcione en loop
            Application.EnableVisualStyles();
            //cargar un ayudante para las operaciones de segundo plano y poder ejecutar el splash de manera correcta
            EsperaDeCargaPesada esperaDeCargaPesada = new EsperaDeCargaPesada();
            //se agrega a traves de un evento la actividad a realizar
            esperaDeCargaPesada.Callback1 += CargaAV;
            //aca se inicia y se efectua
            esperaDeCargaPesada.Start();
        }
        descargas Versiones = new descargas();
        private void CargaAV(object sender, EsperaDeCarga esperaDeCarga)
        {
            Task cargar = Task.Run(() =>
            {
                try
                {
                    //lector para desplegar la respuesta del servidor con el json de las versiones
                    StreamReader Lector;
                    var uri = "https://launchermeta.mojang.com/mc/game/version_manifest.json";
                    //crear solicitud a partir del url anterior
                    HttpWebRequest Solicitud = (HttpWebRequest)WebRequest.Create(uri);
                    //implementar la respuesta de dicha Solicitud
                    using (HttpWebResponse Respuesta = (HttpWebResponse)Solicitud.GetResponse())
                    {
                        //leer toda la respuesta y ingresarlo en un stream para manejar el archivo temporal
                        using (Stream Archivo = Respuesta.GetResponseStream())
                        {
                            Lector = new StreamReader(Archivo);
                            //se lee toda la informacion del StreamReader para ingresarlo a una variable
                            var PreJson = Lector.ReadToEnd();
                            //ya que pienso almacenar los json en un archivo, para permitir jugabilidad sin conexion
                            //se preguntara primero si existe, el archivo se lee y se compara con la respuesta de la api
                            //en caso de no ser iguales significa que la api actualizo y descarga el archivo
                            if (File.Exists("versiones.json"))
                            {
                                string json = System.IO.File.ReadAllText("versiones.json");
                                if (PreJson == json)
                                {
                                    Versiones = JsonConvert.DeserializeObject<descargas>(json);
                                }
                                else
                                {
                                    //si no es igual, lo unico que hace es crearlo del json recibido de la api
                                    StreamWriter file = new StreamWriter("versiones.json");
                                    file.Write(PreJson);
                                    file.Close();
                                    Versiones = JsonConvert.DeserializeObject<descargas>(PreJson);
                                }
                            }
                            else
                            {
                                //aca indica en el caso de que no exista el archivo, se genera a partir de la respuesta del internet
                                StreamWriter file = new StreamWriter("versiones.json");
                                file.Write(PreJson);
                                file.Close();
                                Versiones = JsonConvert.DeserializeObject<descargas>(PreJson);
                            }
                        }
                    }
                }
                catch
                {
                    //si la conexion a internet falla tratara de leer si existe el json de versiones, si no existe
                    //devolvera null, este null indicara al form principal que debe mostrar una alerta para indicar al usuario que se debe conectar al internet.
                    if (File.Exists("versiones.json"))
                    {
                        string json = System.IO.File.ReadAllText("versiones.json");
                        if (string.IsNullOrEmpty(json))
                        {
                            Versiones = null;
                        }
                        else
                        {
                            Versiones = JsonConvert.DeserializeObject<descargas>(json);
                        }
                    }
                    else
                    {
                        Versiones = null;
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

    private BackgroundWorker bw = new BackgroundWorker();

    private void Load_Shown(object sender, EventArgs e)
    {


    }
}
}
