using Patagames.Ocr;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
            throw new NotImplementedException();
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
            WebRequest request = WebRequest.Create(url);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.ResponseUri.ToString());
            // Display the status.
            Console.WriteLine(response.StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();
            // Display the content.
            Console.WriteLine(responseFromServer);
            // Cleanup the streams and the response.
            reader.Close();
            dataStream.Close();
            response.Close();

            throw new NotImplementedException();
        }
    }
}