using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced
{
    /// <summary>
    /// 定义一个静态类,再写一个静态方法
    /// </summary>
    public static class PersonExtend
    {
        public static void ShowPhone(this Person person)
        {
            Console.WriteLine(person.GetPhone());
        }
    }
}
