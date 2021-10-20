using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tire_Label_Decoder.Types.Abstract
{
    public abstract class Attribute
    {
        public virtual string AttributeName => string.Empty;
        public virtual string ProcessAttribute(string plainText)
        {
            return plainText.ToUpper();
        }

        public virtual Rectangle GetRectangle()
        {
            throw new NotImplementedException("You cannot use base rectangle");
        }
        public virtual Tuple<int, int> GetStartingPoints()
        {
            throw new NotImplementedException("You cannot use base starting points.");
        }
    }
}