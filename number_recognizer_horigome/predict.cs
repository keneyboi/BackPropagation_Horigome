using Backprop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace number_recognizer_horigome
{
    public partial class predict : Form
    {
        private Bitmap drawingBitmap;
        private Graphics drawingGraphics;
        private bool isDrawing = false;
        private Point previousPoint;
        private NeuralNet nn;

        public predict(NeuralNet trainedNet)
        {
            InitializeComponent();
            nn = trainedNet;
            InitializeDrawingCanvas();
        }

        private void InitializeDrawingCanvas()
        {

            drawingBitmap = new Bitmap(64, 64, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            drawingGraphics = Graphics.FromImage(drawingBitmap);
            drawingGraphics.Clear(Color.Black);

            pictureBox1.Image = drawingBitmap;


            pictureBox1.MouseDown += pictureBoxCanvas_MouseDown;
            pictureBox1.MouseMove += pictureBoxCanvas_MouseMove;
            pictureBox1.MouseUp += pictureBoxCanvas_MouseUp;
        }

        private void pictureBoxCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            isDrawing = true;
            previousPoint = new Point(e.X * 64 / pictureBox1.Width, e.Y * 64 / pictureBox1.Height);
        }

        private void pictureBoxCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing) return;

            Point currentPoint = new Point(e.X * 64 / pictureBox1.Width, e.Y * 64 / pictureBox1.Height);

            using (Pen pen = new Pen(Color.White, 6f))
            {
                pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                drawingGraphics.DrawLine(pen, previousPoint, currentPoint);
            }

            previousPoint = currentPoint;
            pictureBox1.Invalidate();
        }

        private void pictureBoxCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }


      

        private void button2_Click(object sender, EventArgs e)
        {
            drawingGraphics.Clear(Color.Black);
            pictureBox1.Invalidate();
            label1.Text = "-";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nn == null)
            {
                MessageBox.Show("Neural network is not trained or loaded.");
                return;
            }

      
            for (int x = 0; x < drawingBitmap.Width; x++)
            {
                for (int y = 0; y < drawingBitmap.Height; y++)
                {
                    Color pixel = drawingBitmap.GetPixel(x, y);
                    int inputIndex = (y * drawingBitmap.Width) + x; 
                    nn.setInputs(inputIndex, pixel.R / 255.0);
                }
            }

    
            nn.run();
  
            double maxOutput = -1;
            int predictedDigit = -1;

            for (int d = 0; d < 10; d++)
            {
                double outputVal = nn.getOuputData(d);
                if (outputVal > maxOutput)
                {
                    maxOutput = outputVal;
                    predictedDigit = d;
                }
            }

            label1.Text = $"{predictedDigit}";
            label4.Text = $"{maxOutput}";

            StringBuilder sb = new StringBuilder();
            for (int d = 0; d < 10; d++)
            {
                double val = nn.getOuputData(d);
                sb.AppendLine($"Digit {d}: {val:F4}");
            }
            MessageBox.Show(sb.ToString(), "All Output Node Activations");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            {
                saveFileDialog1.Filter = "PNG Image|*.png|Bitmap Image|*.bmp";
                saveFileDialog1.Title = "Save Drawn Digit";
                saveFileDialog1.FileName = "digit_sample.png"; 

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                     
                        drawingBitmap.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                        MessageBox.Show("Drawing saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                drawingGraphics.Clear(Color.Black);
                pictureBox1.Invalidate();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
