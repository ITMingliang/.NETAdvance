using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedLambda
{
    class Program
    {
        /// <summary>
        /// Ant编程：Q群737763054
        /// 泛型：把类、方法、属性、字段做到了--》通用化。
        /// 反射：他就是操作DLL文件的一个帮助类库。
        /// 特性：特性他就是一个特殊的类，他也AOP的另一种实现方式。
        /// 委托：他就是多播委托，可以保存一个或者多个方法的信息。可以用来传递方法，主要用来实现代码解耦。
        /// 事件：他就是委托的安全版本，定义委托和调用委托在同一个类里面操作，外不能操作。
        /// 
        /// Lambda:他就是匿名方法
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            LambdaTest lambdaTest = new LambdaTest();
            lambdaTest.Show();

            Console.ReadKey();
        }
    }
}
