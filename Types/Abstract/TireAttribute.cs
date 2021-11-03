using System;
using System.Drawing;

namespace Tire_Label_Decoder.Types.Abstract
{
    public abstract class TireAttribute
    {
        /// <summary>
        /// Had to same name as property in TireLabel
        /// </summary>
        public virtual string AttributeName => string.Empty;

        public virtual string ProcessAttribute(string plainText)
        {
            return plainText.ToUpper();
        }

        public virtual Rectangle GetRectangle(int baseHeight, int baseWidth)
        {
            throw new NotImplementedException("You cannot use base rectangle");
        }
    }
}