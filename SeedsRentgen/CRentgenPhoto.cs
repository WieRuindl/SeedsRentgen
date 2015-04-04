using System.Drawing;

namespace SeedsRentgen
{
    class CRentgenPhoto
    {
        private Bitmap _photoOriginal;
        private Bitmap _photoBase;
        private Bitmap _photoBrightness;
        private Bitmap _photoBW;

        public Bitmap PhotoBrightness
        {
            get
            {
                return new Bitmap(_photoBrightness);
            }
        }
        public Bitmap PhotoBW
        {
            get
            {
                return new Bitmap(_photoBW);
            }
        }

        public void Refresh()
        {
            _photoBase = new Bitmap(_photoOriginal);
            _photoBrightness = SCImageProcessing.ChangeBrightness(_photoBase, SeedsRentgen.Properties.Settings.Default.brightness);
            _photoBW = SCImageProcessing.ChangeTreshold(_photoBrightness, SeedsRentgen.Properties.Settings.Default.blackTreshold, SeedsRentgen.Properties.Settings.Default.whiteTreshold);
        }

        public CRentgenPhoto(Bitmap image, Size targetSize)
        {
            //подготовительные функции
            _photoOriginal = SCImageProcessing.MedianFilter(
                SCImageProcessing.ColorToGray(
                SCImageProcessing.ChangeSize(image, targetSize)
                ));

            Refresh();
        }

        public void ChangeTreshold(int black, int white)
        {
            _photoBW = SCImageProcessing.ChangeTreshold(_photoBrightness, black, white);
        }

        public void ChangeBrightness(double coefficient)
        {
            _photoBrightness = SCImageProcessing.ChangeBrightness(_photoBase, coefficient);
        }

        public void CutImage(Rectangle areaToCut)
        {
            _photoBase = SCImageProcessing.CutImage(_photoBase, areaToCut);
            _photoBrightness = SCImageProcessing.CutImage(_photoBrightness, areaToCut);
            _photoBW = SCImageProcessing.CutImage(_photoBW, areaToCut);
        }
    }
}
