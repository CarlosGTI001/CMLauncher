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
using CMLauncher.Properties;
using CMLauncher.Helper;
using static CMLauncher.Helper.Minecraft;
using System.Diagnostics;
using static CMLauncher.Helper.administradorVersiones;
using System.Windows.Shapes;
using System.Runtime.Remoting.Lifetime;
using System.Threading;

namespace CMLauncher
{
    public partial class Inicio : Form
    {
        private int ex;
        private int ey;
        public bool Arrastre { get; private set; }
        public descargas temp { get; set; }
        public descargarVersion versionDArgs;
        string versionUrl = "";
        private string versionID;
        private int cantidadLibrerias;
        double MBTotal;
        double MBCurso;
        int libreriasDescargadas = 0;
        int assetsTotal = 0;
        int assetsDescargados = 0;
        int clienteDescargado = 0;
        int clienteTotal = 0;
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
            Settings Settings = new Settings();
            snap.Checked = Settings.snaptshot;
            List<versiones> _versiones = new List<versiones>();
            //cargar url en el webview novedades
            if (temp != null)
            {
                
                if (snap.Checked)
                {
                    _versiones = (List<versiones>)temp.versions;
                }
                else
                {
                    _versiones = temp.versions.Where(a => a.type.Equals("release")).ToList<versiones>();
                }
                cargarVersionUltima();
                //versionesCbx.DataSource = _versiones;
                //versionesCbx.SelectedIndex = 0;
                //versionesCbx.ValueMember = "url";
                versionesCbx.DisplayMember = "id";
            }
            if (string.IsNullOrEmpty(Settings.ultimaVer))
            {
                Settings.ultimaVer = versionesCbx.Text;
            }
            else
            {
                var item = _versiones.Where(a => a.id == Settings.ultimaVer).FirstOrDefault();
                int indice = _versiones.IndexOf(item);
                versionesCbx.SelectedIndex = indice;
            }
            userName.Text = Settings.userName;
            GC.Collect();
            descargando.ProgressChanged += Descargando_ProgressChanged;
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {

        }

        //public void cargar()
        //{
        //    //cargar url en el webview novedades
        //    //novedades.Source = new Uri("https://www.minecraft.net/es-es");
        //    temp = obtenerVersiones();
        //    if (temp != null)
        //    {
        //        versionesCbx.DataSource = temp.versions;
        //        versionesCbx.SelectedIndex = 0;
        //        versionesCbx.ValueMember = "url";
        //        versionesCbx.DisplayMember = "id";
        //    }
        //}

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

        private descargas VerificarInstalados(descargas versionesSinVerificar, List<versionCarpeta> versionesInstaladas)
        {
            foreach (var l in versionesSinVerificar.versions)
            {
                var index = versionesSinVerificar.versions.IndexOf(l);
                versionesSinVerificar.versions[index].descargado = false;
            }
            if (versionesInstaladas.Count != 0)
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
            return versionesSinVerificar;
        }

