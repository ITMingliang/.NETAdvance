using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedAttribute.ValidateExtend
{
   public static class AttributeExtend
    {
        public static bool Validate<T>(this T t)
        {
            Type type = t.GetType();
            foreach (var property in type.GetProperties())
            {
                if (property.IsDefined(typeof(AbstractValidateAttribute),true))
                {
                    object objValue = property.GetValue(t);
                    foreach (AbstractValidateAttribute attribute in property.GetCustomAttributes(typeof(AbstractValidateAttribute), true))
                    {
                        if (!attribute.Validate(objValue))//如果成功了以后 就继续验证，否则就直接返回
                        {
                            return false ;
                        }
                    }
                }
                
            }
            return true;
        }
    }
}
