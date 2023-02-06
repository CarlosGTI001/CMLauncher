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
using System.Management;
using static CMLauncher.Helper.administradorVersiones;
using System.Drawing.Drawing2D;

namespace CMLauncher
{
    public partial class Splash : Form
    {
        

        private int borderRadius = 20;
        private int borderSize = 2;
        private Color borderColor = Color.FromArgb(31, 31, 31);
        private Color bttonColor = Color.FromArgb(59, 133, 38);

        public Splash()
        {
            InitializeComponent();
            Settings settings = new Settings();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.BackColor = borderColor;
            var str = Environment.GetEnvironmentVariable("JAVA_HOME");
            if (settings.UUID == "")
            {
                settings.UUID = generador.UUID();
                
            }
            if (string.IsNullOrEmpty(settings.javaPath) && !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("JAVA_HOME")))
            {
                settings.javaPath = Environment.GetEnvironmentVariable("JAVA_HOME");
                var m = settings.javaPath;
                if (!Directory.Exists(settings.javaPath))
                {
                    settings.javaPath = "";
                }
            }
            else
            {
                if(!Directory.Exists(settings.javaPath))
                {
                    settings.javaPath = "";
                }
            }

            if (string.IsNullOrEmpty(settings.minecraftPath) || settings.minecraftPath == "null")
            {
                
                settings.minecraftPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    ".minecraft\\"
                );
                if (!Directory.Exists(settings.minecraftPath))
                {
                    Directory.CreateDirectory(settings.minecraftPath);
                }
            }
            settings.Save();
            //administradorVersiones.obtenerVersionesInstaladas();
            //minecraftPath = settings.minecraftPath;
            //habilitar estilos visuales para que la barra de progreso funcione en loop
            Application.EnableVisualStyles();
            //cargar un ayudante para las operaciones de segundo plano y poder ejecutar el splash de manera correcta
            //EsperaDeCargaPesada esperaDeCargaPesada = new EsperaDeCargaPesada();
            ////se agrega a traves de un evento la actividad a realizar
            //esperaDeCargaPesada.Callback1 += CargaAV;
            //esperaDeCargaPesada.Callback2 += genCarpetas;
            ////aca se inicia y se efectua
            //esperaDeCargaPesada.Start();

        }


        private GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void FormRegionAndBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(form.ClientRectangle, radius))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                using (Matrix transform = new Matrix())
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    form.Region = new Region(roundPath);
                    if (borderSize >= 1)
                    {
                        Rectangle rect = form.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);
                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);
                        graph.Transform = transform;
                        graph.DrawPath(penBorder, roundPath);
                    }
                }
            }
        }

        private void DrawPath(Rectangle rect, Graphics graph, Color color)
        {
            using (GraphicsPath roundPath = GetRoundedPath(rect, borderRadius))
            using (Pen penBorder = new Pen(color, 3))
            {
                graph.DrawPath(penBorder, roundPath);
            }
        }

        private struct FormBoundsColors
        {
            public Color TopLeftColor;
            public Color TopRightColor;
            public Color BottomLeftColor;
            public Color BottomRightColor;
        }
        private FormBoundsColors GetFormBoundsColors()
        {
            var fbColor = new FormBoundsColors();
            using (var bmp = new Bitmap(1, 1))
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle rectBmp = new Rectangle(0, 0, 1, 1);
                //Top Left
                rectBmp.X = this.Bounds.X - 1;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopLeftColor = bmp.GetPixel(0, 0);
                //Top Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopRightColor = bmp.GetPixel(0, 0);
                //Bottom Left
                rectBmp.X = this.Bounds.X;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomLeftColor = bmp.GetPixel(0, 0);
                //Bottom Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomRightColor = bmp.GetPixel(0, 0);
            }
            return fbColor;
        }

        private descargas CargaAV()
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
            List<versionCarpeta> versionesEnCarpeta = obtenerVersionesInstaladas();
            return VerificarInstalados(Versiones, versionesEnCarpeta);
        }

        private descargas VerificarInstalados(descargas versionesSinVerificar, List<versionCarpeta> versionesInstaladas)
        {
            foreach (var l in versionesSinVerificar.versions)
            {
                var index = versionesSinVerificar.versions.IndexOf(l);
                versionesSinVerificar.versions[index].descargado = false;
            }
            if(versionesInstaladas.Count != 0)
            {
                foreach (var instalado in versionesInstaladas)
                {
                    var version = versionesSinVerificar.versions.Where(b => b.id == instalado.version).FirstOrDefault();
                    var index = versionesSinVerificar.versions.IndexOf(version);
                    if (version != null)
                    {
                        versionesSinVerificar.versions[index].descargado = true;
                    }
                }
            }
            
            //if()
            //{
            //    foreach(var l in versionesSinVerificar.versions){
            //        var index = versionesSinVerificar.versions.IndexOf(l);
            //        versionesSinVerificar.versions[index].descargado = false;
            //    }
            //}
            //else
            //{
            //    //foreach(var l in versionesInstaladas)
            //    //{
            //    //    for(int i = 0; i < versionesSinVerificar.versions.Count; i++)
            //    //    {
            //    //        if(versionesSinVerificar.versions[i].id == l.version)
            //    //        {
            //    //            versionesSinVerificar.versions[i]
            //    //        }
            //    //    }
            //    //}
            //}
            return versionesSinVerificar;
        }

        //public void genCarpetas(object sender, EsperaDeCarga esperaDeCarga)
        //{
        //    Task generarCarpetas = Task.Run(() =>
        //    {

        //    });
        //}
        private void Load_Load(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            InstalarJava instalarJava = new InstalarJava();
            barraDeCarga.Style = ProgressBarStyle.Marquee;
            var javaHome = Environment.GetEnvironmentVariable("JAVA_HOME");
            if (Directory.Exists("java"))
            {
                if(Directory.GetDirectories("java").Length > 3)
                {

                }
                else
                {
                    if (string.IsNullOrEmpty(settings.javaPath))
                    {
                        if (!Directory.Exists(Environment.GetEnvironmentVariable("JAVA_HOME")))
                        {
                            if (!Directory.Exists(settings.javaPath))
                            {
                                if (instalarJava.ShowDialog() == DialogResult.OK)
                                {
                                    this.Show();
                                    java = true;
                                }
                            }
                            else
                            {
                                this.Hide();
                                if (instalarJava.ShowDialog() == DialogResult.OK)
                                {
                                    this.Show();
                                    java = true;
                                }
                            }

                        }
                        else
                        {
                            settings.javaPath = Environment.GetEnvironmentVariable("JAVA_HOME") + "\\";
                            settings.Save();
                            java = true;
                        }
                    }
                    else
                    {
                        if (!Directory.Exists(settings.javaPath))
                        {
                            if (instalarJava.ShowDialog() == DialogResult.OK)
                            {
                                java = true;
                            }
                        }
                        else
                        {
                            java = true;
                        }
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(settings.javaPath))
                {
                    if (!Directory.Exists(Environment.GetEnvironmentVariable("JAVA_HOME")))
                    {
                        if (!Directory.Exists(settings.javaPath))
                        {
                            if (instalarJava.ShowDialog() == DialogResult.OK)
                            {
                                this.Show();
                                java = true;
                            }
                        }
                        else
                        {
                            this.Hide();
                            if (instalarJava.ShowDialog() == DialogResult.OK)
                            {
                                this.Show();
                                java = true;
                            }
                        }

                    }
                    else
                    {
                        settings.javaPath = Environment.GetEnvironmentVariable("JAVA_HOME") + "\\";
                        settings.Save();
                        java = true;
                    }
                }
                else
                {
                    if (!Directory.Exists(settings.javaPath))
                    {
                        if (instalarJava.ShowDialog() == DialogResult.OK)
                        {
                            java = true;
                        }
                    }
                    else
                    {
                        java = true;
                    }
                }
            }
        }


        private void Load_Shown(object sender, EventArgs e)
        {

            if (!segundoPlano.IsBusy || java == true)
            {
                segundoPlano.RunWorkerAsync();
            }
        }
        descargas Versiones = new descargas();
        private bool java = false;

        private void segundoPlano_DoWork(object sender, DoWorkEventArgs e)
        {
            Versiones = CargaAV();
            GC.Collect();
        }

        private void segundoPlano_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            Inicio inicio = new Inicio();
            //foreach(Form formulariosAbiertos in Application.OpenForms)
            //{
            //    if(formulariosAbiertos.GetType() == typeof(Inicio))
            //    {
            //        formulariosAbiertos.Dispose();
            //        inicio = new Inicio();
            //        inicio.temp = CargaAV();
            //        inicio.Show();
            //        goto salir;
            //    }
            //    else
            //    {

            //    }
            //}
            inicio.temp = Versiones;
            GC.Collect();
            inicio.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Splash_Paint(object sender, PaintEventArgs e)
        {
        //    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        //Rectangle rectForm = this.ClientRectangle;
        //int mWidht = rectForm.Width / 2;
        //int mHeight = rectForm.Height / 2;
        //var fbColors = GetFormBoundsColors();
        ////Top Left
        //DrawPath(rectForm, e.Graphics, fbColors.TopLeftColor);
        ////Top Right
        //Rectangle rectTopRight = new Rectangle(mWidht, rectForm.Y, mWidht, mHeight);
        //DrawPath(rectTopRight, e.Graphics, fbColors.TopRightColor);
        ////Bottom Left
        //Rectangle rectBottomLeft = new Rectangle(rectForm.X, rectForm.X + mHeight, mWidht, mHeight);
        //DrawPath(rectBottomLeft, e.Graphics, fbColors.BottomLeftColor);
        ////Bottom Right
        //Rectangle rectBottomRight = new Rectangle(mWidht, rectForm.Y + mHeight, mWidht, mHeight);
        //DrawPath(rectBottomRight, e.Graphics, fbColors.BottomRightColor);
        ////-> SET ROUNDED REGION AND BORDER
        //FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }
    }
}
