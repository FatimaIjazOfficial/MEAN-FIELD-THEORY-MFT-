using System;
using System.Drawing;
using System.Windows.Forms;

namespace MFT
{
    public partial class Form1 : Form
    {
        Graphics gg;
        double z = 4; // coordination number
        double T;     // temperature, dynamic input

        public Form1()
        {
            InitializeComponent();
            gg = this.CreateGraphics();
        }

        // Draw axes helper
        private void DrawAxes(Point origin, string xs, string ys)
        {
            Point px1 = new Point(origin.X - 100, origin.Y);
            Point px2 = new Point(origin.X + 100, origin.Y);
            Point py1 = new Point(origin.X, origin.Y - 100);
            Point py2 = new Point(origin.X, origin.Y + 100);

            Pen p = new Pen(Color.Red);
            SolidBrush bo = new SolidBrush(Color.OrangeRed);

            gg.DrawLine(p, px1, px2);
            gg.DrawLine(p, py1, py2);

            Font f = new Font("Times New Roman", 12);
            gg.DrawString(xs, f, bo, origin.X + 100, origin.Y);
            gg.DrawString(ys, f, bo, origin.X, origin.Y - 100);
        }

        // General plot helper
        private void PlotFunction(Func<float, float> func, Point origin, float scaleX, float scaleY, Color color, bool drawAxes = true, string xs = "", string ys = "")
        {
            if (drawAxes) DrawAxes(origin, xs, ys);

            using (SolidBrush plotBrush = new SolidBrush(color))
            {
                for (float x = -1; x <= 1; x += 0.01f)
                {
                    float y = func(x);
                    gg.FillEllipse(plotBrush, origin.X + x * scaleX, origin.Y - y * scaleY, 6, 6);
                }
            }
        }

        // Get temperature helper
        private void GetTemperature()
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Enter temperature T:", "Temperature Input", "2.5");
            if (!double.TryParse(input, out T))
            {
                MessageBox.Show("Invalid input. Using default T = 2.5");
                T = 2.5;
            }
        }

        // 1. s vs s
        // Purpose: Shows simple identity relation, baseline comparison for MFT
        private void ssolutionMethod1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlotFunction(s => s, new Point(150, 220), 120, 120, Color.Red, true, "s", "s");
        }

        // 2. s vs tanh(z*s/T)
        // Purpose: Visualize the Mean-Field equation s = tanh(z*s/T)
        private void sVsTanhzsTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetTemperature();
            PlotFunction(s => (float)Math.Tanh(z * s / T), new Point(450, 220), 120, 120, Color.Blue, true, "s", "tanh(z*s/T)");
        }

        // 3. s vs s - tanh(z*s/T)
        // Purpose: Visualize fixed points graphically
        // Fixed points occur where s - tanh(z*s/T) = 0
        private void ssolutionMethod2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetTemperature();
            PlotFunction(s => s - (float)Math.Tanh(z * s / T), new Point(750, 220), 80, 120, Color.Green, true, "s", "s - tanh(z*s/T)");
        }

        // 4. Analytical spontaneous magnetization s(T)
        // Purpose: Shows analytical solution for MFT Ising model
        // Only valid for T < 4 (critical temperature)
        private void buttonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point origin = new Point(120, 650);
            DrawAxes(origin, "T", "s");

            for (double temp = 0.1; temp < 4; temp += 0.05)
            {
                float ans2 = (float)Math.Sqrt(4 - temp);
                float ans3 = -(float)Math.Sqrt(4 - temp);

                gg.FillEllipse(new SolidBrush(Color.Orange), origin.X + (float)temp * 80, origin.Y - ans2 * 120, 6, 6);
                gg.FillEllipse(new SolidBrush(Color.Orange), origin.X + (float)temp * 80, origin.Y - ans3 * 120, 6, 6);
            }
        }

        // 5. s vs T (Fixed Points)
        // Purpose: Shows temperature dependence of MFT fixed points
        // Points where s = tanh(z*s/T)
        private void sVersusTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Point origin = new Point(600, 650);
            DrawAxes(origin, "T", "s");

            for (double temp = 0.1; temp < 10; temp += 0.05)
            {
                for (float s = -1; s < 1; s += 0.01f)
                {
                    float ans = s - (float)Math.Tanh(z * s / temp);
                    if (Math.Abs(ans) < 0.001)
                    {
                        gg.FillEllipse(new SolidBrush(Color.Purple), origin.X + (float)temp * 40, origin.Y - s * 120, 6, 6);
                    }
                }
            }
        }

        // Clear screen
        private void button1_Click(object sender, EventArgs e)
        {
            gg.Clear(this.BackColor);
        }
    }
}
