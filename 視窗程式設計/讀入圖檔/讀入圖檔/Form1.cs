using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 讀入圖檔
{
    public partial class Form1 : Form
    {
        private int imageH;
        private int imageW;
        private Image rgbImage;
        private Image rImage;
        private Image gImage;
        private Image bImage;
        private Image grayImage;
        private Image thresholdingImage;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rgbImage = Image.FromFile(ofd.FileName);
                rImage = (Image)GetRChannel(new Bitmap(rgbImage));
                gImage = (Image)GetGChannel(new Bitmap(rgbImage));
                bImage = (Image)GetBChannel(new Bitmap(rgbImage));
                RGBtoGray(rgbImage,ref grayImage);
                thresholdingImage = Image.FromFile(ofd.FileName);
                if (rgbImage.Width > rgbImage.Height)
                    pictureBox1.Height = 400 * rgbImage.Height / rgbImage.Width;
                else
                    pictureBox1.Width = 400 * rgbImage.Width / rgbImage.Height;
                imageH = pictureBox1.Height;
                imageW = pictureBox1.Width;
                pictureBox1.Image = rgbImage;
                HScrollBar1.Value = 100;
                radioButton2.Checked = true;//RGB888

                comboBox1.SelectedIndex = 0;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
            }
        }

        private Image GetRChannel(Bitmap bm)
        {
            Bitmap newBitmap = new Bitmap(bm.Width, bm.Height);
            for(int y = 0; y < bm.Height ; y++)
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    Color pixelColor = bm.GetPixel(x, y);
                    newBitmap.SetPixel(x, y, Color.FromArgb(pixelColor.R, 0, 0));
                }
            }
            return newBitmap;
        }
        private Image GetGChannel(Bitmap bm)
        {
            Bitmap newBitmap = new Bitmap(bm.Width, bm.Height);
            for (int y = 0; y < bm.Height; y++)
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    Color pixelColor = bm.GetPixel(x, y);
                    newBitmap.SetPixel(x, y, Color.FromArgb(0, pixelColor.G, 0));
                }
            }
            return newBitmap;
        }
        private Image GetBChannel(Bitmap bm)
        {
            Bitmap newBitmap = new Bitmap(bm.Width, bm.Height);
            for (int y = 0; y < bm.Height; y++)
            {
                for (int x = 0; x < bm.Width; x++)
                {
                    Color pixelColor = bm.GetPixel(x, y);
                    newBitmap.SetPixel(x, y, Color.FromArgb(0, 0, pixelColor.B));
                }
            }
            return newBitmap;
        }

        private void RGBtoGray(Image source, ref Image dest)
        {
            Bitmap sourceBitmap = (Bitmap)source;
            dest = (Image)source.Clone();
            Bitmap destBitmap = (Bitmap)dest;
            for(int y = 0;y<sourceBitmap.Height;y++)
            {
                for (int x = 0; x < sourceBitmap.Width; x++)
                {
                    Color pixelColor = sourceBitmap.GetPixel(x, y);
                    int pixelLuminance = (int)(pixelColor.R * 0.2126 + pixelColor.G * 0.7152 + pixelColor.B * 0.0722);
                    destBitmap.SetPixel(x, y, Color.FromArgb(pixelLuminance, pixelLuminance, pixelLuminance));
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            HScrollBar1.Maximum = 109;
            HScrollBar1.Minimum = 1;
            comboBox1.Items.Add("RGB Channel");
            comboBox1.Items.Add("R Channel");
            comboBox1.Items.Add("G Channel");
            comboBox1.Items.Add("B Channel");
            numericUpDown1.Maximum = 255;
            numericUpDown1.Minimum = -1;
            numericUpDown2.Maximum = 255;
            numericUpDown2.Minimum = -1;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

      

        private void ZoomHScroll(object sender, ScrollEventArgs e)
        {
            pictureBox1.Height = (int)(imageH / 100.0 * HScrollBar1.Value);
            pictureBox1.Width = (int)(imageW / 100.0 * HScrollBar1.Value);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                pictureBox1.Image = grayImage;
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                numericUpDown1.Value = 100;
                numericUpDown2.Value = -1;
                checkBox1.Checked = false;
            }
            else if(radioButton2.Checked)
            {
                pictureBox1.Image = rgbImage;
                comboBox1.SelectedIndex = 0;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
            }
        }

        private void ChannelSelectChanged(object sender, EventArgs e)
        {
            switch(comboBox1.SelectedIndex)
            {
                case 0:
                    pictureBox1.Image = rgbImage;
                    break;
                case 1:
                    pictureBox1.Image = rImage;
                    break;
                case 2:
                    pictureBox1.Image = gImage;
                    break;
                case 3:
                    pictureBox1.Image = bImage;
                    break;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                GetThresholdingImage(rgbImage, ref thresholdingImage,
                    (int)numericUpDown1.Value, (int)numericUpDown2.Value, checkBox2.Checked);
                pictureBox1.Image = thresholdingImage;
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
            }
            else
            {
                pictureBox1.Image = grayImage;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;

            }
        }

        private void NumValueChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                GetThresholdingImage(rgbImage, ref thresholdingImage,
                    (int)numericUpDown1.Value, (int)numericUpDown2.Value, checkBox2.Checked);
                pictureBox1.Image = thresholdingImage;
            }
        }

        private void GetThresholdingImage(Image source, ref Image dest, int Lower, int Upper, bool reverse)
        {
            Bitmap sourceBitmap = (Bitmap)source;
            dest.Dispose();
            dest = (Image)source.Clone();
            Bitmap destBitmap = (Bitmap)dest;
            for(int y = 0;y < sourceBitmap.Height ;y++ )
            {
                for(int x = 0;x<sourceBitmap.Width ;x++ )
                {
                    Color pixelColor = sourceBitmap.GetPixel(x, y);
                    if(Upper >= 0 && Upper > Lower)
                    {
                        if (pixelColor.R > Lower && pixelColor.R < Upper)
                            if (reverse == true)
                                destBitmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            else
                                destBitmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                        else
                            if (reverse == true)
                                destBitmap.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                            else
                                destBitmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                    else
                    {
                        if(pixelColor.R > Lower)
                            if(reverse == true)
                                destBitmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                            else
                                destBitmap.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                        else
                            if (reverse == true)
                                destBitmap.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                            else
                                destBitmap.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                }
            }
        }
    }
}
