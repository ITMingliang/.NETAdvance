using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced
{
    /// <summary>
    /// C#进阶课程
    /// 交流群：737763054
    /// AntPrograming出品
    /// </summary>
  class Program
    {

        /*
         * 静态方法:
         *          特点：1、生命周期---一旦创建--应用结束 才会结束。2、全局。3，效率高
         *          用处：用户登陆信息、系统配置信息、系统设置、SQLHelper
         *          注意：静态的东西创建多了 占用内存会很大 ，不是必要情况不要创建静态的对象
         *          调用：静态方法调用 非静态方法 ，不能直接调用,把所在类初始化后再调用 
         *          
         * 构造方法:
         *          用处：1.初始化对象。2、或者初始化一些数据
         *          特点：默认是有一个无参数构造方法，可以多个并重载
         *          
         * 析构方法:  
         *              作用：释放对象
         *              谁在使用：GC垃圾回收器在调用 。
         * 
         * 虚方法--virtual:(小蜜蜂)
         *              作用：允许子类/派生类，进行得写，也实现不一样的功能 。
         *              特点：好维护。
         * 重写方法--override:
         * 
         * 
         * 抽象方法--abstract:（大懒虫）
         *                  定义：一定要写在抽象类里面，而且不能new,不带方法体;
         *                  使用场合：强制性一定要实现。
         *                  
         *                  与接口区别使用场合：
         *                                          区别：1-抽象类---单继承、接口可以多继承。
         *                                                     2-抽象类里可以写普通方法，虚方法等，接口只能写规范，不写实现。
         *                                          使用场合：抽象类一般用于常用不会经常改动、然后抽象范围大一些的事物，人--》男人》女人。
         *                                                             接口适用于--经常修改，只是一个规范的地方。
         *                    
         * 扩展方法ExtendMethod:
         *                              定义：在非泛型静态类，定义静态方法--》》扩展方法
         *                              使用场合:1---调用密封类中的对象，属性，或者方法（扩展密封类）。2--扩展接口。3--在Linq链式编程
         */
        static void Main(string[] args)
        {
            ////1--静态方法测试
            //TestStaticMethod testStaticMethod = new TestStaticMethod();
            //testStaticMethod.Test();
            //Test();
            ////2--构造方法测试
            //CtorMethod ctor = new CtorMethod();

            ////3--虚方法测试
            //VirtualMethod method = new VirtualMethod();
            //int num1= method.Calculate(2, 3);
            //Console.WriteLine($"2+3={ num1}");
            //VirtualMethodChild child = new VirtualMethodChild();
            //int num2= child.Calculate(2, 3);
            //Console.WriteLine($"2X3={ num2}");

            //4--抽象方法
            //AbstracMethodChild methodChild = new AbstracMethodChild();
            //methodChild.Calculate(2, 3);
            //int num1 = methodChild.Calculate(2, 3);
            //Console.WriteLine($"2+3={ num1}");

            //InterfaceClass interfaceClass = new InterfaceClass();
            //  int num2= interfaceClass.Add(2, 3);
            //Console.WriteLine($"2+3={ num2}");


            //5-扩展方法
            Person person = new Person()
            {
                Age = 20,
                Name = "Ant",
                Phone = "12345678900"
            };
            PersonExtend.ShowPhone(person);
            A a = new A();
            a.Maltiply(2, 3);
            C c = new C();

            Console.Read();
        }

        public static void Test()
        {
            Console.WriteLine("我是静态方法");
        }

    }

    #region 静态方法

    /// <summary>
    /// 静态方法测试
    /// </summary>
    class TestStaticMethod
    {
        
        public void Test()
        {
            Console.WriteLine("我是非静态方法");
        }
    }

    #endregion

    #region 构造方法

    /// <summary>
    /// 构造方法测试
    /// </summary>
    class CtorMethod
    {
        public CtorMethod()
        {
            testCtorMethod();
        }

        public  void testCtorMethod()
        {
            Console.WriteLine("我在测试构造方法！");
        }
    }

    #endregion
}
