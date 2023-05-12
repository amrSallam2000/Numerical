using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerical.Classes
{
    internal class CramersRule
    {
        DataTable dt=new DataTable();
        DataTable dt2 = new DataTable();
        public static void CopyMatrix(float[][] _x, float[][] _y)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _y[i][j] = _x[i][j];
                }
            }
        }
        private void createtable()
        {
            dt.Columns.Add("A");
            dt.Columns.Add("x");
        }

        public  void cramersRule(float[][] _a,Label l1,Label l,Label label,DataGridView dv)
        {
            createtable();
            float[][] _ca =
            {
            new float[4],
            new float[4],
            new float[4]
        };
            float detA;
            float[] _detA = new float[3];
            float r0;
            float r1;
            float r2;
            CopyMatrix(_a, _ca);
            r0 = _a[0][0] * ((_a[1][1] * _a[2][2]) - (_a[1][2] * _a[2][1]));
            r1 = _a[0][1] * ((_a[1][0] * _a[2][2]) - (_a[1][2] * _a[2][0]));
            r2 = _a[0][2] * ((_a[1][0] * _a[2][1]) - (_a[1][1] * _a[2][0]));
            detA = r0 + (-r1) + r2;
            l1.Text = "\"Determinte of A = \"" + detA + "\n";
            //Console.Write("Determinte of A = ");
            //Console.Write(detA);
            //Console.Write("\n");
            for (int i = 0; i < 3; i++)
            {
                _a[0][i] = _a[0][3];
                _a[1][i] = _a[1][3];
                _a[2][i] = _a[2][3];
                r0 = _a[0][0] * ((_a[1][1] * _a[2][2]) - (_a[1][2] * _a[2][1]));
                r1 = _a[0][1] * ((_a[1][0] * _a[2][2]) - (_a[1][2] * _a[2][0]));
                r2 = _a[0][2] * ((_a[1][0] * _a[2][1]) - (_a[1][1] * _a[2][0]));
                _detA[i] = r0 + (-r1) + r2;
                CopyMatrix(_ca, _a);
                //Console.Write("A[");
                //Console.Write((i + 1));
                //Console.Write("] = ");
                //Console.Write(_detA[i]);
                //Console.Write("\n");
                dt.Rows.Add("A"+(i+1)+"="+_detA[i], "x" + (i + 1) + "=" + _detA[i] / detA);
            }
            for (int i = 0; i < 3; i++)
            {
                //dt.Rows.Add(,"x" + (i + 1) + "=" + _detA[i] / detA);
                //l.Text = "x" + (i + 1) + " = " + _detA[i] / detA + "\n";
                //Console.Write("x");
                //Console.Write((i + 1));
                //Console.Write(" = ");
                //Console.Write(_detA[i] / detA);
                //Console.Write("\n");
            }
            dv.DataSource = dt;
        }
        
        

    }
}
