using Numerical.Classes;
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
    public partial class frm_Chapter2 : Form
    {

        public frm_Chapter2()
        {
            InitializeComponent();
            DataGridView gridView1 = new DataGridView();
            View.RowCount = 3;
          

        }
       
        private void btn_Done_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton4.Checked == true)
                {


                    gauss_Jordan c = new gauss_Jordan();
                    float[][] matrix =
                {
            new float[4],
            new float[4],
            new float[4]
        };
                    float _m21 = 0F;
                    float _m31 = 0F;
                    float _m32 = 0F;

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            matrix[i][j] = float.Parse(View.Rows[i].Cells[j].Value.ToString());
                        }
                    }
                   
                    c.GaussJordan(matrix, x1, x2, x3, label4);
                    NonVisable();
                    l1.Visible = false;
                    visable();
                }
                else if (radioButton5.Checked == true)
                {
                    Gaussin_Elimination g = new Gaussin_Elimination();

                    float[][] _a =
        {
            new float[4],
            new float[4],
            new float[4]
        };
                    float _m21 = 0F;
                    float _m31 = 0F;
                    float _m32 = 0F;

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            _a[i][j] = float.Parse(View.Rows[i].Cells[j].Value.ToString());
                        }
                    }
                    g.GJE(_a, ref _m21, ref _m31, ref _m32, label4, x1, x2, x3);
                    NonVisable();

                    visable();
                    l1.Visible = false;
                }
                else if (radioButton1.Checked == true)
                {
                    LU_Decomposition l = new LU_Decomposition();
                    float[][] _a =
        {
            new float[4],
            new float[4],
            new float[4]
        };
                    float _m21 = 0F;
                    float _m31 = 0F;
                    float _m32 = 0F;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            _a[i][j] = float.Parse(View.Rows[i].Cells[j].Value.ToString());
                        }
                    }

                    l.GJE(_a, ref _m21, ref _m31, ref _m32, label5, x11, x22, x33);
                    l.LUDecomposition(_a, label4, x1, x2, x3);
                    NonVisable();

                    visable2();
                    visable();
                    l1.Visible = false;
                }
                else
                {
                    CramersRule c = new CramersRule();
                    float[][] _a =
        {
            new float[4],
            new float[4],
            new float[4]
        };
                    float _m21 = 0F;
                    float _m31 = 0F;
                    float _m32 = 0F;
                    
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            
                            _a[i][j] = float.Parse(View.Rows[i].Cells[j].Value.ToString()); 
                        }
                    }
                   c.cramersRule(_a,l1,l,label,dataGridView1);
                    NonVisable();
                    l.Visible= false;
                    l1.Visible= true;
                    label.Visible= false;
                    dataGridView1.Visible = true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
        private void NonVisable()
        {

            x1.Visible = false;
            x2.Visible = false;
            x3.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;

            label5.Visible = false;
            x11.Visible = false;
            x22.Visible = false;
            x33.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;

            dataGridView1.Visible= false;
        }
        private void visable2()
        {

            label5.Visible=true;
            x11.Visible=true;
            x22.Visible = true;
            x33.Visible = true;
            label9.Visible=true;
            label10.Visible = true;
            label11.Visible=true;
        }
        private void visable()
        {
            x1.Visible = true;
            x2.Visible = true;
            x3.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
        }
    }

      
    }


