using CMLauncher.Helper;
using CMLauncher.Modelos;
using CMLauncher.Properties;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
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
        
        string javapath;
        string minecraftPath;
        
        public Splash()
        {
            InitializeComponent();
            Settings settings = new Settings();
            if(settings.UUID == "")
            {
                settings.UUID = generador.UUID();
                settings.Save();
            }
            javapath = Environment.GetEnvironmentVariable("JAVA_HOME");
            //minecraftPath = settings.minecraftPath;
            minecraftPath = "D:\\.minecraft\\";
            //habilitar estilos visuales para que la barra de progreso funcione en loop
            Application.EnableVisualStyles();
            //cargar un ayudante para las operaciones de segundo plano y poder ejecutar el splash de manera correcta
            EsperaDeCargaPesada esperaDeCargaPesada = new EsperaDeCargaPesada();
            //se agrega a traves de un evento la actividad a realizar
            esperaDeCargaPesada.Callback1 += CargaAV;
            esperaDeCargaPesada.Callback2 += genCarpetas;
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
        public void genCarpetas(object sender, EsperaDeCarga esperaDeCarga)
        {
            Task generarCarpetas = Task.Run(() =>
            {
                if (Directory.Exists(minecraftPath))
                {
                    if (Directory.Exists(minecraftPath + "assets"))
                    {
                        if(!Directory.Exists(minecraftPath + "assets\\indexes"))
                        {
                            Directory.CreateDirectory(minecraftPath + "assets\\indexes");
                        }
                        if (!Directory.Exists(minecraftPath + "assets\\objects"))
                        {
                            Directory.CreateDirectory(minecraftPath + "assets\\objects");
                        }
                        if (!Directory.Exists(minecraftPath + "assets\\objects"))
                        {
                            Directory.CreateDirectory(minecraftPath + "assets\\objects");
                        }
                        if (!Directory.Exists(minecraftPath + "assets\\skins"))
                        {
                            Directory.CreateDirectory(minecraftPath + "assets\\skins");
                        }
                    }
                    else
                    {
                        Directory.CreateDirectory(minecraftPath + "assets");
                        Directory.CreateDirectory(minecraftPath + "assets\\indexes");
                        Directory.CreateDirectory(minecraftPath + "assets\\log_configs");
                        Directory.CreateDirectory(minecraftPath + "assets\\objects");
                        Directory.CreateDirectory(minecraftPath + "assets\\skins");
                    }
                    if (!Directory.Exists("libraries"))
                    {
                        Directory.CreateDirectory(minecraftPath + "libraries");
                    }

                    if (!Directory.Exists("logs"))
                    {
                        Directory.CreateDirectory(minecraftPath + "logs");
                    }

                    if (!Directory.Exists("resourcepacks"))
                    {
                        Directory.CreateDirectory(minecraftPath + "resourcepacks");
                    }

                    if (!Directory.Exists("saves"))
                    {
                        Directory.CreateDirectory(minecraftPath + "saves");
                    }

                    if (!Directory.Exists("screenshots"))
                    {
                        Directory.CreateDirectory(minecraftPath + "screenshots");
                    }

                    if (!Directory.Exists("versions"))
                    {
                        Directory.CreateDirectory(minecraftPath + "versions");
                    }
                }
                else
                {
                    Directory.CreateDirectory(minecraftPath);
                }
            });
        }
        private void Load_Load(object sender, EventArgs e)
        {
            barraDeCarga.Style = ProgressBarStyle.Marquee;
            if (javapath == null)
            {
                MessageBox.Show("Necesitas java para iniciar este launcher", "Alerta");
                Application.Exit();
            }
            else
            {

                //string ruta = "C:\\Users\\carlo\\AppData\\Roaming\\.minecraft\\versions\\1.19.3\\";
                //Process process = new Process();
                //process.EnableRaisingEvents = false;
                //process.StartInfo.FileName = "C:\\Program Files\\Java\\jre1.8.0_351" + "\\bin\\javaws.exe"; // aqui ponemos el programa que queremos ejecutar
                //process.StartInfo.Arguments = ruta + "1.19.3.jar";
                //process.Start();
            }
           
        }
        Inicio inicio = new Inicio();

        private BackgroundWorker bw = new BackgroundWorker();

        private void Load_Shown(object sender, EventArgs e)
        {


        }

        
    }
}
