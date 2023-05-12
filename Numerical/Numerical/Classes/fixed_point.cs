using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerical.Classes
{
    internal class fixed_point
    {
        FunctionExpression f = new FunctionExpression();
            DataTable dt=new DataTable();
        int iter = 0;
        double xiPlus1 = 0, xi = 0, error = 0;

       
        private void createTable()
        {
            dt.Columns.Add("I");
            dt.Columns.Add("Xi");
            dt.Columns.Add("X+1");
            dt.Columns.Add("ع%");
        }
        private void print(double i,double xi,double xnew,double err)
        {
            dt.Rows.Add(i, xi, xnew, err); 
        }

        double fixedpoint(double x,double eps)
        {
            xi = x;
            xiPlus1 = f.FunctionValue(xi);
            print(iter,x,xiPlus1,error);
            error =Math.Abs((xiPlus1 - xi) / xiPlus1) * 100;
            iter++;
            if (error > eps) fixedpoint(xiPlus1,eps);
            return xi;
        }
        private void clear()
        {
            dt.Rows.Clear();
            dt.Clear();
            dt.Columns.Clear();
        }
        public void main(string fun,double Xo, double eps, Label l,DataGridView dv)
        {
            if (dt.Columns.Count==0)
            createTable();
            else
            {
                clear();
                createTable();
            }
            if(f.TryLoadFunction(fun))
            {
                f.CanCalculate = true;
            double root;
            root = fixedpoint(Xo, eps);
            l.Text =root.ToString();
            dv.DataSource = dt;
            }else
            {
                MessageBox.Show("Function Not Valid", "Warning", MessageBoxButtons.OK);
            }
        }
    }
}
