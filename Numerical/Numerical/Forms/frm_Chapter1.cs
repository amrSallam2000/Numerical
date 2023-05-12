using System;
using System.Windows;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Numerical.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Numerical.Forms;

namespace Numerical
{
    public partial class frm_Chapter1 : Form
    {
        Bisect Bisect = new Bisect();
        false_pos false_=new false_pos();
        fixed_point fixed_=new fixed_point();
        Newton newton = new Newton(); 
        Secant secant = new Secant();
        FunctionExpression fun = new FunctionExpression();
        public frm_Chapter1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Done_Click(object sender, EventArgs e)
        {

            try
            {

                if (txtfn.Text.Trim() != "" && txtXl.Text.Trim() != "" && txtXu.Text.Trim() != "")
                {
                    if (radioButton1.Checked == true)
                    {
                        Bisect.main(txtfn.Text, float.Parse(txtXl.Text), float.Parse(txtXu.Text), float.Parse(txtEp.Text), label5, View);
                        label5.Visible = true;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        false_.main(txtfn.Text, float.Parse(txtXl.Text), float.Parse(txtXu.Text), float.Parse(txtEp.Text), label5, View);
                        label5.Visible = true;
                    }
                    else if (radioButton3.Checked == true)
                    {
                        fixed_.main(txtfn.Text, double.Parse(txtXl.Text), double.Parse(txtXu.Text), label5, View);
                        label5.Visible = true;
                    }
                    else if (radioButton4.Checked == true)
                    {
                        newton.main(txtfn.Text, double.Parse(txtXl.Text), double.Parse(txtXu.Text), label5, View);
                        label5.Visible = true;
                    }
                    else if (radioButton5.Checked == true)
                    {
                        secant.main(txtfn.Text, double.Parse(txtXu.Text), double.Parse(txtXl.Text), double.Parse(txtEp.Text), label5, View);
                        label5.Visible = true;
                    }
                }else
                {
                    MessageBox.Show("Fill all Fieldes", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch(Exception ex)
            {
                  MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
   
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton3.Checked == true)
            {
                label2.Text = "Xo:";
                label3.Text = "Esp:";
                txtEp.Hide();
                label4.Hide();
                View.Width = (875 / 2)+6;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

            if ( radioButton2.Checked == true)
            {
                label2.Text = "Xl:";
                label3.Text = "Xu:";
                View.Width = 850;
                label4.Visible= true;
                txtEp.Visible=true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButton1.Checked == true)
            {
                label2.Text = "Xl:";
                label3.Text = "Xu:";
                View.Width = 850;
                label4.Visible = true;
                txtEp.Visible = true;
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            

            label2.Text = "Xi:";
            label3.Text = "Esp:";
            txtEp.Hide();
            label4.Hide();
            View.Width = 875-300 ;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
           

            if (radioButton5.Checked == true)
            {
                label2.Text = "Xi-1:";
                label3.Text = "Xi:";
                View.Width = 875-230;

                txtEp.Visible = true;
                label4.Visible = true;
            }
        }

        private void btn_help_Click(object sender, EventArgs e)
        {
            Help_window h = new Help_window();
            h.Show();
        }
    }
}
