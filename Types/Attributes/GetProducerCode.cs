﻿using System.Drawing;
using Tire_Label_Decoder.Types.Abstract;

namespace Tire_Label_Decoder.Types.Attributes
{
    public class GetProducerCode : TireAttribute
    {
        public override string AttributeName => "Eprel";
        public override Rectangle GetRectangle(int baseHeight, int baseWidth)
        {
            int startPointX = baseWidth / 2;
            int startPointY = (baseHeight * 12) / 100;
            int newHeight = ((baseHeight * 19) / 100) - ((baseHeight * 12) / 100);
            int newWidth = baseWidth / 2;

            return new Rectangle(startPointX, startPointY, newWidth, newHeight);
        }
    }
}