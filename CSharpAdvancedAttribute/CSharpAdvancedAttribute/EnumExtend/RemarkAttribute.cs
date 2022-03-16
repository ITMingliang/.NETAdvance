using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedAttribute.EnumExtend
{

    [AttributeUsage(AttributeTargets.Field)]
   public class RemarkAttribute:Attribute
    {
        /// <summary>
        /// 状态特性
        /// </summary>
        /// <param name="remark"></param>
        public RemarkAttribute(string remark)
        {
            this.Remark = remark;
        }
        public string Remark { get; private set; }
    }
}