        public descargarVersion obtenerUnaVersion(string uri)
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
            //var version = obtenerUnaVersion(new Uri(versionesCbx.SelectedValue.ToString()));

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
            //var archivo = version.downloads.client.file.url;
            if (jugarMC.Text == "Jugar")
            {
                Settings settings = new Settings();
                settings.ultimaVer = versionesCbx.Text;
                settings.Save();
                JugarMC();
                //Settings Settings = new Settings();
                //Settings.userName = userName.Text;
                //Settings.Save();
                //string uri = ((versiones)versionesCbx.SelectedValue).url;
                //var version = ((versiones)versionesCbx.SelectedValue).id;
                ////var version = Directorios[i].Split('\\')[7];
                ////var directorioVersion = Directorios[i] + "\\";
                //var json = System.IO.File.ReadAllText(string.Format(Settings.minecraftPath + "versions\\" + version + "\\" + version + ".json"));
                //versionDArgs = JsonConvert.DeserializeObject<descargarVersion>(json);
                //var comando = Minecraft.ejecutar(new Minecraft.argumentos
                //{
                //    minecraftPath = Settings.minecraftPath,
                //    javapath = Settings.javaPath,
                //    verWindows = "10.0",
                //    LauncherBrand = "CMLauncher",
                //    LauncherVersion = "0.0.1",
                //    Xmx = Settings.ramMB,
                //    Xmn = Settings.ramMB - (Settings.ramMB / 2),
                //    Librerias = versionDArgs.libraries,
                //    UserName = userName.Text,
                //    version = version,
                //    tipoVersion = versionDArgs.type,
                //    assetIndex = versionDArgs.assetIndex.id,
                //    uuid = Settings.UUID,
                //    gameJar = Settings.minecraftPath + "versions\\" + version + "\\" + version + ".jar"
                //});
                //FileStream configuracion = File.Open(Settings.minecraftPath + "options.txt", FileMode.Open);
                //StreamReader streamReader = new StreamReader(configuracion);
                //var _configuracion = streamReader.ReadToEnd();
                //if (Settings.fullScreen == true && _configuracion.Contains("fullscreen:false"))
                //{
                //    _configuracion = _configuracion.Replace("fullscreen:false", "fullscreen:true");
                //}
                //if(Settings.fullScreen == false && _configuracion.Contains("fullscreen:true"))
                //{
                //    _configuracion = _configuracion.Replace("fullscreen:true", "fullscreen:false");
                //}
                //StreamWriter guardar = new StreamWriter(configuracion);
                //guardar.Write(_configuracion);
                //guardar.Close();
                //configuracion.Close();
                //streamReader.Close();
                ///*Minecraft.ExecuteCommand(comando + "\n pause");*/


                //Process process = new Process();
                //process.EnableRaisingEvents = false;
                //process.StartInfo.FileName = "C:\\Users\\carlo\\AppData\\Roaming\\.minecraft\\runtime\\java-runtime-beta\\windows\\java-runtime-beta\\bin\\javaw.exe";
                ////process.StartInfo.FileName = "" + "\\bin\\javaw.exe";
                //process.StartInfo.Arguments = comando;
                //process.Start();
                //this.Hide();
                //process.WaitForExit();
                //this.Show();
                ////var cmdLine = Settings.javaPath + "\\bin\\javaw.exe " + comando;
                ////Console.WriteLine(cmdLine);
                ////versionDArgs.assets
                ////Minecraft.ejecutar();
            }
            else
            {
                descargaBar.Style = ProgressBarStyle.Marquee;
                cancelar.Enabled = true;
                descargando.RunWorkerAsync();
            }
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void versionesCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (versionesCbx.SelectedIndex != -1)
            {
                var versionSeleccionada = ((versiones)versionesCbx.SelectedValue).descargado;
                if (versionSeleccionada)
                {
                    jugarMC.Text = "Jugar";
                }
                else
                {
                    jugarMC.Text = "Descargar";
                }
                if(config != true)
                {
                    Settings settings = new Settings();
                    settings.ultimaVer = versionesCbx.Text;
                    settings.Save();
                    
                }
                config = false;
                versionUrl = ((versiones)versionesCbx.SelectedValue).url;
                versionID = ((versiones)versionesCbx.SelectedValue).id;
            }
        }

        Minecraft Minecraft = new Minecraft();

        private void descargarMinecraft(object sender, EventArgs e)
        {
            Settings Settings = new Settings();
            Settings.userName = userName.Text;
            Settings.Save();
        }

        private void lanzarMinecraft(object sender, EventArgs e)
        {

        }

        private void versionesCbx_SelectedValueChanged(object sender, EventArgs e)
        {
            if (versionesCbx.SelectedIndex != -1)
            {
                var versionSeleccionada = ((versiones)versionesCbx.SelectedValue).id;
                var versionDesplegadas = temp.versions.Where(a => a.id == versionSeleccionada).FirstOrDefault();
                if (versionDesplegadas.descargado)
                {
                    jugarMC.Text = "Jugar";
                }
                else
                {
                    jugarMC.Text = "Descargar";
                }
            }
        }

