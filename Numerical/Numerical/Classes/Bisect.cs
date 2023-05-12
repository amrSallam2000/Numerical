using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerical.Classes
{
    internal class Bisect
    {
        FunctionExpression f=new FunctionExpression();
         DataTable dt=new DataTable();
        
        private void clear()
        {
            dt.Rows.Clear();
            dt.Clear();
            dt.Columns.Clear();
        }
        private void createTable()
        {
            dt.Columns.Add("Iteration");
            dt.Columns.Add("Xl");
            dt.Columns.Add("f(Xl)");
            dt.Columns.Add("Xu");
            dt.Columns.Add("f(Xu)");
            dt.Columns.Add("Xr");
            dt.Columns.Add("f(Xr");
            dt.Columns.Add("Error");
        }
        private void print(double it,double xl,double fxl,double xu,double fxu,double xr,double fxr,string err)
        {
            dt.Rows.Add(it,xl,fxl,xu,fxu,xr,fxr,err);
        }
        private double bisect(double xl, double xu, double eps)
        {
            if (dt.Columns.Count == 0)
                createTable();
            else
            {
                clear();
                createTable();
            }
            int iter = 0;//mmken fe case de nbd2 mn 1 bs fe false postion abda2ha mn 0 
            double Xr = 0.0;
            double XrOld = 0.0;
            double Error = 0.0;


            do
            {
                XrOld = Xr;
                Xr = (xl + xu) / 2;

                Error = Math.Abs((Xr - XrOld) / Xr) * 100;

                if (iter == 0)
                {
                    print(iter,xl,f.FunctionValue(xl),xu,f.FunctionValue(xu),Xr,f.FunctionValue(Xr),"----");
                }
                else
                {
                    print(iter, xl, f.FunctionValue(xl), xu, f.FunctionValue(xu), Xr, f.FunctionValue(Xr),(Error.ToString()+ "%"));

                }



                if (f.FunctionValue(xl) * f.FunctionValue(Xr) == 0)//lw la2ahom enhom bysawo zero hay5rog we yrg3 kemt el Xr el w2f 3ndha we de tb2a root
                {
                    break;
                    return Xr;
                }

                else if (f.FunctionValue(xl) * f.FunctionValue(Xr) > 0)
                {
                    xl = Xr;
                }
                else
                {
                    xu = Xr;

                }
                iter++;
            } while (Error >= eps);
            return Xr;
        }

        public void main(string fun,float Xl, float Xu, float eps,Label l,DataGridView dv)
        {
            double root;
            if (f.TryLoadFunction(fun))
            {
                f.CanCalculate = true;
            }else
            {
                MessageBox.Show("Function Not Valid", "Warning", MessageBoxButtons.OK);
            }
            f.TryLoadFunction(fun);
            if (f.FunctionValue(Xl) * f.FunctionValue(Xu) < 0)
            {
                root = bisect(Xl, Xu, eps);

                l.Text = root.ToString();
                dv.DataSource = dt;
            }
            else
            {
              l.Text= "Has No Solution";
            }
        }
    }
}
