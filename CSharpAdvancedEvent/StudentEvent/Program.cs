using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            Publisher publisher = new Publisher();
            Subscriber subscriber = new Subscriber("subscriber", publisher);
            Subscriber2 subscriber2 = new Subscriber2("subscriber2", publisher);
            //调用引发事件的方法
            publisher.DoSomething();

            Console.ReadKey();
        }
    }
    //事件参数
    class CustomEventArgs:EventArgs
    {
        public CustomEventArgs( string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }


    //事件发布者：事件的定义和调用，触发事件也可以写在这里面
    class Publisher
    {
        public event EventHandler<CustomEventArgs> CustomEvent;

        public void DoSomething()
        {
            //调用之前可以在这里写一些其他的东西
            OnCustomEvent(new CustomEventArgs("我是事件参数"));
        }

        //在受保护的虚方法中包装事件的调用 ，这样就允许派生类重写调用行为
        protected virtual void OnCustomEvent(CustomEventArgs e)
        {
            CustomEvent?.Invoke(this, e);
        }
    }

    //事件订阅者：事件方法编写和订阅功能
    class Subscriber
    {
        ////订阅的动作要在这里面了，所以才要传过来发布者
        public Subscriber( string str,Publisher publisher)
        {
            Str = str;
            //订阅事件
            publisher.CustomEvent += HanderCustomEvent;
        }
        private readonly string Str;

        private void HanderCustomEvent(object sender, CustomEventArgs e)
        {
            //在这里做想做的事件
            Console.WriteLine($"发布者：{sender.GetType()},订阅者：{Str}，参数是：{e.Message}");
        }
    }

    //事件订阅者：事件方法编写和订阅功能
    class Subscriber2
    {
        ////订阅的动作要在这里面了，所以才要传过来发布者
        public Subscriber2(string str, Publisher publisher)
        {
            Str = str;
            //订阅事件
            publisher.CustomEvent += HanderCustomEvent;
        }
        private readonly string Str;

        private void HanderCustomEvent(object sender, CustomEventArgs e)
        {
            //在这里做想做的事件
            Console.WriteLine($"发布者：{sender.GetType()},订阅者：{Str}，参数是：{e.Message}");
        }
    }
}
