using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pattern_Task6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            List<double> x = new List<double>{2,3,5}; 
            GradientDescentOptimizer gdo = new GradientDescentOptimizer(x,0.01,100,6);
            gdo.generatePoints(20,1,6);
            gdo.generateThetas();

        }
    }
}
