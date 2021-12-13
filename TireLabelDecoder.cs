using Newtonsoft.Json;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Tire_Label_Decoder.Types;

namespace Tire_Label_Decoder
{
    public class TireLabelDecoder
    {
        private const string _baseUrl = @"https://eprel.ec.europa.eu/api/products/tyres/";

        public TireLabel GetByQrCodeUrl(string qrCodeUrl)
        {
            WebClient client = new WebClient();

            var stream = client.OpenRead(qrCodeUrl);
            var image = Image.FromStream(stream) as Bitmap;
            stream.Close();

            var url = GetEprelDataFromQrCode(image);

            if (!string.IsNullOrEmpty(url))
                return CreateTireLabel(url);
            else
                return null;
        }

        public TireLabel GetByQrData (string qrData)
        {
            return CreateTireLabel(qrData);
        }

        private string GetEprelDataFromQrCode(Bitmap qrCode)
        {
            try
            {
                var qrCodeReader = new ZXing.QrCode.QRCodeReader();
                var score = new ZXing.BitmapLuminanceSource(qrCode);
                var binarizer = new ZXing.Common.HybridBinarizer(score);
                var binaryBitmap = new ZXing.BinaryBitmap(binarizer);
                var result = qrCodeReader.decode(binaryBitmap);
                var eprelData = result.Text.Split('/').Last();

                return eprelData;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot read qrCode " + ex.Message);
                return string.Empty;
            }
        }

        private TireLabel CreateTireLabel(string eprelCode)
        {
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