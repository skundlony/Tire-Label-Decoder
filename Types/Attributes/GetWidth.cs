using System.Drawing;
using Tire_Label_Decoder.Types.Abstract;

namespace Tire_Label_Decoder.Types.Attributes
{
    public class GetWidth : TireAttribute
    {
        public override string AttributeName => "Width";

        public override Rectangle GetRectangle(int baseHeight, int baseWidth)
        {
            int startPointX = 0;
            int startPointY = (baseHeight * 19) / 100;
            int newHeight = ((baseHeight * 19) / 100) - ((baseHeight * 12) / 100);
            int newWidth = baseWidth / 2;

            return new Rectangle(startPointX, startPointY, newWidth, newHeight);
        }
    }
}