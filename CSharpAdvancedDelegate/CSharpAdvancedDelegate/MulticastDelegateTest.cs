using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedDelegate
{
    //delegate void MulticastTest();
    /// <summary>
    /// 多播委托
    /// 【1】每一个委托都是继承自MulticastDelegate，也就是每个都是多播委托。
    /// 【2】带返回值的多播委托只返回最后一个方法的值
    /// 【3】多播委托可以用加减号来操作方法的增加或者减少。
    /// 【4】给委托传递相同方法时 生成的委托实例也是相同的（也就是同一个委托）
    /// </summary>
    public class MulticastDelegateTest
    {
        
            
        public void Show()
        {
            //MulticastTest multicastTest = new MulticastTest(MethodTest);
            //multicastTest();



            //Action action =new Action(MethodTest);
            //action = (Action)MulticastDelegate.Combine(action, new Action(MethodTest2));
            //action= (Action)MulticastDelegate.Combine(action, new Action(MethodTest3));
            //action = (Action)MulticastDelegate.Remove(action, new Action(MethodTest3));
            //action();

            Action action = MethodTest;
            action += MethodTest2;
            action += MethodTest3;
            action -= MethodTest3;
            foreach (Action action1 in action.GetInvocationList())
            {
                action1();
            }
            //action();



            //Func<string> func = ()=> { return "我是Lambda"; };
            //func+= () => { return "我是func1"; };
            //func += () => { return "我是func2"; };
            //func += GetTest;
            //func += GetTest;
            // string result= func();
            //Console.WriteLine(result);
        }



        public void MethodTest()
        {
            Console.WriteLine("我是方法MethodTest()");
        }

        public void MethodTest2()
        {
            Console.WriteLine("我是方法MethodTest()2");
        }

        public void MethodTest3()
        {
            Console.WriteLine("我是方法MethodTest()3");
        }

        public string GetTest()
        {
            return "我是方法GetTest()";
        }

    }
}
