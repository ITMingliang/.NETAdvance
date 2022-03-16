using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced
{
    /// <summary>
    /// 虚方法测试
    /// </summary>
    public  class VirtualMethod
    {
        //加法
        public virtual int Calculate(int a,int b)
        {
            return a + b;
        }

    }

    class VirtualMethodChild: VirtualMethod
    {
        //乘法
        public override int Calculate(int a, int b)
        {
            return a * b;
        }
    }

}
