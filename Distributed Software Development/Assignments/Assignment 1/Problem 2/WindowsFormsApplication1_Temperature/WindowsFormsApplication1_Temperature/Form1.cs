using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Consuming WCF Service
using WindowsFormsApplication1_Temperature.TempConversionService;

namespace WindowsFormsApplication1_Temperature
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Service1Client tcs = new Service1Client();
            double celsiusTemp = Convert.ToDouble(textBox1.Text);
            double FahrenheitTemp = tcs.C2F(celsiusTemp);
            textBox2.Text = FahrenheitTemp.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Service1Client tcs = new Service1Client();
            double FahrenheitTemp = Convert.ToDouble(textBox3.Text);
            double celsiusTemp = tcs.F2C(FahrenheitTemp);
            textBox4.Text = celsiusTemp.ToString();
        }

       
        private void Reset_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
