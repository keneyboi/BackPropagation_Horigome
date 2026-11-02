namespace number_recognizer_horigome
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuralNetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToCompareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trainNeuralNetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveWeightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadWeightsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationToolStripMenuItem,
            this.neuralNetToolStripMenuItem,
            this.imageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(778, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.applicationToolStripMenuItem.Text = "Application";
            // 
            // neuralNetToolStripMenuItem
            // 
            this.neuralNetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trainNeuralNetToolStripMenuItem,
            this.saveWeightsToolStripMenuItem,
            this.loadWeightsToolStripMenuItem});
            this.neuralNetToolStripMenuItem.Name = "neuralNetToolStripMenuItem";
            this.neuralNetToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.neuralNetToolStripMenuItem.Text = "Neural Net";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImagesToolStripMenuItem,
            this.loadImageToCompareToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // loadImagesToolStripMenuItem
            // 
            this.loadImagesToolStripMenuItem.Name = "loadImagesToolStripMenuItem";
            this.loadImagesToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.loadImagesToolStripMenuItem.Text = "Load Image/s";
            this.loadImagesToolStripMenuItem.Click += new System.EventHandler(this.loadImagesToolStripMenuItem_Click);
            // 
            // loadImageToCompareToolStripMenuItem
            // 
            this.loadImageToCompareToolStripMenuItem.Name = "loadImageToCompareToolStripMenuItem";
            this.loadImageToCompareToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadImageToCompareToolStripMenuItem.Text = "Draw Number ";
            this.loadImageToCompareToolStripMenuItem.Click += new System.EventHandler(this.loadImageToCompareToolStripMenuItem_Click);
            // 
            // trainNeuralNetToolStripMenuItem
            // 
            this.trainNeuralNetToolStripMenuItem.Name = "trainNeuralNetToolStripMenuItem";
            this.trainNeuralNetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.trainNeuralNetToolStripMenuItem.Text = "Train Neural Net";
            this.trainNeuralNetToolStripMenuItem.Click += new System.EventHandler(this.trainNeuralNetToolStripMenuItem_Click);
            // 
            // saveWeightsToolStripMenuItem
            // 
            this.saveWeightsToolStripMenuItem.Name = "saveWeightsToolStripMenuItem";
            this.saveWeightsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveWeightsToolStripMenuItem.Text = "Save Weights";
            this.saveWeightsToolStripMenuItem.Click += new System.EventHandler(this.saveWeightsToolStripMenuItem_Click);
            // 
            // loadWeightsToolStripMenuItem
            // 
            this.loadWeightsToolStripMenuItem.Name = "loadWeightsToolStripMenuItem";
            this.loadWeightsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.loadWeightsToolStripMenuItem.Text = "Load Weights";
            this.loadWeightsToolStripMenuItem.Click += new System.EventHandler(this.loadWeightsToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(53, 41);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(665, 23);
            this.progressBar1.TabIndex = 1;
            this.progressBar1.Visible = false;
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            this.openFileDialog2.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog2_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 450);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuralNetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trainNeuralNetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveWeightsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadWeightsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImageToCompareToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
    }
}

