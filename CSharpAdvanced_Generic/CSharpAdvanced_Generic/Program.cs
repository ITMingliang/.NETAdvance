using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvanced_Generic
{
    /// <summary>
    /// QQ讨论群：737763054
    /// 网址：www.antprograming.com
    /// </summary>
    class Program
    {
        /*
         * 1 什么是泛型？
            2 如何声明和使用泛型
            3 泛型的好处和原理
            4 泛型类、泛型方法、泛型接口、泛型委托（学了委托后再讲）
            5 泛型约束
            6 协变 逆变(选修)
            7 泛型缓存(选修)

            //总结：【1】泛型的用处--让我们让泛型类、泛型方法、泛型接口、泛型委托这些更--通用。
                         【2】次要：--约束用得不是很多。
                         【3】了解性内容：协变逆变
            
            //后面课程介绍--反射--面向对象（OOP）---特性---委托--事件--Lambda--Linq---设计模式六大原则--表达式目录树--
           做EF类似的框架。
         */
        static void Main(string[] args)
        {
            {
           // // 1 什么是泛型？
           // Console.WriteLine("-----------------------------------------------------------泛型Lis<T>--------------------------------------");
           // List<string> strList = new List<string>() { "Ant编程", "小程序", "语法基础" };
           // foreach (var item in strList)
           // {
           //     Console.WriteLine(item);
           // }
           // List<int> intList = new List<int>() { 1, 2, 3, 4, 5,};
           // foreach (var item in intList)
           // {
           //     Console.WriteLine(item);
           // }
           // List<object> ojbList = new List<object>() {  };//ojbect类型做数据转换的时候有拆将箱的操作，有性能损耗，建议大家少用。
           // Console.WriteLine("-----------------------------------------------------------泛型Dictionary<K,V>--------------------------------------");
           // //泛型Dictionary<K,V>,键/值对(泛型字典)
           // //key是不能重复、
           // Dictionary<int, string> directory = new Dictionary<int, string>();
           // directory.Add(1, "C#基础语法");
           // directory.Add(2, "C#进阶语法");
           // directory.Add(3, "MongoDB");
           // foreach (var item in directory)
           // {
           //     Console.WriteLine(item.Key.ToString()+" "+item.Value);
           // }
           //bool isContains= directory.ContainsValue("MongoDB");
           // directory.Remove(1);
           // foreach (var item in directory)
           // {
           //     Console.WriteLine(item.Key.ToString() + " " + item.Value);
           // }
           // Console.WriteLine("-----------------------------------------------------------泛型自定义--------------------------------------");
           // //自定义泛型（泛型最大优点就是做到了通用）
           // MyGeneric<int> myGeneric = new MyGeneric<int>(1111111);
           // myGeneric.Show();
           // MyClass myClass = new MyClass("这是普通类型");
           // myClass.Show();

           // Console.WriteLine("-----------------------------------------------------------泛型方法--------------------------------------");
           // Show("这是泛型方法");
           // Show(888888888);
            }

            #region 泛型约束

            Console.WriteLine("-----------------------------------------------------------泛型约束-------------------------------------");
            //【1】new() 约束--表示T类型只接收带一个无参数的构造函数
            //【2】struct 值类型约束
            //【3】class 引用类型约束
            //【4】自定义类型约束（基类型约束，接口类型约束）
            //值类型---结构类型struct /int ,double,bool、枚举
            //引用类型--数组、类、接口、委托、object、字符串
            //new()约束一定要写在最后面

            Student student = new Student();
            Student2 student2 = new Student2();
            //IStudent student1 = null;
            //Show(int);

            #endregion

            #region 协变和逆变

            Console.WriteLine("-----------------------------------------------------------协变和逆变--------------------------------------");
            

            
                People people = new People();
                People people1 = new Teacher();
                Teacher teacher = new Teacher();
                //Teacher teacher1 = new People();

            
            
                List<People> peoples = new List<People>();
            //【1】其实从现实 中理解 他应该正确才对，但是List<People>类型和 List<Teacher>不是一个类型，从类型的角度来不成立，
            //，所以其实这个是语法规则不支持。.net 2.0 ,3.0的时候才有协变和逆变
            //【2】协变和逆变他是针对泛型接口和泛型委托来说的。离开了他们就没有这个说法。
            //【3】out关键字代表是协变，in代表是逆变。
            //【4】什么情况下使用？在知道自己或者别人以后有用到父类通过子类实例化，或者子类通过父类实例化的情况下可以lk out或者in关键字
            //List<People> peoples1 = new List<Teacher>();

            


            
                IListOut<People> listOut = new ListOut<People>();
                IListOut<People> listOut1 = new ListOut<Teacher>();//协变

                IListIN<Teacher> listIN = new ListIN<Teacher>();
                IListIN<Teacher> listIN1 = new ListIN<People>();//逆变
                

                IOutIntList<Teacher, People> myList1 = new OutIntList<Teacher, People>();
                IOutIntList<Teacher, People> myList2 = new OutIntList<Teacher, Teacher>();//协变
                IOutIntList<Teacher, People> myList3 = new OutIntList<People, People>();//逆变


                IOutIntList<Teacher, People> myList4 = new OutIntList<People, Teacher>();//逆变+协变



            #endregion

            Console.ReadLine();
        }

        #region 泛型方法

        public static void Show<T,S,K,D>( T t)
            where D: Student,  IStudent, IStudent<T>//基类约束，只能有一个而要放前面，接口约束可以多个
            where S:struct
            where T: class,new()
        {
            
            Console.WriteLine(t);
        }

        #endregion

    }

    #region 协变和逆变
    class People//父类
    {
        public int Id { get; set; }
    }

    class Teacher : People//子类
    {
        public string Name { get; set; }
    }
    /// <summary>
    /// 协变只能返回结果，不能做参数
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IListOut<out T>
    {
        T GetT();

        // void Show(T t);
    }

    class ListOut<T> : IListOut<T>
    {
        public T GetT()
        {
            return default(T);//default关键字，如果是值 类型默认返回0，是引用类型默认返回null
        }
    }

    /// <summary>
    /// in修饰，逆变后，T只能作为当参数  不能做返回值，
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IListIN<in T>
    {
        //T GetT();

        void Show(T t);
    }

    class ListIN<T> : IListIN<T>
    {

        public void Show(T t)
        {

        }
    }

    public interface IOutIntList<in inT, out outT>
    {
        void Show(inT t);
        outT Get();
        outT Do(inT t);

        ////out 只能是返回值   in只能是参数
        //void Show1(outT t);
        //inT Get1();

    }


    public class OutIntList<T1, T2> : IOutIntList<T1, T2>
    {

        public void Show(T1 t)//逆变作为参数
        {

        }

        public T2 Get()//协变作为返回值
        {

            return default(T2);
        }

        public T2 Do(T1 t)
        {

            return default(T2);
        }
    }

    #endregion

    #region 泛型接口

    interface IStudent<T>//泛型接口
    {

    }
    interface IStudent //普通接口
    {
        //没有构造函数
    }

    class Student //普通类
    {
        //默认有一个无参数的构造
    }

    class Student2  //普通类
    {
        //默认有一个无参数的构造
    }

    #endregion


    #region 泛型

    class MyClass
    {
        private string str;

        public MyClass(string str)
        {
            this.str = str;
        }

        public void Show()
        {
            Console.WriteLine(str);
        }
    }


    class MyGeneric<T> 
    {
        private T t;

        public MyGeneric(T t)
        {
            this.t = t;
        }

        public void Show()
        {
            Console.WriteLine(t);
        }
    }


    #endregion



}
