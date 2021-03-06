﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeedsRentgen
{
    [Serializable]
    public class CSeed
    {
        public int Number { get; private set; }
        public double BodyArea { get; private set; }
        public double HuskArea { get; private set; }
        public double Fulfilled { get; private set; }

        public Rectangle Frame { get; private set; }

        public CSeed(int number, CArea husk, CArea body)
        {
            Number = number;
            int scopeCoefficint = (int)Math.Pow(SeedsRentgen.Properties.Settings.Default.scopeCoefficient * 10, 2);

            HuskArea = (husk != null) ? (double)husk.GetPoints().Count / scopeCoefficint : 0;
            BodyArea = (body != null) ? (double)body.GetPoints().Count / scopeCoefficint : 0;

            Fulfilled = BodyArea / HuskArea;
            Frame = husk.CalculateFrame();
        }
    }
}
