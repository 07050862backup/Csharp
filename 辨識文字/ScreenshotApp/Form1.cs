using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Tesseract;
using static System.Windows.Forms.DataFormats;

namespace ScreenshotApp
{
    public partial class Form1 : Form
    {
        private PictureBox pictureBox1;
        private Button ocrButton;
        public Form1()
        {
            InitializeComponent();

            // Create a new button
            Button captureButton = new Button();
            captureButton.Text = "擷取畫面";
            captureButton.Location = new Point(10, 10);
            captureButton.Size = new Size(100, 30); // Set the size of the button
            captureButton.Font = new Font(captureButton.Font.FontFamily, 10); // Set the font size of the button text
            captureButton.Click += captureButton_Click;
            this.Controls.Add(captureButton);
            Icon icon = new Icon("logo.ico");
            this.Icon = icon;
            // Create a new button
            ocrButton = new Button();
            ocrButton.Text = "辨識文字";
            ocrButton.Location = new Point(125, 10);
            ocrButton.Size = new Size(100, 30);
            ocrButton.Font = new Font(ocrButton.Font.FontFamily, 10);
            ocrButton.Click += ocrButton_Click;
            this.Controls.Add(ocrButton);

            // Create a new picture box
            pictureBox1 = new PictureBox();
            pictureBox1.Location = new Point(10, 50);
            pictureBox1.Size = new Size(780, 390);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(pictureBox1);
        }
        private Bitmap capturedImage;
        private Form2 currentForm2; // To store the reference to the current instance of Form2

        private void ocrButton_Click(object sender, EventArgs e)
        {
            string extractedText = ExtractTextFromImage(capturedImage);

            if (currentForm2 != null)
            {
                currentForm2.Close();
            }
            currentForm2 = new Form2();
            //string extractedText = "這是從圖像中識別出的文本。";

            currentForm2.SetText(extractedText);
            currentForm2.Show();
        }

        private void captureButton_Click(object sender, EventArgs e)
        {
            // Create a new full-screen semi-transparent form
            Form overlayForm = new Form();
            overlayForm.FormBorderStyle = FormBorderStyle.None;
            overlayForm.WindowState = FormWindowState.Maximized;
            overlayForm.TopMost = true;
            overlayForm.Opacity = 0.5;
            overlayForm.MouseDown += overlayForm_MouseDown;
            overlayForm.MouseMove += overlayForm_MouseMove;
            overlayForm.MouseUp += overlayForm_MouseUp;
            overlayForm.Paint += overlayForm_Paint;
            overlayForm.ShowDialog();
        }

        private Point startPoint; // Starting point of the selection
        private Rectangle selectionRect; // To store the selection rectangle
        private bool selecting; // To indicate if the user is selecting

        private void overlayForm_MouseDown(object sender, MouseEventArgs e)
        {
            // Start the selection
            selecting = true;
            startPoint = e.Location;
            selectionRect = new Rectangle(startPoint, Size.Empty); // Initialize the rectangle
        }

        private void overlayForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (selecting)
            {
                // Calculate the selection rectangle
                selectionRect = new Rectangle(startPoint.X, startPoint.Y, e.X - startPoint.X, e.Y - startPoint.Y);
                (sender as Form).Invalidate();
            }
        }

        private void overlayForm_MouseUp(object sender, MouseEventArgs e)
        {
            // End the selection
            selecting = false;

            // Hide the form temporarily to capture the screen
            (sender as Form).Hide();

            Bitmap bitmap = new Bitmap(selectionRect.Width, selectionRect.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.CopyFromScreen(selectionRect.Location, Point.Empty, selectionRect.Size);
                pictureBox1.Image = bitmap;
                (sender as Form).Close();
                this.Activate();
                this.Focus();
                this.BringToFront();
                this.TopMost = true;
                this.TopMost = false;
                this.WindowState = FormWindowState.Normal;
                this.WindowState = FormWindowState.Maximized;
                this.WindowState = FormWindowState.Normal;
                this.WindowState = FormWindowState.Maximized;
                this.WindowState = FormWindowState.Normal;
                capturedImage = bitmap;
                ocrButton.PerformClick();

                // Extract the text from the captured image using OCR
                //string extractedText = ExtractTextFromImage(bitmap);

                // TODO: Do something with the extracted text
            }
        }
        private string ExtractTextFromImage(Bitmap image)
        {


            using (var engine = new TesseractEngine(Application.StartupPath + @"\tessdata", "chi_tra", EngineMode.Default))
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    image.Save(stream, System.Drawing.Imaging.ImageFormat.Tiff);
                    stream.Position = 0;

                    using (var pix = Pix.LoadTiffFromMemory(stream.ToArray()))
                    {
                        using (var page = engine.Process(pix))
                        {
                            return page.GetText();
                        }
                    }
                }
            }
        }


        private void overlayForm_Paint(object sender, PaintEventArgs e)
        {
            if (selecting)
            {
                // Draw the selection rectangle
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, selectionRect);
                }
            }
        }
    }
}