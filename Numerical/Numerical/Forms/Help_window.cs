using Numerical.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerical.Forms
{
    public partial class Help_window : Form
    {
        private readonly List<string> _helpInformation;

        public Help_window()
        {
            InitializeComponent();
        }
        private void ReadInTimeSheet()
        {

            string countiers = File.ReadAllText("E:\\Numerical\\Numerical\\Recurces\\new_help.txt");
            string[]count=countiers.Split(';');
            foreach (string s in count)
            {
                listView1.Items.Add(s);
            }
            //using (StreamReader file = new StreamReader("E:\\Numerical\\Numerical\\Recurces\\new_help.txt"))
            //{
            //    int counter = 0;
            //    string ln;

            //    while ((ln = file.ReadLine()) != null)
            //    {
            //        listView1.Items.Add(ln);
            //        counter++;
            //    }
            //}

        }
        private void Help_window_Load(object sender, EventArgs e)
        {
            ReadInTimeSheet();
        }
    }
}
