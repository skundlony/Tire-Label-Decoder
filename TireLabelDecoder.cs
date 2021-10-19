using Patagames.Ocr;
using System;
using System.Collections.Generic;
using System.Drawing;
using Tire_Label_Decoder.Types;

namespace Tire_Label_Decoder
{
    class ValueRegion
    {
        int Width { get; set; }
        int Height { get; set; }
        Bitmap Region { get; set; }
        string TireLabelAttribute { get; set; }
    }

    public class TireLabelDecoder
    {
        public static TireLabel ProcessLabel()
        {
            using (var api = OcrApi.Create())
            {
                api.Init("", "eng");
                using (var bmp = Image.FromFile(@"C:\test.jpg") as Bitmap)
                {
                    string plainText = api.GetTextFromImage(bmp);
                }
            }

            throw new NotImplementedException();
        }

        IEnumerable<ValueRegion> SliceBitMapIntoRegions()
        {
            // Bitmap.Clone 
            throw new NotImplementedException();
        }
    }
}