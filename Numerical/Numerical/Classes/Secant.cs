using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerical.Classes
{
    internal class Secant
    {
        FunctionExpression f = new FunctionExpression();
        DataTable dt=new DataTable();
        double error = 0;
        int iter = 0;
        double xiPlus1 = 0;
 
        private void clear()
        {
            dt.Rows.Clear();
            dt.Clear();
            dt.Columns.Clear();
        }
        private void createTable()
        {
            dt.Columns.Add("Iteration");
            dt.Columns.Add("Xi-1");
            dt.Columns.Add("f(Xi-1)");
            dt.Columns.Add("Xi");
            dt.Columns.Add("f(Xi)");
            dt.Columns.Add("Error%");
        }
        private void print(double it, double xi_1,double fxi_1, double xi, double fxi, double err)
        {
            dt.Rows.Add(it, xi_1, fxi_1, xi, fxi,err);
        }
        double secant(double Xi, double xiMin1, double eps)
        {
            if(dt.Columns.Count==0)
                createTable();   
            
            
            xiPlus1 = Xi - (f.FunctionValue(Xi) * (xiMin1 - Xi)) / (f.FunctionValue(xiMin1) - f.FunctionValue(Xi));
            if (error > eps || iter == 0)
            {
                error =Math.Abs((xiPlus1 - Xi) / xiPlus1) * 100;
                iter++;
                xiMin1 = Xi;
                Xi = xiPlus1;
            print(iter,xiMin1,f.FunctionValue(xiMin1),Xi,f.FunctionValue(Xi),error);
                secant(Xi, xiMin1,eps);
            }
            return Xi;
        }

        public void main(string fun,double xi,double xiMini,double eps,Label l,DataGridView dv)
        {
            if (f.TryLoadFunction(fun))
            {
                
                f.CanCalculate = true;

            double root = secant(xi, xiMini, eps);
            l.Text=root.ToString();
            dv.DataSource = dt;
            }
            else
            {
               MessageBox.Show("Function Not Valid", "Warning", MessageBoxButtons.OK);

            }
           
        }

    }
}
