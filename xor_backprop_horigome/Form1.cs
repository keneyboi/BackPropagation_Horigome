using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Backprop;
namespace backprop_horigome
{
    public partial class Form1 : Form
    {
        NeuralNet nn;
        Bitmap loaded;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nn = new NeuralNet(2, 5, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1000; i++)
            {
                // perform XOR operation
                // 1 XOR 1 = 0
                nn.setInputs(0, 1.0);
                nn.setInputs(1, 1.0);
                nn.setDesiredOutput(0, 0.0);
                nn.learn();

                // 1 XOR 0 = 1
                nn.setInputs(0, 1.0);
                nn.setInputs(1, 0.0);
                nn.setDesiredOutput(0, 1.0);
                nn.learn();

                // 0 XOR 1 = 1
                nn.setInputs(0, 0.0);
                nn.setInputs(1, 1.0);
                nn.setDesiredOutput(0, 1.0);
                nn.learn();

                // 0 XOR 0 = 0
                nn.setInputs(0, 0.0);
                nn.setInputs(1, 0.0);
                nn.setDesiredOutput(0, 0.0);
                nn.learn();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            nn.setInputs(0, Convert.ToDouble(textBox1.Text));
            nn.setInputs(1, Convert.ToDouble(textBox2.Text));
            nn.run();
            textBox3.Text = "" + nn.getOuputData(0);        }

        private void button7_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            loaded = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = loaded;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            nn = new NeuralNet(4096, 64, 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int a = 0; a < 1000; a++)
            {
                int count = 0;
                for (int x = 0; x < loaded.Width; x++)
                {
                    for (int y = 0; y < loaded.Height; y++)
                    {
                        Color pixel = loaded.GetPixel(x, y);
                        int gray = (pixel.R + pixel.G + pixel.B) / 3;
                        nn.setInputs(count, gray);
                        count++;
                    }
                }

                nn.setDesiredOutput(0, 1.0);
                nn.learn();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (loaded == null)
            {
                MessageBox.Show("Please load an image first.");
                return;
            }

            if (nn == null)
            {
                MessageBox.Show("Please initialize the neural network first.");
                return;
            }

            if (loaded.Width * loaded.Height != 4096)
            {
                MessageBox.Show($"Image must be 64x64 (4096 pixels). Current size: {loaded.Width}x{loaded.Height}");
                return;
            }

            int count = 0;
            for (int x = 0; x < loaded.Width; x++)
            {
                for (int y = 0; y < loaded.Height; y++)
                {
                    Color pixel = loaded.GetPixel(x, y);
                    double gray = (pixel.R + pixel.G + pixel.B) / (3.0 * 255.0);
                    nn.setInputs(count, gray);
                    count++;
                }
            }

            nn.run();
            textBox4.Text = nn.getOuputData(0).ToString("F4");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
