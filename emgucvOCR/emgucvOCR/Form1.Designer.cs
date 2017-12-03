namespace emgucvOCR
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
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.imageBox2 = new Emgu.CV.UI.ImageBox();
            this.btnOtsu = new System.Windows.Forms.Button();
            this.btnGray = new System.Windows.Forms.Button();
            this.btnSobel = new System.Windows.Forms.Button();
            this.btnCanny = new System.Windows.Forms.Button();
            this.btnOcr = new System.Windows.Forms.Button();
            this.txtOcr = new System.Windows.Forms.TextBox();
            this.btnMedianBlur = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox1.Location = new System.Drawing.Point(12, 39);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(640, 480);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            this.imageBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.imageBox1_Paint);
            this.imageBox1.DoubleClick += new System.EventHandler(this.imageBox1_DoubleClick);
            this.imageBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.imageBox1_MouseDown);
            this.imageBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.imageBox1_MouseMove);
            this.imageBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageBox1_MouseUp);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(13, 546);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // imageBox2
            // 
            this.imageBox2.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageBox2.Location = new System.Drawing.Point(668, 39);
            this.imageBox2.Name = "imageBox2";
            this.imageBox2.Size = new System.Drawing.Size(640, 480);
            this.imageBox2.TabIndex = 2;
            this.imageBox2.TabStop = false;
            // 
            // btnOtsu
            // 
            this.btnOtsu.Location = new System.Drawing.Point(749, 558);
            this.btnOtsu.Name = "btnOtsu";
            this.btnOtsu.Size = new System.Drawing.Size(75, 23);
            this.btnOtsu.TabIndex = 4;
            this.btnOtsu.Text = "Otsu";
            this.btnOtsu.UseVisualStyleBackColor = true;
            this.btnOtsu.Click += new System.EventHandler(this.btnOtsu_Click);
            // 
            // btnGray
            // 
            this.btnGray.Location = new System.Drawing.Point(668, 558);
            this.btnGray.Name = "btnGray";
            this.btnGray.Size = new System.Drawing.Size(75, 23);
            this.btnGray.TabIndex = 5;
            this.btnGray.Text = "Gray";
            this.btnGray.UseVisualStyleBackColor = true;
            this.btnGray.Click += new System.EventHandler(this.btnGray_Click);
            // 
            // btnSobel
            // 
            this.btnSobel.Location = new System.Drawing.Point(831, 557);
            this.btnSobel.Name = "btnSobel";
            this.btnSobel.Size = new System.Drawing.Size(75, 23);
            this.btnSobel.TabIndex = 6;
            this.btnSobel.Text = "Sobel";
            this.btnSobel.UseVisualStyleBackColor = true;
            this.btnSobel.Click += new System.EventHandler(this.btnSobel_Click);
            // 
            // btnCanny
            // 
            this.btnCanny.Location = new System.Drawing.Point(913, 557);
            this.btnCanny.Name = "btnCanny";
            this.btnCanny.Size = new System.Drawing.Size(75, 23);
            this.btnCanny.TabIndex = 7;
            this.btnCanny.Text = "Canny";
            this.btnCanny.UseVisualStyleBackColor = true;
            this.btnCanny.Click += new System.EventHandler(this.btnCanny_Click);
            // 
            // btnOcr
            // 
            this.btnOcr.Location = new System.Drawing.Point(668, 604);
            this.btnOcr.Name = "btnOcr";
            this.btnOcr.Size = new System.Drawing.Size(75, 23);
            this.btnOcr.TabIndex = 8;
            this.btnOcr.Text = "Ocr";
            this.btnOcr.UseVisualStyleBackColor = true;
            this.btnOcr.Click += new System.EventHandler(this.btnOcr_Click);
            // 
            // txtOcr
            // 
            this.txtOcr.Location = new System.Drawing.Point(668, 665);
            this.txtOcr.Multiline = true;
            this.txtOcr.Name = "txtOcr";
            this.txtOcr.ReadOnly = true;
            this.txtOcr.Size = new System.Drawing.Size(536, 81);
            this.txtOcr.TabIndex = 9;
            // 
            // btnMedianBlur
            // 
            this.btnMedianBlur.Location = new System.Drawing.Point(994, 558);
            this.btnMedianBlur.Name = "btnMedianBlur";
            this.btnMedianBlur.Size = new System.Drawing.Size(106, 23);
            this.btnMedianBlur.TabIndex = 10;
            this.btnMedianBlur.Text = "medianBlur";
            this.btnMedianBlur.UseVisualStyleBackColor = true;
            this.btnMedianBlur.Click += new System.EventHandler(this.btnMedianBlur_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1310, 776);
            this.Controls.Add(this.btnMedianBlur);
            this.Controls.Add(this.txtOcr);
            this.Controls.Add(this.btnOcr);
            this.Controls.Add(this.btnCanny);
            this.Controls.Add(this.btnSobel);
            this.Controls.Add(this.btnGray);
            this.Controls.Add(this.btnOtsu);
            this.Controls.Add(this.imageBox2);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.imageBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button btnStart;
        private Emgu.CV.UI.ImageBox imageBox2;
        private System.Windows.Forms.Button btnOtsu;
        private System.Windows.Forms.Button btnGray;
        private System.Windows.Forms.Button btnSobel;
        private System.Windows.Forms.Button btnCanny;
        private System.Windows.Forms.Button btnOcr;
        private System.Windows.Forms.TextBox txtOcr;
        private System.Windows.Forms.Button btnMedianBlur;
    }
}

