using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedLambda
{
    delegate void StudentDelegate(string name, int age);
   public class LambdaTest
    {
        public void Show()
        {
            DateTime dateTime = DateTime.Now;
            //历史
            //版本1
            {
                StudentDelegate student = new StudentDelegate(Student);
                student("Ant编程", 1);
            }
            //版本2(这样写的话可以访问局部变量)
            {
                StudentDelegate student = new StudentDelegate( delegate (string name, int age)
                {
                    Console.Write(dateTime);
                    Console.WriteLine($"我的名字是：{name},我的年龄是{age}");
                });
                student("Ant编程", 1);
            }

            //版本3(=>念成gose to)
            {
                StudentDelegate student = new StudentDelegate((string name, int age)=>
                {
                    Console.Write(dateTime);
                    Console.WriteLine($"我的名字是：{name},我的年龄是{age}");
                });
                student("Ant编程", 1);
            }
            {
                Action action = () => Console.WriteLine("无返回值，无参数");
                Action<DateTime> action1 = d => { Console.WriteLine(d+"带一个参数"); };
                Func<DateTime> func=()=>{ return DateTime.Now; };//带返回值
                DateTime dateTime1 = func();//调用Lambda获取值 

                Func<DateTime> func2 = () => DateTime.Now;//带返回值
            }
        }


        public void Student(string name,int age)
        {
            Console.WriteLine($"我的名字是：{name},我的年龄是{age}");
        }
    }
}
