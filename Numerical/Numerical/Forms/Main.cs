using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerical.Forms
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnCh1_Click(object sender, EventArgs e)
        {
            frm_Chapter1 frm = new frm_Chapter1();
            frm.Show();
        }

        private void btnCh2_Click(object sender, EventArgs e)
        {
            frm_Chapter2 frm_Chapter2 = new frm_Chapter2();
            frm_Chapter2.Show();
        }
    }
}
