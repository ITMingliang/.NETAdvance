using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedAttribute.ValidateExtend
{
    [AttributeUsage(AttributeTargets.Property)]
    public class StringLengthAttribute : AbstractValidateAttribute
    {
        private int _Mni=0;
        private int _Max = 0;

        public StringLengthAttribute(int min,int max)
        {
            this._Max = max;
            this._Mni = min;
        }
        public override bool Validate(object objValue)
        {
          return  objValue != null
                && objValue.ToString().Length >= this._Mni
                && objValue.ToString().Length <= this._Max;
        }
    }
}
