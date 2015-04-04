using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace SeedsRentgen
{
    class CSaverTxt : ISave
    {
        private String _fileName;

        public CSaverTxt(String directoryName, String fileName)
        {
            _fileName = directoryName + "\\" + fileName + ".txt";
        }

        public void Save(object obj)
        {
            List<CSeed> seeds = (List<CSeed>)obj;

            FileInfo file = new FileInfo(_fileName);

            if (file.Exists)
                file.Attributes = FileAttributes.Normal;
             
            FileStream fileStream = new FileStream(_fileName, FileMode.Create, FileAccess.Write);
            
            using (StreamWriter writer = new StreamWriter(fileStream))
            {
                for (int i = 0; i < seeds.Count; i++)
                {
                    writer.WriteLine(ParameterInfo("номер семени", seeds[i].Number));
                    writer.WriteLine(ParameterInfo("площадь шелухи", seeds[i].HuskArea));
                    writer.WriteLine(ParameterInfo("площадь ядра", seeds[i].BodyArea));
                    writer.WriteLine(ParameterInfo("выполненность", seeds[i].Fulfilled));
                    writer.WriteLine();
                }

                file.Attributes = FileAttributes.ReadOnly;
            }
        }

        private String ParameterInfo(String parameter, double value)
        {
            string result = "<" + parameter + "> " + String.Format("{0:0.####}", value);
            return result;
        }
    }
}
