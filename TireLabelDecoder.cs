using Patagames.Ocr;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Tire_Label_Decoder.Types;
using Tire_Label_Decoder.Types.Abstract;

namespace Tire_Label_Decoder
{
    public class TireLabelDecoder
    {
        public TireLabel GetTireLabelInfo(string path)
        {
            var image = Image.FromFile(path) as Bitmap;
            var url = GetUrlFromQRCode(image);
            CreateTireLabel(url);
            
            return new TireLabel();
        }

        private string GetUrlFromQRCode(Bitmap qrCode)
        {
            try
            {
                var qrCodeReader = new ZXing.QrCode.QRCodeReader();
                var score = new ZXing.BitmapLuminanceSource(qrCode);
                var binarizer = new ZXing.Common.HybridBinarizer(score);
                var binaryBitmap = new ZXing.BinaryBitmap(binarizer);
                var result = qrCodeReader.decode(binaryBitmap);

                return result.Text;
            }
            catch (Exception)
            {
                // should throw an exception or skip and go on?
            }
            return string.Empty;
        }

        TireLabel CreateTireLabel(string url)
        {
            url = @"https://eprel.ec.europa.eu/screen/product/tyres/381801";

            // we have to use chrome driver...
             
            throw new NotImplementedException();
        }
    }
}