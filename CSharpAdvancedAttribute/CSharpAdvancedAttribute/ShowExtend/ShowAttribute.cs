using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedAttribute.ShowExtend
{
    [AttributeUsage(AttributeTargets.All,AllowMultiple =true,Inherited =true)]
   public class ShowAttribute:Attribute
    {
        public string ShowInfo { get; set; }
        public void Show()
        {
            Console.WriteLine(ShowInfo);
        }
    }
}
