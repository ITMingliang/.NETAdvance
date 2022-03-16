using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedEvent
{
    /// <summary>
    /// Ant编程QQ群：737763054
    /// 委托--事件：什么叫事件？事件就是委托的安全版本。第一点--在定义事件类的外部，他是不能使用=号来操作，只能用+=。第二点，在定义事件类的外部不能调用 事件。另外事件就是在委托的前面增加一个event关键字。
    /// </summary>
    delegate void StudentDelegate();//【1】定义一个委托
    class Program
    {
        static void Main(string[] args)
        {
            EventFunction eventFunction = new EventFunction();
            InvokeDefine invokeDefine = new InvokeDefine();
            invokeDefine.StudentEvent += eventFunction.Student1;//【3】订阅事件
            invokeDefine.StudentEvent += eventFunction.Student2;
            invokeDefine.Invoke();
            
            Console.ReadKey();
        }

    }

    /// <summary>
    ///定义事件和调用 事件一定要放在一个类里面
    /// </summary>
    class InvokeDefine //【2】定义一个调用和定义事件的类
    {

        public event StudentDelegate StudentEvent;

        public void Invoke()
        {
            StudentEvent?.Invoke();//?.Null检查运算符
        }

    }

    class EventFunction //【4】订阅者
    {
        public void Student1()
        {
            Console.WriteLine("我是Ant编程1号学员");
        }
        public void Student2()
        {
            Console.WriteLine("我是Ant编程2号学员");
        }

    }

}
