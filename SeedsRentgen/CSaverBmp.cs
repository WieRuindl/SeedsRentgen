using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SeedsRentgen
{
    class CSaverBmp : ISave
    {
        private String _fileName;

        public CSaverBmp(String directoryName, String fileName)
        {
            _fileName = directoryName + "\\" + fileName + " - пронумеровано.bmp";
        }

        public void Save(object obj)
        {
            Bitmap image = (Bitmap)obj;

            image.Save(_fileName, ImageFormat.Bmp);
        }
    }
}
