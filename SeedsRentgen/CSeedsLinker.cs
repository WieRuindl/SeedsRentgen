using System;
using System.Collections.Generic;
using System.Drawing;

namespace SeedsRentgen
{
    static class CSeedsLinker
    {
        static public List<CSeed> GetSeeds(List<CArea> storage)
        {
            List<CArea> husks = new List<CArea>();
            List<CArea> bodies = new List<CArea>();

            foreach (CArea element in storage)
            {
                if (Color.White.R == element.Color)
                {
                    bodies.Add(element);
                }
                else
                {
                    husks.Add(element);
                }
            }

            husks = SortHusks(husks);

            List<CSeed> seeds = LinkBodies(husks, bodies);
            
            return seeds;
        }

        static private List<CArea> SortHusks(List<CArea> inputHusks)
        {
            List<CArea> sortedHusks = new List<CArea>();

            inputHusks.Sort(delegate(CArea el1, CArea el2)
            { return (el1.CalculateFrame().Y).CompareTo(el2.CalculateFrame().Y); });

            while (inputHusks.Count > 0)
            {
                List<CArea> _tempHusks = new List<CArea>();

                while (inputHusks.Count > 1 &&
                    inputHusks[0].CalculateFrame().Y + inputHusks[0].CalculateFrame().Height >
                    inputHusks[1].CalculateFrame().Y)
                {
                    _tempHusks.Add(inputHusks[0]);
                    inputHusks.Remove(inputHusks[0]);
                }

                _tempHusks.Add(inputHusks[0]);
                inputHusks.Remove(inputHusks[0]);

                _tempHusks.Sort(delegate(CArea el1, CArea el2)
                { return (el1.CalculateFrame().X).CompareTo(el2.CalculateFrame().X); });

                for (int i = 0; i < _tempHusks.Count; i++)
                {
                    sortedHusks.Add(_tempHusks[i]);
                }
            }

            return sortedHusks;
        }

        static private List<CSeed> LinkBodies(List<CArea> inputHusks, List<CArea> inputBodies)
        {
            List<CSeed> seeds = new List<CSeed>();

            int i = 0;
            while (inputHusks.Count > 0)
            {
                CArea husk = inputHusks[0];
                inputHusks.Remove(husk);

                CArea body = null;
                for (int k = 0; k < inputBodies.Count; k++)
                {
                    if (inputBodies[k].Frame.X >= husk.Frame.X &&

                        inputBodies[k].Frame.Y >= husk.Frame.Y &&

                        inputBodies[k].Frame.X + inputBodies[k].Frame.Width <= 
                        husk.Frame.X + husk.Frame.Width &&

                        inputBodies[k].Frame.Y + inputBodies[k].Frame.Height <= 
                        husk.Frame.Y + husk.Frame.Height)
                    {
                        body = inputBodies[k];
                        inputBodies.Remove(body);
                        break;
                    }
                }

                seeds.Add(new CSeed(++i, husk, body));
            }

            return seeds;
        }
    }
}
