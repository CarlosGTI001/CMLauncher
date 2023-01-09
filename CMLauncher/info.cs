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
    public partial class info : Form
    {
        public info()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void masInfo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://servercraftrd.xyz");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void donarBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
