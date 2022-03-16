using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced
{
    /// <summary>
    /// 抽象类
    /// </summary>
   public abstract class AbstractMethod
    {
        /// <summary>
        /// 规范好让子类去实现
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public abstract int Calculate(int a, int b);

        public virtual int Sub(int a, int b)
        {
            return a - b;
        }

        public int Maltiply(int a, int b)
        {
            return a* b;
        }
    }

    public class AbstracMethodChild : AbstractMethod
    {
        public override int Calculate(int a, int b)
        {
            return a + b;
        }
    }
}
