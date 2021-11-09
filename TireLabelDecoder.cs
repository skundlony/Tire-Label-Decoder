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

            var client = new RestSharp.RestClient();
            //client.FollowRedirects = true;

            var request = new RestSharp.RestRequest(url);
            request.Method = RestSharp.Method.GET;
            
            request.AddCookie("eu_cookie_consent", "%7B%22a%22%3A%7B%22europa%22%3A%5B%22europa-analytics%22%2C%22load-balancers%22%2C%22authentication%22%5D%7D%2C%22r%22%3A%7B%7D%7D");
            //request.AddCookie("cck1", "{ \"cm\":true,\"all1st\":false,\"closed\":false}");
            request.AddCookie("has_js", "1");

            var response = client.Execute(request);
            Debug.WriteLine(response.Content);
            
            //WebRequest request = WebRequest.Create(url);
            //// If required by the server, set the credentials.
            //request.Credentials = CredentialCache.DefaultCredentials;

            //// Get the response.
            //HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            
            //Console.WriteLine(response.ResponseUri.ToString());
            //// Display the status.
            //Console.WriteLine(response.StatusDescription);
            //// Get the stream containing content returned by the server.
            //Stream dataStream = response.GetResponseStream();
            //// Open the stream using a StreamReader for easy access.
            //StreamReader reader = new StreamReader(dataStream);
            //// Read the content.
            //string responseFromServer = reader.ReadToEnd();
            //// Display the content.
            //Console.WriteLine(responseFromServer);
            //// Cleanup the streams and the response.
            //reader.Close();
            //dataStream.Close();
            //response.Close();
             
            throw new NotImplementedException();
        }
    }
}