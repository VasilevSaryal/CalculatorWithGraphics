using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        bool Format = false;
        Parser p = new Parser();
        public Form1()
        {
            InitializeComponent();
            Click += Form1_Click;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_Click(object sender, EventArgs e)
        {          
        }
        private void button17_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }
        private void button22_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        private void button27_Click(object sender, EventArgs e)
        {
            if (Format) { label1.Text = "RAD"; Format = false; }
            else { label1.Text = "DEG"; Format = true; }
        }
        private void button28_Click(object sender, EventArgs e)
        {
            
            string exp = textBox1.Text;
            textBox1.Text=Convert.ToString(p.Evaluate(textBox1.Text));
            string story = exp + " = " + textBox1.Text;
            listBox1.Items.Insert(0, story);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            int maxX = (Convert.ToInt32(textBox2.Text) - Convert.ToInt32(textBox3.Text)) * 1000;
            int minX = Convert.ToInt32(textBox3.Text) * 1000;

            double[] x = new double[maxX];
            double[] y = new double[maxX];
            string expr;
            double[] result = new double[maxX];

            expr = textBox1.Text;

            for (int i = 0; i < maxX; i = i + 1)
            {
                x[i] = (i + minX) / 1000.0;
            }

            for (int i = 0; i < maxX; i = i + 1)
            {
                p.Evaluate("x=" + x[i]);
                result[i] = p.Evaluate(expr);
            }

            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.ChartAreas[0].AxisX.Title = "Y";
            chart1.ChartAreas[0].AxisY.Title = "X";
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.Crossing = 0;
            chart1.ChartAreas[0].AxisY.Crossing = 0;
            chart1.ChartAreas[0].AxisX.Maximum = Convert.ToInt32(textBox2.Text);
            chart1.ChartAreas[0].AxisY.Maximum = Convert.ToInt32(textBox4.Text);
            chart1.ChartAreas[0].AxisX.Minimum = Convert.ToInt32(textBox3.Text);
            chart1.ChartAreas[0].AxisY.Minimum = Convert.ToInt32(textBox5.Text);
            if (textBox6.Text != "")
                chart1.ChartAreas[0].AxisX.Interval = Convert.ToInt32(textBox6.Text);
            if (textBox7.Text != "")
                chart1.ChartAreas[0].AxisY.Interval = Convert.ToInt32(textBox7.Text);

            for (int i = 0; i < maxX; i++)
                chart1.Series[0].Points.AddXY(x[i], result[i]);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
        }
    }
}
