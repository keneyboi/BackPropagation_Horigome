using Backprop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
namespace number_recognizer_horigome
{
    public partial class Form1 : Form
    {
        Bitmap[] images;
        string[] fnames;
        PictureBox[] pbimages;
        int maxEpochs;
        NeuralNet nn;
        
        public Form1()
        {
            nn = new NeuralNet(64 * 64, 64, 10);
            maxEpochs = 1000;
            InitializeComponent();
        }

        private void loadImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            images = new Bitmap[openFileDialog1.FileNames.Count()];
            fnames = new string[images.Length];
            pbimages = new PictureBox[images.Length];

            int locx = 60;
            int locy = 70;

            for (int x = 0; x < images.Length; x++)
            {
                images[x] = new Bitmap("" + openFileDialog1.FileNames[x]);
                fnames[x] = "" + openFileDialog1.FileNames[x];
                pbimages[x] = new PictureBox();
                pbimages[x].Size = images[x].Size;
                pbimages[x].Location = new Point(locx, locy);
                pbimages[x].Image = images[x];
                this.Controls.Add(pbimages[x]);
                locx += images[x].Width + 5;
                if (locx + images[x].Width + 5 > this.Width)
                {
                    locx = 60;
                    locy += images[x].Height + 5;
                }
            }

         
           

        }

        private void trainNeuralNetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            nn = new NeuralNet(64 * 64, 64, 10);
            MessageBox.Show("This will take a bit of time!");
            timer1.Enabled = true;
            progressBar1.Value = 0;
            progressBar1.Maximum = maxEpochs;
            progressBar1.Visible = true;
            Thread hilo = new Thread(new ThreadStart(trainstep));
            hilo.Start();
        }

        private void trainstep()
        {
            this.Invoke((MethodInvoker)delegate {
                progressBar1.Value = 0;
                progressBar1.Maximum = maxEpochs;
                progressBar1.Visible = true;
            });

        
            int[] order = Enumerable.Range(0, images.Length).ToArray();
            Random rng = new Random();

            for (int epoch = 0; epoch < maxEpochs; epoch++)
            {
    
                for (int i = order.Length - 1; i > 0; i--)
                {
                    int swapIndex = rng.Next(i + 1);
                    int temp = order[i];
                    order[i] = order[swapIndex];
                    order[swapIndex] = temp;
                }

                for (int idx = 0; idx < order.Length; idx++)
                {
                    int a = order[idx];
                    Bitmap b = images[a];

                    for (int x = 0; x < b.Width; x++)
                    {
                        for (int y = 0; y < b.Height; y++)
                        {
                            Color pixel = b.GetPixel(x, y);
                            int inputIndex = (y * b.Width) + x;
                            nn.setInputs(inputIndex, pixel.R / 255.0);
                        }
                    }

                    string prefix = Path.GetFileNameWithoutExtension(fnames[a]).Split('_')[0].ToLower();

                    int targetDigit;
                    switch (prefix)
                    {
                        case "zero": case "0": targetDigit = 0; break;
                        case "one": case "1": targetDigit = 1; break;
                        case "two": case "2": targetDigit = 2; break;
                        case "three": case "3": targetDigit = 3; break;
                        case "four": case "4": targetDigit = 4; break;
                        case "five": case "5": targetDigit = 5; break;
                        case "six": case "6": targetDigit = 6; break;
                        case "seven": case "7": targetDigit = 7; break;
                        case "eight": case "8": targetDigit = 8; break;
                        case "nine": case "9": targetDigit = 9; break;
                        default: throw new ArgumentException("Unknown digit name: " + prefix);
                    }

                    for (int d = 0; d < 10; d++)
                    {
                        nn.setDesiredOutput(d, d == targetDigit ? 1.0 : 0.0);
                    }

                    nn.learn();
                }

                int currentEpoch = epoch + 1;
                this.Invoke((MethodInvoker)delegate {
                    if (currentEpoch <= progressBar1.Maximum)
                    {
                        progressBar1.Value = currentEpoch;
                    }
                });
            }

            this.Invoke((MethodInvoker)delegate {
                MessageBox.Show("Training Complete");
                progressBar1.Visible = false;
            });
        }

        private void saveWeightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                nn.saveWeights(saveFileDialog1.FileName);
            }
        }

        private void loadWeightsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                nn.loadWeights(openFileDialog2.FileName);
                MessageBox.Show("Weights loaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            nn.loadWeights(openFileDialog2.FileName);
        }

        private void loadImageToCompareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            using (predict modalForm = new predict(nn))
            {
                modalForm.ShowDialog(this);
            }
        }
    }
}
