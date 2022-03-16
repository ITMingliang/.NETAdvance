using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced
{
    /// <summary>
    /// 假如
    /// </summary>
    public static class InterfaceExtend
    {
      public static int Sub( this ICalculate calculate, int a,int b)
        {
            return a - b;
        }

        public static int Maltiply(this ICalculate calculate, int a, int b)
        {
            return a * b;
        }

        public static int Division(this ICalculate calculate, int a, int b)
        {
            return a / b;
        }

   
    }
}
