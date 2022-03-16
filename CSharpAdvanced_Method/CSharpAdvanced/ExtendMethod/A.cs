using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced
{
    public class A : ICalculate
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
    }
}
