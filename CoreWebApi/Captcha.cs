using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace CoreWebApi
{
    public class Captcha3
    {
         
        public string Generate(Stream stream)
        {
            string captcha = GenerateRandomString();
            int height = 25;
            int width = 90;
            using (Bitmap bmp = new Bitmap(width, height))
            {
                RectangleF rectf = new RectangleF(30, 5, 0, 0);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.Clear(Color.White);
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.DrawString(captcha, new Font("Georgia", 12, FontStyle.Italic), Brushes.Blue, rectf);
                    g.DrawRectangle(new Pen(Color.BurlyWood), 1, 1, width - 2, height - 2);
                    g.Flush();
                    bmp.Save(stream, ImageFormat.Jpeg);
                }
            }
            return captcha;
        }
        private string GenerateRandomString()
        {
            Random random = new Random();
            string combination = "0123456789";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 4; i++)
            sb.Append(combination[random.Next(combination.Length)]);
            return sb.ToString();
        }
    }
}