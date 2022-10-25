using System.Runtime.CompilerServices;

namespace MandelbrotTry
{
    public partial class Form1 : Form
    {

        float graphWidth;
        float windowHeight;
        


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush brush;

            graphWidth = 3;
            windowHeight = (graphWidth * Size.Height) / Size.Width;

            float xMin = -(graphWidth / 2);
            float yMin = -(windowHeight / 2);
            float xMax = xMin + graphWidth;
            float yMax = yMin + windowHeight;

            int maxIterations = 100;

            float dX = (xMax - xMin) / Size.Width;
            float dY = (yMax - yMin) / Size.Height;

            float y = yMin;

            for (int i = 0; i < Size.Height; i++)
            {
                float x = xMin;
                for (int j = 0; j < Size.Width; j++)
                {
                    float a = x;
                    float b = y;
                    int n = 0;
                    while (n < maxIterations)
                    {
                        float aa = a * a;
                        float bb = b * b;
                        float twoAB = 2f * a * b;
                        a = aa - bb + x;
                        b = twoAB + y;
                        if((aa * aa) + (bb * bb) > 16f)
                        {
                            break;
                        }
                        n++;
                    }

                    if (n == maxIterations)
                    {
                        brush = new SolidBrush(Color.FromArgb(255,0,0,0));
                    }
                    else
                    {
                        brush = new SolidBrush(Color.FromArgb(255, (int)Math.Round(MathF.Sqrt(n/maxIterations)), 255, 255));
                    }
                    g.FillRectangle(brush, i, j, 1, 1);
                    x += dX;
                }
                y += dY;
            }
        }
    }
}