        private void abrirCarpeta_Click(object sender, EventArgs e)
        {
            Settings Settings = new Settings();
            Process abrirCarpetaDeMC = Process.Start(Settings.minecraftPath);
        }

        private void editarConfiguracionBtn_Click(object sender, EventArgs e)
        {
            Configuracion configuracion = new Configuracion();
            if (configuracion.ShowDialog() == DialogResult.OK)
            {
                temp = VerificarInstalados(temp, obtenerVersionesInstaladas());
                config = true;
                cargarVersionUltima();
            };
            
        }

        public void cargarVersionUltima()
        {
            Settings Settings = new Settings();
            List<versiones> _versiones = (List<versiones>)temp.versions;
            if (temp != null)
            {

                if (snap.Checked)
                {
                    _versiones = (List<versiones>)temp.versions;
                }
                else
                {
                    _versiones = temp.versions.Where(a => a.type.Equals("release")).ToList<versiones>();
                }
                config = true;
                versionesCbx.DataSource = _versiones;
                //versionesCbx.SelectedIndex = 0;
                //versionesCbx.ValueMember = "url";
                versionesCbx.DisplayMember = "id";
                config = false;
            }
            if (string.IsNullOrEmpty(Settings.ultimaVer))
            {
                Settings.ultimaVer = versionesCbx.Text;
            }
            else
            {
                var item = _versiones.Where(a => a.id == Settings.ultimaVer).FirstOrDefault();
                int indice = _versiones.IndexOf(item);
                versionesCbx.SelectedIndex = indice;
            }
        }

        private void acercaDe_Click(object sender, EventArgs e)
        {
            info info = new info();
            info.ShowDialog();
        }

        public void counter()
        {
            if (cambiar)
            {
                descargaBar.Maximum = cantidad;
                descargaBar.Minimum = 0;
                descargaBar.Style = ProgressBarStyle.Blocks;
            }
        }

        public void iniciarDescarga()
        {

        }

        bool cambiar = true;
        int cantidad;
        int paso;
        int i = 0;
        private bool config = false;

