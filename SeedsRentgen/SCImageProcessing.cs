using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace SeedsRentgen
{
    static class SCImageProcessing
    {
        static public Bitmap ChangeSize(Bitmap sourceImage, Size targetSize)
        {
            Bitmap resultImage = new Bitmap(targetSize.Width, targetSize.Height);
            using (Graphics canvas = Graphics.FromImage(resultImage))
            {
                canvas.DrawImage(sourceImage, 0, 0, targetSize.Width, targetSize.Height);
            }

            return resultImage;
        }

        static public Bitmap ColorToGray(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);
            Graphics canvas = Graphics.FromImage(resultImage);

            //create the grayscale ColorMatrix
            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][] 
               {
                   new float[] {0.2125f, 0.2125f, 0.2125f, 0, 0},
                   new float[] {0.7154f, 0.7154f, 0.7154f, 0, 0},
                   new float[] {0.0721f, 0.0721f, 0.0721f, 0, 0},
                   new float[] {0, 0, 0, 1, 0},
                   new float[] {0, 0, 0, 0, 1}
               });

            //create some image attributes
            ImageAttributes attributes = new ImageAttributes();

            //set the color matrix attribute
            attributes.SetColorMatrix(colorMatrix);

            //draw the original image on the new image
            //using the grayscale color matrix
            canvas.DrawImage(sourceImage, new Rectangle(0, 0, sourceImage.Width, sourceImage.Height),
               0, 0, sourceImage.Width, sourceImage.Height, GraphicsUnit.Pixel, attributes);

            //dispose the Graphics object
            canvas.Dispose();
            return resultImage;
        }

        static public Bitmap MedianFilter(Bitmap sourceImage)
        {
            Bitmap resultImage = new Bitmap(sourceImage);

            Rectangle area = new Rectangle(0, 0, resultImage.Width, resultImage.Height);

            int nBytes = sourceImage.Width * sourceImage.Height * 3;

            BitmapData bmpDataResult = resultImage.LockBits(area, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpDataSource = sourceImage.LockBits(area, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            byte[] rgbValuesResult = new byte[nBytes]; 
            byte[] rgbValuesSource = new byte[nBytes];

            Marshal.Copy(bmpDataResult.Scan0, rgbValuesResult, 0, nBytes);
            Marshal.Copy(bmpDataSource.Scan0, rgbValuesSource, 0, nBytes);

            int widthBytes = sourceImage.Width * 3;

            for (int i = widthBytes + 3; i < rgbValuesResult.Length - widthBytes - 3; i += 3)
            {
                //if (i - widthBytes - 3 >= 0 && i + widthBytes + 3 < rgbValuesResult.Length)

                byte[] array = new byte[9];

                array[0] = rgbValuesSource[i - widthBytes - 3];
                array[1] = rgbValuesSource[i - widthBytes];
                array[2] = rgbValuesSource[i - widthBytes + 3];
                array[3] = rgbValuesSource[i - 3];
                array[4] = rgbValuesSource[i];
                array[5] = rgbValuesSource[i + 3];
                array[6] = rgbValuesSource[i + widthBytes - 3];
                array[7] = rgbValuesSource[i + widthBytes];
                array[8] = rgbValuesSource[i + widthBytes + 3];
                Array.Sort(array);

                rgbValuesResult[i] = rgbValuesResult[i + 1] =
                    rgbValuesResult[i + 2] = array[4];

            }

            Marshal.Copy(rgbValuesResult, 0, bmpDataResult.Scan0, nBytes);

            resultImage.UnlockBits(bmpDataResult);
            sourceImage.UnlockBits(bmpDataSource);

            return resultImage;
        }

        static public Bitmap ChangeBrightness(Bitmap sourceImage, double brightness)
        {
            Bitmap resultImage = new Bitmap(sourceImage);

            double baseValue = 1;
            double coeficient = brightness / 100;
            double value = baseValue + coeficient;

            double w = (double)sourceImage.Width / 2;
            double h = (double)sourceImage.Height / 2;
            double max = Math.Sqrt(Math.Pow(w, 2) + Math.Pow(h, 2));

            for (int y = 0; y < sourceImage.Height; y++)
            {
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    double distance = Math.Sqrt(Math.Pow(w - x, 2) + Math.Pow(h - y, 2));
                    double mult = distance * (value - 1) / max + 1;
                    double tempValue = mult * sourceImage.GetPixel(x, y).R;
                    byte bcolor = Convert.ToByte(Math.Round(tempValue));
                    Color color = Color.FromArgb(bcolor, bcolor, bcolor);

                    resultImage.SetPixel(x, y, color);
                }
            }

            return resultImage;
        }

        static public Bitmap ChangeTreshold(Bitmap sourceImage, int black, int white)
        {
            Bitmap resultImage = new Bitmap(sourceImage);

            Rectangle area = new Rectangle(0, 0, resultImage.Width, resultImage.Height);
            BitmapData bmpData = resultImage.LockBits(area, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int nBytes = sourceImage.Width * sourceImage.Height * 3;             
            byte[] rgbValues = new byte[nBytes];

            Marshal.Copy(bmpData.Scan0, rgbValues, 0, nBytes);

            for (int i = 0; i < rgbValues.Length; i += 3)
            {
                byte color;
                if (rgbValues[i] < black) color = Color.Black.R;
                else if (rgbValues[i] < white) color = Color.Gray.R;
                else color = Color.White.R;

                rgbValues[i] = rgbValues[i + 1] = rgbValues[i + 2] = color;
            }

            Marshal.Copy(rgbValues, 0, bmpData.Scan0, nBytes);

            resultImage.UnlockBits(bmpData);

            return resultImage;
        }

        static public Bitmap CutImage(Bitmap sourceImage, Rectangle area)
        {
            Bitmap resultImage = new Bitmap(area.Width, area.Height);

            Graphics graphics = Graphics.FromImage(resultImage);
            graphics.DrawImage(sourceImage, 0, 0, area, GraphicsUnit.Pixel);

            return resultImage;
        }

        static public Bitmap ColorizePhoto(Bitmap sourceImage, List<CArea> elements)
        {
            Bitmap resultImage = new Bitmap(sourceImage);

            List<CArea> husks = new List<CArea>();
            List<CArea> seeds = new List<CArea>();

            foreach (CArea element in elements)
            {
                if (Color.White.R == element.Color)
                {
                    seeds.Add(element);
                }
                else
                {
                    husks.Add(element);
                }
            }

            resultImage = Colorize(resultImage, husks, SeedsRentgen.Properties.Settings.Default.colorHusk);
            resultImage = Colorize(resultImage, seeds, SeedsRentgen.Properties.Settings.Default.colorSeed);

            return resultImage;
        }

        static private Bitmap Colorize(Bitmap sourceImage, List<CArea> elements, Color inputColor)
        {
            Bitmap resultImage = new Bitmap(sourceImage);

            foreach (CArea element in elements)
            {
                List<Point> points = element.GetPoints();

                foreach (Point p in points)
                {
                    Color pColor = sourceImage.GetPixel(p.X, p.Y);

                    Color color = Color.FromArgb(
                        Convert.ToByte(Math.Round((inputColor.R + pColor.R) * 0.5)),
                        Convert.ToByte(Math.Round((inputColor.G + pColor.G) * 0.5)),
                        Convert.ToByte(Math.Round((inputColor.B + pColor.B) * 0.5)));
                        
                    resultImage.SetPixel(p.X, p.Y, color);
                }
            }

            return resultImage;
        }

        static public Bitmap NumberizePhoto(Bitmap sourceImage, List<CSeed> seeds)
        {
            Bitmap resultImage = new Bitmap(sourceImage);
            Graphics canvas = Graphics.FromImage(resultImage);

            Pen pen = new Pen(SeedsRentgen.Properties.Settings.Default.colorFrame);
            Font font = new Font("Arial", 14);
            Brush brush = new SolidBrush(SeedsRentgen.Properties.Settings.Default.colorFrame);

            foreach (CSeed seed in seeds)
            {
                canvas.DrawRectangle(pen, seed.Frame);
                canvas.DrawString(seed.Number.ToString(), font, brush, new PointF(seed.Frame.X + 1, seed.Frame.Y + 1));          
            }

            return resultImage;
        }

    }
}
