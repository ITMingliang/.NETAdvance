using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced
{
   public interface ICalcualte_1
    {
        int Add(int a, int b);

    }

    public class InterfaceClass : ICalcualte_1, ICalcualte_2
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Sub(int a, int b)
        {
            return a - b;
        }
    }
}
