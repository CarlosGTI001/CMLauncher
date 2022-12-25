using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMLauncher
{
    public partial class checkCustom : UserControl
    {
        public bool Checked { get; set; } = false;
        public checkCustom()
        {
            InitializeComponent();
        }
        
        private void check_Enter(object sender, EventArgs e)
        {
            if(Checked == false)
            {
                change.Text = "✓";
                Checked = true;
            }
            else
            {
                change.Text = " ";
                Checked = false;
            }
        }
    }
}
