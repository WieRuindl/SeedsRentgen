using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SeedsRentgen
{
    class CAreaFinder
    {
        private Bitmap _photoBW;

        private CArea _seed;

        private bool[,] _isFree;
        private bool[,] _isFreeGray;
        static private bool[,] _isFreeWhite;

        private int _warningCount;
        private bool _warningAnswerIsYes;
        private int _recursionTreshold;
        private List<Point> _controlList;

        public CAreaFinder(Size photoBW)
        {
            _isFreeWhite = new bool[photoBW.Width, photoBW.Height];
            _isFreeGray = new bool[photoBW.Width, photoBW.Height];

            for (int x = 0; x < photoBW.Width; x++)
            {
                for (int y = 0; y < photoBW.Height; y++)
                {
                    _isFreeWhite[x, y] = true;
                    _isFreeGray[x, y] = true;
                }
            }
        }

        public CArea GetArea(Bitmap photoBW, int x, int y)
        {
            if (_photoBW != null) _photoBW.Dispose();
            _photoBW = new Bitmap(photoBW);

            _seed = new CArea(_photoBW.GetPixel(x, y).R);
            _isFree = (Color.White.R == _seed.Color) ? _isFreeWhite : _isFreeGray;

            _controlList = new List<Point>();
            _controlList.Add(new Point(x, y));
            _recursionTreshold = 0;
            _warningCount = 0;
            _warningAnswerIsYes = true;

            while (_controlList.Count > 0 && _warningAnswerIsYes)
            {
                Point p = _controlList[_controlList.Count - 1];
                _controlList.Remove(p);

                RecursionSearching(p.X, p.Y);
            }

            if (!_warningAnswerIsYes)
            {
                RestoreControlMatrix(_seed);
            }

            return (0 < _seed.GetPoints().Count && _warningAnswerIsYes) ? _seed : null;
        }

        public void RestoreControlMatrix(CArea seed)
        {
            Point[] points = seed.GetPoints().ToArray();

            _isFree = (Color.White.R == seed.Color) ? _isFreeWhite : _isFreeGray;

            foreach (var p in points)
            {
                _isFree[p.X, p.Y] = true;
            }
        }

        private void ShowWarningMessage()
        {
            if (DialogResult.No == MessageBox.Show(
                SeedsRentgen.Properties.Resources.messageAreaWarningBody,
                SeedsRentgen.Properties.Resources.messageAreaWarningHeader,
                    System.Windows.Forms.MessageBoxButtons.YesNo)
                    )
            {
                _warningAnswerIsYes = false;
                return;
            }
        }

        private void RecursionSearching(int x, int y)
        {
            if (!_warningAnswerIsYes) return;


            if (_warningCount++ == SeedsRentgen.Properties.Settings.Default.valueWarning)
            {
                ShowWarningMessage();
            }

            if (_recursionTreshold++ < SeedsRentgen.Properties.Settings.Default.valueMaxRecursion)
            {
                if (_photoBW.GetPixel(x, y).R >= _seed.Color && _isFree[x, y])
                {
                    _seed.AddPoint(x, y);
                    _isFree[x, y] = false;

                    if (x > 1) RecursionSearching(x - 1, y);
                    if (x < _photoBW.Width - 1) RecursionSearching(x + 1, y);
                    if (y > 1) RecursionSearching(x, y - 1);
                    if (y < _photoBW.Height - 1) RecursionSearching(x, y + 1);
                }
            }
            else
            {
                _controlList.Add(new Point(x, y));
            }

            _recursionTreshold--;
        }
    }
}
