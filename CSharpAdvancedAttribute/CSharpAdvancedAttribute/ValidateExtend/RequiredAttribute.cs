using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedAttribute.ValidateExtend
{
    [AttributeUsage(AttributeTargets.Property)]
    public class RequiredAttribute : AbstractValidateAttribute
    {
        public override bool Validate(object objValue)
        {
            return objValue != null && !string.IsNullOrWhiteSpace(objValue.ToString());
        }
    }
}
