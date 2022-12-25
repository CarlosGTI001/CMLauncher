using CMLauncher.Properties;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMLauncher.Helper;

namespace CMLauncher
{
    public partial class Configuracion : Form
    {
        bool sobrepasar;
        Settings settings = new Settings();
        public Configuracion()
        {
            InitializeComponent();
        }

        private void Configuracion_Load(object sender, EventArgs e)
        {
            directorio.Text = settings.minecraftPath;
            if(settings.fullScreen)
            {
                fullScreenCheck.Checked = true;
            }
            else
            {
                fullScreenCheck.Checked = false;
            }
            RMAX.Value = settings.ramMB;
            RMIN.Value = settings.ramMin;
            xNum.Value = settings.resolutionX;
            yNum.Value = settings.resolutionY;
            javaPath.Text = settings.javaPath;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void examinarDirectorio_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog examinarCarpeta = new CommonOpenFileDialog();
            examinarCarpeta.InitialDirectory = settings.minecraftPath;
            examinarCarpeta.IsFolderPicker = true;
            if (examinarCarpeta.ShowDialog() == CommonFileDialogResult.Ok)
            {
                directorio.Text = examinarCarpeta.FileName + "\\";
            }
        }

        private void salirBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RMAX_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void guardarBtn_Click(object sender, EventArgs e)
        {
            configMgr.actualizarConfiguracion(new configMgr.configClass
            {
                fullScreen = fullScreenCheck.Checked,
                javaPath = javaPath.Text,
                minecraftPath = directorio.Text,
                RamMax = int.Parse(RMAX.Value.ToString()),
                RamMin = int.Parse(RMIN.Value.ToString()),
                x = int.Parse(xNum.Value.ToString()),
                y = int.Parse(yNum.Value.ToString())
            });
            this.Close();
            generador.generarCarpetas();
        }

        private void fullScreenCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (fullScreenCheck.Checked)
            {
                resolucionPanel.Hide();
            }
            else
            {
                resolucionPanel.Show();
            }
        }

        private void examinarJavaPath_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog examinarCarpeta = new CommonOpenFileDialog();
            examinarCarpeta.InitialDirectory = settings.javaPath;
            examinarCarpeta.IsFolderPicker = true;
            if (examinarCarpeta.ShowDialog() == CommonFileDialogResult.Ok)
            {
                javaPath.Text = examinarCarpeta.FileName + "\\";
            }
        }

        private void RMAX_Leave(object sender, EventArgs e)
        {
            if (RMAX.Value > (generador.RAMinMB() / 2) && sobrepasar == false)
            {
                sobrepasar = false;
                MessageBox.Show("La memoria RAM aplicada es mayor a la mitad de la actual, recuerde que si sobrepasa una cantidad puede reducir el rendimiento de su equipo", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                RMAX.Value = settings.ramMB;
            }
            else
            {
                sobrepasar = true;
            }
        }
        int ex;
        int ey;
        bool Arrastre;
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
    }
}
