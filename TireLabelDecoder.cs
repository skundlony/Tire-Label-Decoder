using Newtonsoft.Json;
using System;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Tire_Label_Decoder.Types;

namespace Tire_Label_Decoder
{
    public class TireLabelDecoder
    {
        private const string _baseUrl = @"https://eprel.ec.europa.eu/api/products/tyres/";

        public TireLabel GetTireLabelInfo(string path)
        {
            var image = Image.FromFile(path) as Bitmap;
            var url = GetUrlFromQRCode(image);

            if (!string.IsNullOrEmpty(url))
                return CreateTireLabel(url);
            else
                return null;
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
                Console.WriteLine("Cannot read qrCode");
                return string.Empty;
            }
        }

        TireLabel CreateTireLabel(string url)
        {
            var eprelCode = url.Split('/')
                .ToList()
                .Last();

            var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(@"application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/96.0.4664.93 Safari/537.36");

            var response = client.GetStringAsync(_baseUrl + eprelCode);
            var tireLabel = JsonConvert.DeserializeObject<TireLabel>(response.Result);

            return tireLabel;
        }
    }
}