        private void descargando_DoWork(object sender, DoWorkEventArgs e)
        {
            descargando.WorkerReportsProgress = true;
            descargando.WorkerSupportsCancellation = true;
            descargando.ReportProgress(0);
            paso = 1;
            Descargar descargar = new Descargar();
            descargarVersion _descargarVersion = new descargarVersion();
            Settings Settings = new Settings();
            var url = versionUrl;
            WebClient webClient = new WebClient();
            var json = webClient.DownloadString(url);
            _descargarVersion = JsonConvert.DeserializeObject<descargarVersion>(json);
            var minecraftPath = Settings.minecraftPath;
            var assets = descargar.ObtenerIndexAsset(url, _descargarVersion, minecraftPath);
            cantidad = assets.Count() + _descargarVersion.libraries.Count() + 6;


            i = 0;
            cambiar = false;
            var cliente = _descargarVersion.downloads.client;
            var librerias = _descargarVersion.libraries.Select(a => a.downloads.artifact.url).ToList();
            var Libreria = _descargarVersion.libraries.Select(a => a.downloads.artifact).ToList<Artifact>();
            var pesoLibrerias = _descargarVersion.libraries.Select(a => a.downloads.artifact.size).ToList();
            cantidadLibrerias = _descargarVersion.libraries.Where(a => a.downloads.artifact.url != "linux" || a.downloads.artifact.url != "macos").Count();
            //.Select(a => a.downloads.artifact.url).ToList<Artifact>();
            MBTotal = (assets.Select(a => a.size).Sum() / 1024) / 1024;
            MBTotal += (cliente.size / 1024) / 1024;
            MBTotal += (pesoLibrerias.Sum() / 1024) / 1024;

            MBTotal = Math.Round(MBTotal, 2);
            paso = 2;
            descargando.ReportProgress(1);

            if (!File.Exists(Settings.minecraftPath + "assets\\log_configs\\" + _descargarVersion.logging.client.file.id))
            {
                var logConfig = "";
                using (WebClient client = new WebClient())
                {
                    logConfig = client.DownloadString(_descargarVersion.logging.client.file.url);
                }
                File.WriteAllText(Settings.minecraftPath + "assets\\log_configs\\" + _descargarVersion.logging.client.file.id, logConfig);
            }

            foreach (var asset in assets)
            {
                var firstPath = asset.hash.Substring(0, 2);
                var fileName = asset.hash;
                var urlInicial = "https://resources.download.minecraft.net";
                var urlDescarga = urlInicial + "/" + firstPath + "/" + fileName;
                assetsTotal = assets.Count();
                var path = Settings.minecraftPath + "assets\\objects\\" + firstPath + "" +
                    "\\";
                MBCurso += Math.Round((((asset.size) / 1024) / 1024), 2);
                paso = 4;
            crearPath:
                if (Directory.Exists(path))
                {
                    if (!File.Exists(path + fileName))
                    {
                        descargarArchivo(urlDescarga, path, fileName);
                    }
                    assetsDescargados++;
                }
                else
                {
                    Directory.CreateDirectory(path);
                    goto crearPath;
                }
                paso = 4;

                descargando.ReportProgress(i);
                i++;
            }

            if (Directory.Exists(Settings.minecraftPath + "libraries"))
            {

                foreach (Artifact library in Libreria)
                {
                    if (!library.url.Contains("linux") || !library.url.Contains("macos"))
                    {
                        descargarLib(library.url, library.path);
                        MBCurso += Math.Round((library.size / 1024) / 1024, 2);
                        paso = 3;
                        descargando.ReportProgress(i);
                        libreriasDescargadas++;
                        i++;
                    }
                    else
                    {

                    }
                }
            }
            paso = 5;
        descargarClient:
            if (!Directory.Exists(Settings.minecraftPath + "versions\\" + versionID))
            {
                Directory.CreateDirectory(Settings.minecraftPath + "versions\\" + versionID);

                goto descargarClient;
            }
            else
            {
                if (!Directory.Exists(Settings.minecraftPath + "versions\\" + versionID + "\\natives"))
                {
                    Directory.CreateDirectory(Settings.minecraftPath + "versions\\" + versionID + "\\natives");
                }
                if (!File.Exists(Settings.minecraftPath + "versions\\" + versionID + "\\" + versionID + ".jar"))
                {
                    descargarCliente(cliente.url, Settings.minecraftPath + "versions\\" + versionID + "\\", versionID + ".jar");
                    File.WriteAllText(Settings.minecraftPath + "versions\\" + versionID + "\\" + versionID + ".json", json);
                }
                else
                {
                    if (!File.Exists(Settings.minecraftPath + "versions\\" + versionID + "\\" + versionID + ".json"))
                    {
                        File.WriteAllText(Settings.minecraftPath + "versions\\" + versionID + "\\" + versionID + ".json", json);
                    }
                }
                paso = 7;
                descargando.ReportProgress(i);
            }
            i++;
            LibreriasNativas libreriasNativas = new LibreriasNativas();
            libreriasNativas.descomprimirNativas(_descargarVersion);
            paso = 7;            
            descargando.ReportProgress(i);
            Thread.Sleep(2000);
            paso = 0;
            GC.Collect();
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
            if (!File.Exists(pasarArchivo))
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

        private void Descargando_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            if (!cambiar)
            {
                cambiar = true;
                counter();
            }
            else
            {
                if (!(i > descargaBar.Maximum))
                    descargaBar.Value += 1;
            };
            int newSize = 10;
            switch (paso)
            {
                case 1:
                    jugarMC.Enabled = false;
                    jugarMC.Text = "Iniciando...";
                    break;
                case 2:
                    jugarMC.Font = new Font(jugarMC.Font.FontFamily, newSize, FontStyle.Bold);
                    jugarMC.ForeColor = Color.White;
                    jugarMC.BackColor = Color.FromArgb(200, 255, 210);
                    jugarMC.Text = "" + Math.Round(MBCurso) + "MB" + " / " + MBTotal + "MB";
                    break;
                case 3:
                    jugarMC.Font = new Font(jugarMC.Font.FontFamily, newSize, FontStyle.Bold);
                    jugarMC.ForeColor = Color.White;
                    jugarMC.BackColor = Color.FromArgb(200, 255, 210);
                    jugarMC.Text = "" + Math.Round(MBCurso) + "MB" + " / " + MBTotal + "MB \n Libreria: " + libreriasDescargadas + " / " + cantidadLibrerias;
                    break;
                case 4:
                    jugarMC.Font = new Font(jugarMC.Font.FontFamily, newSize, FontStyle.Bold);
                    jugarMC.ForeColor = Color.White;
                    jugarMC.BackColor = Color.FromArgb(200, 255, 210);
                    jugarMC.Text = "" + Math.Round(MBCurso) + "MB" + " / " + MBTotal + "MB \n Asset: " + assetsDescargados + " / " + assetsTotal;
                    //jugarMC.Text = "" + Math.Round(MBCurso) + "MB" + "/ " + MBTotal + "MB";
                    break;
                case 5:
                    jugarMC.Text = "Descargando cliente...";
                    descargaBar.Style = ProgressBarStyle.Marquee;
                    break;
                case 6:

                    break;
                case 7:
                    temp = VerificarInstalados(temp, obtenerVersionesInstaladas());
                    if (temp != null)
                    {
                        jugarMC.Font = new Font(jugarMC.Font.FontFamily, 14.25f, FontStyle.Bold);
                        jugarMC.ForeColor = Color.White;
                        //59; 133; 38
                        jugarMC.BackColor = Color.FromArgb(59, 133, 38);
                        jugarMC.Text = "Jugar";
                        jugarMC.Enabled = true;
                        //versionesCbx.DataSource = temp.versions;
                        //var selecionado = versionesCbx.SelectedIndex;
                        //versionesCbx.SelectedIndex = selecionado + 1;
                        //versionesCbx.SelectedIndex = selecionado;
                        //versionesCbx.DisplayMember = "id";
                    }
                    cargarVersionUltima();
                    break;
            }
        }

