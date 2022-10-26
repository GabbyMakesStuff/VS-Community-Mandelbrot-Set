using System.Runtime.CompilerServices;
using System.Drawing.Imaging;

namespace MandelbrotTry
{
    public partial class MandelbrotSet : Form
    {
        // global variables declared here. This is how zoomed in the mandelbrot set will be.
        float scale = 2f;
        
        // This bool stops the panels from drawing the set upon the window opening for the first time.
        // prevents lag
        bool formStarted = false;

        // These are used for the mandelbrot and julia sets
        float xMin;
        float xMax;
        float yMin;
        float yMax;

        float xDisplacement;
        float yDisplacement;

        // These are used to choose a julia set
        float mouseX;
        float mouseY;

        float juliaWidth;
        float juliaHeight;
        float mandelWidth;
        float mandelHeight;



        public MandelbrotSet()
        {
            InitializeComponent();
        }

        // This paints the mandelbrot set inside the left panel.
        private void MandelbrotPanelPaint(object sender, PaintEventArgs e)
        {
            // Checks if button has been pressed. If not, don't paint. Prevents lag upon window loading for the first time.
            if (formStarted == true)
            {
                // Stuff is declared for drawing.
                Graphics g = e.Graphics;
                Brush brush;

                // variables for height and width of the panel.
                float height = MandelbrotPanel.Height;
                float width = MandelbrotPanel.Width;

                // Crazy math is done.
                // Width is declared as a value and height is declared so as to keep the ratio between height and width constant.
                mandelWidth = scale;
                mandelHeight = (mandelWidth * height) / width;

                // This just moves the set around a bit.
                xDisplacement = -0.5f;
                yDisplacement = 0f;

                // Upper and lower bounds are declared.
                xMin = -(mandelWidth / 2) + xDisplacement;
                yMin = -(mandelHeight / 2) + yDisplacement;
                xMax = (mandelWidth / 2) + xDisplacement;
                yMax = (mandelHeight / 2) + yDisplacement;

                // The max amount of times the recursion below will repeat for a single pixel.
                float maxIterations = 100;

                // Change in X and Y so as to move exactly 1 pixel forward.
                float dX = (xMax - xMin) / height;
                float dY = (yMax - yMin) / width;

                // Generation starts here. X begins at the lower bound.
                float x = xMin;
                for (int i = 0; i < height; i++)
                {
                    // Y begins at the lower bound and each time the for loop above loops,
                    float y = yMin;
                    for (int j = 0; j < width; j++)
                    {
                        float a = x;
                        float b = y;
                        int n = 0;
                        while (n < maxIterations)
                        {
                            n++;
                            float aa = a * a;
                            float bb = b * b;
                            float twoAB = 2f * a * b;
                            a = aa - bb + x;
                            b = twoAB + y;
                            if ((aa * aa) + (bb * bb) > 100)
                            {
                                break;
                            }

                        }

                        if (n == maxIterations)
                        {
                            brush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
                        }
                        else
                        {

                            float bright = Lerp(0, 1, MathF.Pow(n/maxIterations, 1.0f/2.0f));
                            bright = MathF.Round(bright * 255);
                            brush = new SolidBrush(Color.FromArgb(255, 
                                (int)(Lerp(0, 1, MathF.Pow(n / maxIterations, 1.0f / 2.0f)) * 255), 
                                (int)(Lerp(0, 1, MathF.Pow(n / maxIterations, 1.0f / 5.0f)) * 255),
                                (int)(Lerp(0, 1, MathF.Pow(n / maxIterations, 1.0f / 1.0f)) * 255)));
                        }

                        g.FillRectangle(brush, i, j, 500, 1);
                        y += dY;
                    }
                    x += dX;
                }
            }
            
        }

        float Lerp(float start, float end, float target)
        {
            // start, end, target is where between the two values I return
            float output =  (1-target)*start + target*end;
            return output;
        }

        private void MandelbrotBtn_Click(object sender, EventArgs e)
        {
            formStarted = true;
            MandelbrotPanel.Invalidate();
        }

        private void MandelbrotPanel_MouseDown(object sender, MouseEventArgs e)
        {
            TestLbl.Text = e.Location.X + ":" + e.Location.Y;
            float mouseAreaWidth = scale;
            float mouseAreaHeight = (mouseAreaWidth * JuliaSetPanel.Height) / JuliaSetPanel.Width;
            

            mouseX = (e.Location.X / (float)MandelbrotPanel.Width) * scale - 1.5f;
            mouseY = (e.Location.Y / (float)MandelbrotPanel.Height) * -scale +1;

            Test2Lbl.Text = mouseX + ":" + mouseY;

        }

        private void JuliaSetPanel_Paint(object sender, PaintEventArgs e)
        {
            if (formStarted == true)
            {
                Graphics g = e.Graphics;
                Brush brush;

                float height = JuliaSetPanel.Height;
                float width = JuliaSetPanel.Width;

                juliaWidth = 3;
                juliaHeight = (juliaWidth * height) / width;

                xDisplacement = 0f;
                yDisplacement = 0f;

                float xMin = -juliaWidth / 2;
                float yMin = -juliaHeight / 2;
                float xMax = juliaWidth / 2;
                float yMax = juliaHeight / 2;

                float maxIterations = 20;

                float dX = (xMax - xMin) / height;
                float dY = (yMax - yMin) / width;

                float x = xMin;

                for (int i = 0; i < height; i++)
                {
                    float y = yMin;
                    for (int j = 0; j < width; j++)
                    {
                        float a = x;
                        float b = y;
                        int n = 0;
                        while (n < maxIterations)
                        {
                            n++;
                            float aa = a * a;
                            float bb = b * b;
                            float twoAB = 2f * a * b;
                            a = aa - bb + mouseX;
                            b = twoAB + mouseY;
                            if ((aa * aa) + (bb * bb) > 16)
                            {
                                break;
                            }

                        }

                        if (n == maxIterations)
                        {
                            brush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
                        }
                        else
                        {

                            float bright = Lerp(0, 1, MathF.Pow(n / maxIterations, 1.0f / 2.0f));
                            bright = MathF.Round(bright * 255);
                            brush = new SolidBrush(Color.FromArgb(255,
                                (int)(Lerp(0, 1, MathF.Pow(n / maxIterations, 1.0f / 2.0f)) * 255),
                                (int)(Lerp(0, 1, MathF.Pow(n / maxIterations, 1.0f / 5.0f)) * 255),
                                255));
                        }

                        g.FillRectangle(brush, i, j, 500, 1);
                        y += dY;
                    }
                    x += dX;
                }
            }

        }

        private void JuliaSetBtn_Click(object sender, EventArgs e)
        {
            JuliaSetPanel.Invalidate();
        }
    }
}