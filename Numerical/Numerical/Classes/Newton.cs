using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerical.Classes
{
    internal class Newton
    {
        FunctionExpression f = new FunctionExpression();
        DataTable dt=new DataTable();
        double xiPlus1 = 0;
        double xi = 0;
        double error = 0;
        int iter = 0;
        
        
        private void clear()
        {
            dt.Rows.Clear();
            dt.Clear();
            dt.Columns.Clear();
        }
        private void createTable()
        {
            dt.Columns.Add("Iteration");
            dt.Columns.Add("Xi");
            dt.Columns.Add("f(xi)");
            dt.Columns.Add("f`(xi)");
            dt.Columns.Add("Error%");
        }
        private void print(double it, double xi, double fxi, double fdash, double err)
        {
            dt.Rows.Add(it, xi, fxi, fdash,err);
        }
        private double newton(double x, double eps)
        {
            double e = eps;
            if(dt.Columns.Count==0)
                createTable();
         
            xi = x;
            xiPlus1 = xi - ((f.FunctionValue(xi) / f.FunctionDerivativeValue(xi)));

            print(iter,x,f.FunctionValue(x),f.FunctionDerivativeValue(xi),error);

            if (error > eps || iter == 0)
            {

                error =Math.Abs((xiPlus1 - xi) / xiPlus1) * 100;
                iter++;
                newton(xiPlus1,e);
            }


            return xi;
        }
        public void main(string fun, double x, double eps, Label l, DataGridView dv)
        {

            double root;
            if (f.TryLoadFunction(fun))
            {
                f.CanCalculate = true;

                f.FunctionDerivativeValue(x);
                root = newton(x, eps);
                l.Text = root.ToString();
                dv.DataSource = dt;
            }
            else
            {
                MessageBox.Show("Function Not Valid", "Warning", MessageBoxButtons.OK);
            }
        }

    }
}