        public void JugarMC()
        {
            Settings Settings = new Settings();
            Settings.userName = userName.Text;
            Settings.Save();
            string uri = ((versiones)versionesCbx.SelectedValue).url;
            var version = ((versiones)versionesCbx.SelectedValue).id;
            //var version = Directorios[i].Split('\\')[7];
            //var directorioVersion = Directorios[i] + "\\";
            var json = System.IO.File.ReadAllText(string.Format(Settings.minecraftPath + "versions\\" + version + "\\" + version + ".json"));
            
            versionDArgs = JsonConvert.DeserializeObject<descargarVersion>(json);
            LibWin libWin = new LibWin();
            libWin.obtenerLibreriasNativas(json);
            
            var archivo = Settings.minecraftPath + "assets\\indexes\\" + versionDArgs.assetIndex.id + ".json";
            if (!File.Exists(archivo))
            {
                var index = versionDArgs.assetIndex.id;
                string indexAsset;
                using (WebClient webClient = new WebClient())
                {
                    indexAsset = webClient.DownloadString(versionDArgs.assetIndex.url);
                    File.WriteAllText(archivo, indexAsset);
                }
            }
            var args = new Minecraft.argumentos
            {
                minecraftPath = Settings.minecraftPath,
                javapath = Settings.javaPath,
                verWindows = "10.0",
                LauncherBrand = "CMLauncher",
                LauncherVersion = "0.0.1",
                Xmx = Settings.ramMB,
                Xmn = Settings.ramMB - (Settings.ramMB / 2),
                Librerias = JsonConvert.DeserializeObject<descargarVersion>(json).libraries,
                UserName = userName.Text,
                version = version,
                tipoVersion = versionDArgs.type,
                assetIndex = versionDArgs.assetIndex.id,
                uuid = Settings.UUID,
                gameJar = Settings.minecraftPath + "versions\\" + version + "\\" + version + ".jar"
            };
            var libreriasRepetidas = versionDArgs.libraries.Distinct().ToList<Library>();
            var librerias = libreriasRepetidas.Select(a => a.name).Distinct().ToList();
            List<Library> lib = new List<Library>();
            foreach(var library in librerias)
            {
                lib.Add(libreriasRepetidas.Where(a => a.name == library).First());
            }
            args.Librerias = lib;
            var comando = Minecraft.ejecutar(args);
        volver:
            if (File.Exists(Settings.minecraftPath + "options.txt"))
            {
                FileStream configuracion = File.Open(Settings.minecraftPath + "options.txt", FileMode.Open);
                StreamReader streamReader = new StreamReader(configuracion);
                var _configuracion = streamReader.ReadToEnd();
                if (Settings.fullScreen == true && _configuracion.Contains("fullscreen:false"))
                {
                    _configuracion = _configuracion.Replace("fullscreen:false", "fullscreen:true");
                }
                if (Settings.fullScreen == false && _configuracion.Contains("fullscreen:true"))
                {
                    _configuracion = _configuracion.Replace("fullscreen:true", "fullscreen:false");
                }
                ;
                StreamWriter guardar = new StreamWriter(configuracion);
                guardar.Write(_configuracion);
                guardar.Close();
                configuracion.Close();
                streamReader.Close();
            }
            else
            {
                File.WriteAllText(Settings.minecraftPath + "options.txt", "");
                
                goto volver;
            }

            /*Minecraft.ExecuteCommand(comando + "\n pause");*/


            Process process = new Process();
            process.EnableRaisingEvents = false;
            var directorio = Settings.javaPath + "bin\\javaw.exe";
            process.StartInfo.FileName = directorio;
            //process.StartInfo.FileName = "" + "\\bin\\javaw.exe";
            process.StartInfo.Arguments = comando;
            process.Start();
            this.Hide();
            process.WaitForExit();
            this.Show();
            //var cmdLine = Settings.javaPath + "\\bin\\javaw.exe " + comando;
            //Console.WriteLine(cmdLine);
            //versionDArgs.assets
            //Minecraft.ejecutar();
        }

