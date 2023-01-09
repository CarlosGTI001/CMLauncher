using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CLauncher
{
    public partial class InstalarJava : Form
    {
        public InstalarJava()
        {
            InitializeComponent();
        }

        private void javaPortable_Click(object sender, EventArgs e)
        {
            DownloadDialog downloadDialog = new DownloadDialog();
            if(downloadDialog.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void cancelarBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
