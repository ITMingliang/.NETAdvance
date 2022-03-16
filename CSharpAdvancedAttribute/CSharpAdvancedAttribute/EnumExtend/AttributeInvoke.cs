using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedAttribute.EnumExtend
{
   public class AttributeInvoke
    {
        public string GetRemark( UserState userState)
        {
            Type type = userState.GetType();
            var fileId = type.GetField(userState.ToString());
            if (fileId.IsDefined(typeof(RemarkAttribute),true))
            {
                RemarkAttribute remarkAttribute=(RemarkAttribute)fileId.GetCustomAttribute(typeof(RemarkAttribute), true);
                return remarkAttribute.Remark;
            }
            else
            {
                return userState.ToString();
            }
        }
    }
}
