using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerical.Classes
{
    internal class LU_Decomposition
    {
        public  void GJE(float[][] _a, ref float m21, ref float m31, ref float m32,Label label,Label x11,Label x22,Label x33)
        {
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
            label.Text = "\"Gauss Jordan Result\"";
            x11.Text = x1.ToString();
            x22.Text=x2.ToString();
            x33.Text = x3.ToString();
        }

        public  void LUDecomposition(float[][] _a, Label label, Label x11, Label x22, Label x33)
        {
            float[][] _u =
            {
            new float[4],
            new float[4],
            new float[4]
        };
            float[][] _l =
            {
            new float[4],
            new float[4],
            new float[4]
        };
            float[] _b = new float[3];
            float _m21 = 0F;
            float _m31 = 0F;
            float _m32 = 0F;
            for (int i = 0; i < 3; i++)
            {
                _b[i] = _a[i][3];
            }
            GJE(_a, ref _m21, ref _m31, ref _m32,label,x11,x22,x33);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    _u[i][j] = _a[i][j];
                }
            }
            _l[0][1] = 0F;
            _l[0][2] = 0F;
            _l[1][2] = 0F;
            _l[0][0] = 1F;
            _l[1][1] = 1F;
            _l[2][2] = 1F;
            _l[1][0] = _m21;
            _l[2][0] = _m31;
            _l[2][1] = _m32;
            //lc=b
            float c1 = _b[0] / _l[0][0];
            float c2 = (_b[1] - (_l[1][0] * c1)) / _l[1][1];
            float c3 = (_b[2] - ((_l[2][0] * c1) + (_l[2][1] * c2))) / _l[2][2];
            //ux=c
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    _a[i][j] = _u[i][j];
                }
            }
            _a[0][3] = c1;
            _a[1][3] = c2;
            _a[2][3] = c3;
            float x3 = _a[2][3] / _a[2][2];
            float x2 = (_a[1][3] - (_a[1][2] * x3)) / _a[1][1];
            float x1 = (_a[0][3] - ((_a[0][1] * x2) + (_a[0][2] * x3))) / _a[0][0];
            label.Text = "\"LU decomposition\"";
            x11.Text = x1.ToString();
            x22.Text=x2.ToString();
            x33.Text=x3.ToString();
        }

    }
}
