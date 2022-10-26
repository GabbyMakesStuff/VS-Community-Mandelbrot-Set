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
                        // Some local variables are declared. I simply followed The Coding Train's implementation.
                        float a = x;
                        float b = y;
                        // This is number of increments.
                        int n = 0;

                        // While loop increments until max iterations (100 typically).
                        while (n < maxIterations)
                        {
                            n++;
                            // The math is done. A squared and B squared are calculated
                            // as well as 2*A*B, then the values are mixed and stored back into A and B.
                            // The process repeats over and over...
                            float aa = a * a;
                            float bb = b * b;
                            float twoAB = 2f * a * b;
                            a = aa - bb + x;
                            b = twoAB + y;

                            // ... unless the sum of a and b are so high we know for sure they diverge and aren't part of the set.
                            if ((aa * aa) + (bb * bb) > 100)
                            {
                                break;
                            }

                        }

                        // After all of that up above, we get a single useful value out of it: n.
                        // If n reached the max iterations, we know for sure the pixel was part of the set.
                        if (n == maxIterations)
                        {
                            brush = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
                        }
                        // Otherwise, n could be anything from 0 to 99
                        // This allows us to add a colour gradient!
                        else
                        {
                            // This was some whacky loopy illogical math that somehow worked.
                            // Basically, we give a color based on an ARGB value (4 int parameters)
                            // Therefore:
                            // A is always 255. No transparency.
                            // R is a linear interpolation from 0 to 1, then square rooted, then multiplied by 255
                            // G is a lerp from 0 to 1, then 5-rooted, then multiplied by 255.
                            // B is a lerp from 0 to 1, then cube rooted, then multiplied by 255.
                            brush = new SolidBrush(Color.FromArgb(255, 
                                (int)(Lerp(0, 1, MathF.Pow(n / maxIterations, 1.0f / 2.0f)) * 255), 
                                (int)(Lerp(0, 1, MathF.Pow(n / maxIterations, 1.0f / 5.0f)) * 255),
                                (int)(Lerp(0, 1, MathF.Pow(n / maxIterations, 1.0f / 1.0f)) * 255)));
                        }
                        // The pixel is drawn with the colour above.
                        // Technically it's a rectangle with horizontal width 500, because it looks very cool.
                        g.FillRectangle(brush, i, j, 500, 1);

                        // Increment Y.
                        y += dY;
                    }
                    // Increment X.
                    x += dX;
                }
                JuliaLbl.Text = "Click anywhere on the Mandelbrot set then click the button below";
            }
            
        }

        // This is the lerp function. Very simple, I just looked it up online.
        float Lerp(float start, float end, float target)
        {
            // start, end, target is where between the two values I return
            float output =  (1-target)*start + target*end;
            return output;
        }

        // Only starts painting the mandelbrot set if the button is clicked. Prevents lag.
        private void MandelbrotBtn_Click(object sender, EventArgs e)
        {
            formStarted = true;
            MandelbrotPanel.Invalidate();
        }

        // Mouse down function in the event that user clicks somewhere on the mandelbrot set.
        private void MandelbrotPanel_MouseDown(object sender, MouseEventArgs e)
        { 
            // Some wonky math to keep the XY ratio consistent.
            float mouseAreaWidth = scale;
            float mouseAreaHeight = (mouseAreaWidth * JuliaSetPanel.Height) / JuliaSetPanel.Width;

            // This is hardcoded because I cannot for the life of me figure out a generalised expression 
            // for translating the mouse position to the complex plane.
            mouseX = (e.Location.X / (float)MandelbrotPanel.Width) * scale - 1.5f;
            mouseY = (e.Location.Y / (float)MandelbrotPanel.Height) * -scale +1;

            // Mouse X and Y are output onto 2 labels below the Julia Set panel.
            MouseLabelX.Text = "Mouse X Position: " + MathF.Round(mouseX,2);
            MouseLabelY.Text = "Mouse Y Position: " + MathF.Round(mouseY,2);

        }

        // This paints the Julia set for the corresponding mouse coordinates on the right panel.
        private void JuliaSetPanel_Paint(object sender, PaintEventArgs e)
        {
            // This condition stops it from drawing a Julia set immediately. Prevents lag.
            if (formStarted == true)
            {
                // Most of this stuff is exactly the same as the Mandelbrot Set's code, except...
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

                            // ...THIS. Instead of using the current pixel's X and Y coordinates, 
                            // the mouse XY coordinates are used as constants, no matter the pixel.
                            a = aa - bb + mouseX;
                            b = twoAB + mouseY;
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
                            brush = new SolidBrush(Color.FromArgb(255,
                                // This is different too. Blue is a constant 255 instead of also varying.
                                (int)(Lerp(0, 1, MathF.Pow(n / maxIterations, 1.0f / 2.0f)) * 255),
                                (int)(Lerp(0, 1, MathF.Pow(n / maxIterations, 1.0f / 5.0f)) * 255),
                                255));
                        }

                        g.FillRectangle(brush, i, j, 500, 1);
                        y += dY;
                    }
                    x += dX;
                }
                JuliaLbl2.Text = "Try out different points!";
            }

        }

        // This generates the Julia set.
        // I also accidentally made sure the Julia set couldn't be made UNTIL the Mandelbrot set is generated.
        // Turns out, this was a good feature.
        private void JuliaSetBtn_Click(object sender, EventArgs e)
        {
            JuliaSetPanel.Invalidate();
        }
    }
}