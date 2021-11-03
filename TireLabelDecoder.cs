using Patagames.Ocr;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Tire_Label_Decoder.Types;
using Tire_Label_Decoder.Types.Abstract;

namespace Tire_Label_Decoder
{
    public class TireLabelDecoder
    {
        private TireLabel _label;
        private Bitmap _image;

        public TireLabel GetTireLabelInfo(string path)
        {
            _image = Image.FromFile(path) as Bitmap;
            _label = new TireLabel();

            PrepareRegions();

            return _label;
        }

        void PrepareRegions()
        {
            var type = typeof(TireAttribute);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(type));

            foreach (var attribute in types)
            {
                var instance = (TireAttribute) Activator.CreateInstance(attribute);
                var attributeValue = GetAttributeValue(instance);

                if(!string.IsNullOrEmpty(attributeValue))
                    UpdateTireLabel(instance.AttributeName, attributeValue);
            }
        }

        void UpdateTireLabel(string propertyName, string value)
        {
            var type = _label.GetType().GetProperty(propertyName).GetType();
            _label.GetType().GetProperty(propertyName).SetValue(_label, (typeof(type)) value);
        }

        // metoda ktora bedzie po kolei wydobywac dla danego atrybutu i obrazu rzeczy
        private string GetAttributeValue(TireAttribute attribute)
        {
            var rectangle = attribute.GetRectangle(_image.Height, _image.Width);
            var format = _image.PixelFormat;
            var region = _image.Clone(rectangle, format);

            using (var api = OcrApi.Create())
            {
                api.Init("", "eng");
                string plainText = api.GetTextFromImage(region);
                Debug.WriteLine(plainText);

                if (!string.IsNullOrEmpty(plainText))
                    return attribute.ProcessAttribute(plainText.Trim());
                else
                    return string.Empty;
            }
        }
    }
}