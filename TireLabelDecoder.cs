using Patagames.Ocr;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using Tire_Label_Decoder.Types;

namespace Tire_Label_Decoder
{
    class AttributeRegion
    {
        Rectangle Region { get; set; }
        string TireLabelAttribute { get; set; }
    }

    public class TireLabelDecoder
    {
        public TireLabel ProcessLabel()
        {

            var bmp = Image.FromFile(@"C:\test.jpg") as Bitmap;

            //PrepareRegions(bmp);
            var rectangle = new Rectangle(0, 170, bmp.Size.Width, 100);
            PixelFormat format = bmp.PixelFormat;
            var newMape = bmp.Clone(rectangle, format);

            using (var api = OcrApi.Create())
            {
                api.Init("", "eng");
                string plainText = api.GetTextFromImage(newMape);
                Debug.WriteLine(plainText);
            }

            throw new NotImplementedException();
        }

        void PrepareRegions(Bitmap image)
        {
            int overallHeight = image.Size.Height;
            int overallWidth = image.Size.Width;
        }
        IEnumerable<AttributeRegion> SliceBitMapIntoRegions()
        {
            //Bitmap.Clone(new Rectangle(0, 0, bmp.Size.Width, 200)_;
            throw new NotImplementedException();
        }
    }
}