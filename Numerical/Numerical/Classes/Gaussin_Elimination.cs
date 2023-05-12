using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerical.Classes
{
    internal class Gaussin_Elimination
    {
        public void swap(float[][] _a, int r1, int r2)
        {
            Console.Write("Swap R");
            Console.Write(r1);
            Console.Write(" <-> R");
            Console.Write(r2);
            Console.Write("\n");
            for (int i = 0; i < 4; i++)
            {
                float temp = _a[r1][i];
                _a[r1][i] = _a[r2][i];
                _a[r2][i] = temp;
            }
        }
        //---!! ONLY WHEN SOLVING WITH PARTIAL PIVOT !!---

        public void GJE(float[][] _a, ref float m21, ref float m31, ref float m32,Label label,Label x11,Label x22,Label x33)
        {
            //---!! ONLY WHEN SOLVING WITH PARTIAL PIVOT !!---
            // Check if pivot is larger than the elements below it
            if (Math.Abs(_a[0][0]) < Math.Abs(_a[1][0]) || Math.Abs(_a[0][0]) < Math.Abs(_a[2][0]))
            {
                if (Math.Abs(_a[1][0]) > Math.Abs(_a[2][0]))
                {
                    swap(_a, 0, 1);
                }
                else
                {
                    swap(_a, 0, 2);
                }
            }
            //---!! ONLY WHEN SOLVING WITH PARTIAL PIVOT !!---


            m21 = _a[1][0] / _a[0][0];
            m31 = _a[2][0] / _a[0][0];
            //rule E2-(m21)E1 = E2
            for (int j = 0; j < 4; j++)
            {
                float e2 = _a[1][j];
                float e1 = ((m21) * _a[0][j]);
                _a[1][j] = e2 - e1;
            }
            //rule E3-(m31)E1 = E3
            for (int j = 0; j < 4; j++)
            {
                float e3 = _a[2][j];
                float e1 = ((m31) * _a[0][j]);
                _a[2][j] = e3 - e1;
            }

            //---!! ONLY WHEN SOLVING WITH PARTIAL PIVOT !!---
            // Check if m22 is larger than the element below it
            if (Math.Abs(_a[1][1]) < Math.Abs(_a[2][1]))
            {
                swap(_a, 1, 2);
            }
            //---!! ONLY WHEN SOLVING WITH PARTIAL PIVOT !!---

            m32 = _a[2][1] / _a[1][1];
            //rule E3-(m32)E2 = E3
            for (int j = 0; j < 4; j++)
            {
                float e3 = _a[2][j];
                float e1 = ((m32) * _a[1][j]);
                _a[2][j] = e3 - e1;
            }
            float x3 = _a[2][3] / _a[2][2];
            float x2 = (_a[1][3] - (_a[1][2] * x3)) / _a[1][1];
            float x1 = (_a[0][3] - ((_a[0][1] * x2) + (_a[0][2] * x3))) / _a[0][0];
            label.Text = "\"Gaussian Elimination Result\"";
            x11.Text = x1.ToString();
            x22.Text=x2.ToString();
            x33.Text=x3.ToString();
            
        }
    }
}
