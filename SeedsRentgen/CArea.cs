using System.Collections.Generic;
using System.Drawing;

namespace SeedsRentgen
{
    public class CArea
    {
        private List<Point> _area;
           
        private bool _isFrameCalculated;
        private Rectangle _frame;
        public Rectangle Frame 
        {
            get
            {
                return CalculateFrame();
            }
        }

        public byte Color { get; private set; }
        
        public CArea(byte color)
        {
            _area = new List<Point>();
            Color = color;

            _isFrameCalculated = false;
        }

        public List<Point> GetPoints()
        {
            return new List<Point>(_area);
        }

        public void AddPoint(int x, int y)
        {
            _area.Add(new Point(x, y));
        }

        public Rectangle CalculateFrame()
        {
            if (!_isFrameCalculated)
            {
                //добавить зависимость от настроек
                int minX = 1000, maxX = -1, minY = 1000, maxY = -1;

                foreach (Point p in _area)
                {
                    if (p.X < minX) minX = p.X;
                    if (p.Y < minY) minY = p.Y;
                    if (p.X > maxX) maxX = p.X;
                    if (p.Y > maxY) maxY = p.Y;
                }

                _frame = new Rectangle(minX - 1, minY - 1, maxX - minX + 2, maxY - minY + 2);
                _isFrameCalculated = true;
            }

            return _frame;
        }
    }
}
