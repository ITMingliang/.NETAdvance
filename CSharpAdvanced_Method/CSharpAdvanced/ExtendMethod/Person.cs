using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced
{
    /// <summary>
    /// 假如这个类是 别人那里拿过来的，不是自己写的
    /// </summary>
   public sealed class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
       /// <summary>
       /// 返回电话
       /// </summary>
       /// <returns></returns>
        public string GetPhone()
        {
            return Phone;
        }
    }
}
