using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedAttribute.ValidateExtend
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LongAttribute : AbstractValidateAttribute
    {
        private long _Long = 0;
        public LongAttribute(long phoneLength)
        {
            this._Long = phoneLength;
        }

        public override bool Validate(object objValue)
        {
           return objValue != null && objValue.ToString().Length == 11;
        }
    }
}
