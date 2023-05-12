using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerical.Classes
{
    internal class gauss_Jordan
    {
        public void gaussJordanDivide(float[][] matrix, int row, float divider)
        {
            for (int i = 0; i < 4; i++)
            {
                matrix[row][i] = matrix[row][i] / divider;
            }
        }

        public void gaussJordanMultiply(float[][] matrix, int row1, int row2)
        {
            int multiplier = (int)(-matrix[row1][row2]);
            for (int i = 0; i < 4; i++)
            {
                matrix[row1][i] = matrix[row1][i] + (multiplier * matrix[row2][i]);
            }
        }

        public void swap(float[][] matrix, int r1, int r2)
        {
            for (int i = 0; i < 4; i++)
            {
                float temp = matrix[r1][i];
                matrix[r1][i] = matrix[r2][i];
                matrix[r2][i] = temp;
            }
        }

        public void GaussJordan(float[][] matrix,Label lab1,Label lab2 ,Label lab3,Label lab4)
        {
            int cols = 4;
            int rows = 3;
            // Augmented Matrix

            // Make m00 = 1 (divide or swap)
            if (matrix[0][0] != 1F)
            {
                if (matrix[1][0] == 1F)
                {
                    swap(matrix, 0, 1);
                }
                else if (matrix[2][0] == 1F)
                {
                    swap(matrix, 0, 2);
                }
                else
                {
                    gaussJordanDivide(matrix, 0, matrix[0][0]);
                }
            }
            // R2 = R2 + Mutiplier * R1
            if (matrix[1][0] != 0F)
            {
                gaussJordanMultiply(matrix, 1, 0);
            }

            // R3 = R3 + Multiplier * R1
            if (matrix[2][0] != 0F)
            {
                gaussJordanMultiply(matrix, 2, 0);
            }

            // Make m11 = 1 (divide or swap)
            if (matrix[1][1] != 1F)
            {
                if (matrix[2][1] == 1F)
                {
                    swap(matrix, 1, 2);
                }
                else
                {
                    gaussJordanDivide(matrix, 1, matrix[1][1]);
                }
            }

            // R3 = R3 + Multiplier R2
            if (matrix[0][1] != 0F)
            {
                gaussJordanMultiply(matrix, 0, 1);
            }

            // R1 = R1 + Multiplier R2
            if (matrix[2][1] != 0F)
            {
                gaussJordanMultiply(matrix, 2, 1);
            }

            // Make m22 = 1 (By dividing)
            if (matrix[2][2] != 1F)
            {
                gaussJordanDivide(matrix, 2, matrix[2][2]);
            }

            // R1 = R1 + Multiplier R2
            if (matrix[0][2] != 0F)
            {
                gaussJordanMultiply(matrix, 0, 2);
            }

            // R2 = R2 + Multiplier R3
            if (matrix[1][2] != 0F)
            {
                gaussJordanMultiply(matrix, 1, 2);
            }

            float x3 = matrix[2][3] / matrix[2][2];
            float x2 = (matrix[1][3] - ((matrix[1][2] * x3))) / matrix[1][1];
            float x1 = (matrix[0][3] - ((matrix[0][1] * x2) + (matrix[0][2] * x3))) / matrix[0][0];
            lab4.Text = "\"Gauss Jordan Result\"";
            lab1.Text = x1.ToString();
            lab2.Text = x2.ToString();
            lab3.Text = x3.ToString();
        }
    }
}