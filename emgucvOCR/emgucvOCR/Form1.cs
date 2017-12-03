using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Emgu.CV.OCR;
namespace emgucvOCR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private VideoCapture capture;
        private bool isProcess = false;
        private bool isOstu = false;
        private bool isGray = false;
        private bool isSobel = false;
        private bool isCanny = false;
        private bool isOcr = false;
        private bool isMedianBlur = false;
        private Rectangle Rect = new Rectangle();
        private Point RectStartPoint;
        Mat src;
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                capture = new VideoCapture();
                if (capture != null)
                {
                    if (isProcess)
                    {
                        Application.Idle -= new EventHandler(ProcessFrame);
                        this.btnStart.Text = "Start";
                    }
                    else
                    {
                        Application.Idle += new EventHandler(ProcessFrame);
                        this.btnStart.Text = "Stop";
                    }
                    isProcess = !isProcess;
                }
            }
            catch (NullReferenceException expt)
            {
                MessageBox.Show(expt.Message);
            }
        }
        private void ProcessFrame(object sender, EventArgs arg)
        {
            Mat src = capture.QueryFrame();
            imageBox1.Image = src;
            if(isOstu == true)
            {
                Size sz = src.Size;
                Mat[] mat = src.Split();
                Mat dst = new Mat(sz, DepthType.Cv8U, 1);
                CvInvoke.CvtColor(src, dst, ColorConversion.Bgr2Gray);
                CvInvoke.Threshold(dst, dst, 0, 255, ThresholdType.Binary | ThresholdType.Otsu);
                imageBox2.Image = dst;

            }
            else if (isGray == true)
            {
                Size sz = src.Size;
                Mat[] mat = src.Split();
                Mat dst = new Mat(sz, DepthType.Cv8U, 1);
                CvInvoke.CvtColor(src, dst, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                //CvInvoke.Threshold(dst, dst, 0, 255, ThresholdType.Binary | ThresholdType.Otsu);
                imageBox2.Image = dst;

            }
            else if(isSobel == true)
            {
                int scale = 1;
                int delta = 0;
                Size sz = src.Size;
                Mat[] mat = src.Split();
                Mat gray = new Mat(sz, DepthType.Cv8U, 1);
                Mat grad = new Mat(sz, DepthType.Cv8U, 1);
                Mat grad_x = new Mat(sz, DepthType.Cv8U, 1), grad_y = new Mat(sz, DepthType.Cv8U, 1);
                Mat abs_grad_x = new Mat(sz, DepthType.Cv8U, 1), abs_grad_y = new Mat(sz, DepthType.Cv8U, 1);
                CvInvoke.CvtColor(src, gray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);
                CvInvoke.Sobel(gray, grad_x, Emgu.CV.CvEnum.DepthType.Cv16S, 1, 0, 3, scale, delta, Emgu.CV.CvEnum.BorderType.Default);
                CvInvoke.ConvertScaleAbs(grad_x, abs_grad_x, 1.0, 0.0);
                CvInvoke.Sobel(gray, grad_y, Emgu.CV.CvEnum.DepthType.Cv16S, 0, 1, 3, scale, delta, Emgu.CV.CvEnum.BorderType.Default);
                CvInvoke.ConvertScaleAbs(grad_y, abs_grad_y, 1.0, 0.0);
                CvInvoke.AddWeighted(abs_grad_x, 0.5, abs_grad_y, 0.5, 0, grad);
                imageBox2.Image = grad;
            }
            else if (isCanny == true)
            {
                Size sz = src.Size;
                Mat[] mat = src.Split();
                Mat dst = new Mat(sz, DepthType.Cv8U, 1);
                CvInvoke.CvtColor(src, dst, ColorConversion.Bgr2Gray);
                CvInvoke.Canny(dst, dst, 50, 150, 3);
                //CvInvoke.Threshold(dst, dst, 0, 255, ThresholdType.Binary | ThresholdType.Otsu);
                imageBox2.Image = dst;
            }else if(isMedianBlur == true)
            {
                Size sz = src.Size;
                Mat[] mat = src.Split();
                Mat dst = new Mat(sz, DepthType.Cv8U, 3);
                CvInvoke.MedianBlur(src, dst, 5);
                imageBox2.Image = dst;
            }
            else if(isOcr == true)
            {
                Image<Bgr, byte> img;
                img = new Image<Bgr, byte>(imageBox1.Image.Bitmap);
                //imgEntrada.Draw(Rect, new Bgr(Color.Red), 3);
                img.ROI = Rect;
                Tesseract tess;
                //tess = new Tesseract("tessdata", "eng", Tesseract.OcrEngineMode.OEM_TESSERACT_CUBE_COMBINED);
                tess = new Tesseract(@"tessdata\", "eng", OcrEngineMode.TesseractLstmCombined);
                tess.SetVariable("tessedit_char_whitelist", "1234567890");
                Tesseract.Character[] words;
                Mat dst = new Mat(img.Size, DepthType.Cv8U, 1);
                CvInvoke.CvtColor(img.Mat, dst, ColorConversion.Bgr2Gray);
                //CvInvoke.Threshold(dst, dst, 0, 255, ThresholdType.Binary | ThresholdType.Otsu);
                CvInvoke.Canny(dst, dst, 50, 150, 3);
                //threshold(dst1, dst2, 128, 255, THRESH_BINARY_INV);
                CvInvoke.Threshold(dst, dst, 128, 255, ThresholdType.BinaryInv);
                tess.SetImage(dst);
                tess.Recognize();
                words = tess.GetCharacters();
                imageBox2.Image = dst;
                txtOcr.Text = tess.GetUTF8Text();
            }
            else
            {
                imageBox2.Image = src;
            }

        }
        private void btnOtsu_Click(object sender, EventArgs e)
        {
            isOstu = true;
            isGray = false;
            isSobel = false;
            isCanny = false;
            isMedianBlur = false;

            isOcr = false;
        }

        private void btnGray_Click(object sender, EventArgs e)
        {
            isGray = true;
            isOstu = false;
            isSobel = false;
            isCanny = false;
            isMedianBlur = false;

            isOcr = false;
        }

        private void btnSobel_Click(object sender, EventArgs e)
        {
            isSobel = true;
            isGray = false;
            isOstu = false;
            isCanny = false;
            isMedianBlur = false;

            isOcr = false;
        }

        private void btnCanny_Click(object sender, EventArgs e)
        {
            isCanny = true;
            isSobel = false;
            isGray = false;
            isOstu = false;
            isMedianBlur = false;

            isOcr = false;
        }

        private void imageBox1_DoubleClick(object sender, EventArgs e)
        {
            Rect = new Rectangle();
            ((PictureBox)sender).Invalidate();
        }

        private void imageBox1_Paint(object sender, PaintEventArgs e)
        {
            if(imageBox1 != null)
            {
                if (Rect != null && Rect.Width > 0 && Rect.Height > 0)
                {
                    e.Graphics.SetClip(Rect, System.Drawing.Drawing2D.CombineMode.Exclude);
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(128, 64, 64, 64)), new Rectangle(0, 0, ((PictureBox)sender).Width, ((PictureBox)sender).Height));
                }

            }
        }

        private void imageBox1_MouseDown(object sender, MouseEventArgs e)
        {
            RectStartPoint = e.Location;
            Invalidate();
        }

        private void imageBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void imageBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;
            Point tempEndPoint = e.Location;
            Rect.Location = new Point(
                Math.Min(RectStartPoint.X, tempEndPoint.X),
                Math.Min(RectStartPoint.Y, tempEndPoint.Y));
            Rect.Size = new Size(
                Math.Abs(RectStartPoint.X - tempEndPoint.X),
                Math.Abs(RectStartPoint.Y - tempEndPoint.Y));
        }

        private void btnOcr_Click(object sender, EventArgs e)
        {
            isOcr = true;
            isCanny = false;
            isSobel = false;
            isGray = false;
            isOstu = false;
            isMedianBlur = false;
        }

        private void btnMedianBlur_Click(object sender, EventArgs e)
        {
            isMedianBlur = true;

            isOcr = false;
            isCanny = false;
            isSobel = false;
            isGray = false;
            isOstu = false;
        }
    }
}