        public void descargarArchivo(string url, string path, string fileName)
        {
            byte[] fileData;
            using (WebClient client = new WebClient())
            {
                fileData = client.DownloadData(url);
            }
            using (FileStream fs = new FileStream(path + fileName, FileMode.Create))
            {
                foreach (byte b in fileData)
                {
                    fs.WriteByte(b);
                }
                fs.Close();
            }
        }

        public void descargarCliente(string url, string path, string fileName)
        {
            byte[] fileData;
            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += Client_DownloadProgressChanged1;
                fileData = client.DownloadData(url);

            }
            using (FileStream fs = new FileStream(path + fileName, FileMode.Create))
            {
                foreach (byte b in fileData)
                {
                    fs.WriteByte(b);
                    i++;
                }
                fs.Close();
            }
        }

        private void Client_DownloadProgressChanged1(object sender, DownloadProgressChangedEventArgs e)
        {
            descargando.ReportProgress(i);
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            jugarMC.Text = "Descargar";
            cancelar.Enabled = false;
            jugarMC.Font = new Font(jugarMC.Font.FontFamily, 14.25f, FontStyle.Bold);
            jugarMC.ForeColor = Color.White;
            //59; 133; 38
            jugarMC.BackColor = Color.FromArgb(59, 133, 38);
            jugarMC.Text = "Descargar";
            jugarMC.Enabled = true;
            descargando.CancelAsync();
        }

        private void descargando_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            descargaBar.Value = 0;
            descargaBar.Style = ProgressBarStyle.Blocks;
        }

        private void Snaptshot_CheckedChanged(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.snaptshot = snap.Checked;
            if (snap.Checked)
            {
                versionesCbx.DataSource = temp.versions;
            }
            else
            {
                versionesCbx.DataSource = temp.versions.Where(a => a.type.Equals("release")).ToList<versiones>();
            }
            settings.Save();
        }
    }
}
