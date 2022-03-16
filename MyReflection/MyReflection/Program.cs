using Ant.DB.Interface;
using Ant.DB.MySql;
using Ant.DB.SQLServer;
using Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyReflection
{
    
    /// <summary>
    /// 反射的基本信息：
    /// 
    /// exe/dll(主要区别就是exe文件有入口)---metadata(元数据：描述exe/dll文件的一个数据清单)--反射（Reflection）用来操作获取元数（metadata）
    /// 【1】更新程序时（更新自己的DLL）
    /// 【2】使用别人的DLL文件（这种可以读取别人的私有的东西）
    /// 
    /// 反射是什么？:他就是一个操作metadata的一个类库（可以把反射当成一个小工具用来读取或者操作元数据的）
    ///                        类、方法、特性、属性字段。（为什么要通过反射间接去操作，1--因为我们需要动态，2--读取私有的对象）
    /// 那些地方使用到了：asp.net MVC  ----ORM---IOC---AOP 几乎所有裤架都会使用反射。
    /// 
    /// 反射---反射工具---操作metadata（元数据）的工具
    /// 
    /// 通过反射加载DLL文件
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {
            try
            {


                #region Common
                Console.WriteLine("----------------------------------------Common--------------------------------");


                #endregion

                #region Reflection 加载DLL文件
                {
                    Console.WriteLine("----------------------------------------Reflection--------------------------------");
                    Assembly assembly = Assembly.Load("Ant.DB.SQLServer");//加载方式一：dll文件名（当前目录）
                    //Assembly assembly = Assembly.LoadFile(@"C:\Users\Administrator\Desktop\奇艺教程\C#语法进阶\MyReflection\Ant.DB.MySql\bin\Debug\Ant.DB.Interface.dll");//加载方式二：完整路径(文件具体路径)
                    //Assembly assembly = Assembly.LoadFrom("Ant.DB.SQLServer.dll");//方法三：完全限定名（当前目录）
                    //Assembly assembly = Assembly.LoadFrom(@"C:\Users\Administrator\Desktop\奇艺教程\C#语法进阶\MyReflection\Ant.DB.MySql\bin\Debug\Ant.DB.Interface.dll");//(文件具体路径)

                    foreach (var type in assembly.GetTypes())//找到所有类型
                    {
                        Console.WriteLine(type.Name);

                        foreach (var method in type.GetMethods())//类型下面的所有方法
                        {
                            Console.WriteLine("这是" + method.Name + "方法");
                        }
                    }

                }
                #endregion

                #region UseReflection 使用反射创建对象
                {

                    //Console.WriteLine("************************UseReflection 使用反射创建对象************************");
                    //Assembly assembly = Assembly.LoadFrom("Ant.DB.SQLServer.dll");//【1】加载DLL文件
                    //Type type = assembly.GetType("Ant.DB.SQLServer.SQLServerHelper");//【2】获取类型（要完整类型名称）
                    //object oDbHelper = Activator.CreateInstance(type);//创建对象
                    ////SQLServerHelper sqlHelper = new SQLServerHelper();
                    //IDBHelper dBHelper = oDbHelper as IDBHelper;//类型转换（as转换不报错，类型不对就返回null）
                    ////IDBHelper dBHelper2 = (IDBHelper)oDbHelper;
                    //dBHelper.Query();

                }
                #endregion

                #region 使用反射创建对象（带参数的构造函数）
                {

                   // Console.WriteLine("************************cotr&Parameter************************");
                   // Assembly assembly = Assembly.LoadFrom("Ant.DB.SQLServer.dll");
                   // Type type = assembly.GetType("Ant.DB.SQLServer.ReflectionTest");
                   // //获取到这个类型下面所有构造方法
                   // foreach (ConstructorInfo ctor in type.GetConstructors())//获取到所有的构造 方法
                   // {
                   //     Console.WriteLine(ctor.Name);
                   //     foreach (var parameter in ctor.GetParameters())//获取到构造方法的所有参数类型
                   //     {
                   //         Console.WriteLine(parameter.ParameterType);//显示类型名称
                   //     }
                   // }
                   // Console.WriteLine("************************创建对象************************");
                   // //object oCotr1 = Activator.CreateInstance(type);//无参数构造函数
                   // //object oCotr2 = Activator.CreateInstance(type,new object[] { "Ant编程"});
                   //// object oCotr3 = Activator.CreateInstance(type, new object[] { 123});
                   // object oCotr3 = Activator.CreateInstance(type, new object[] { 123,"ant编程" });

                }
                #endregion

                #region 使用反射创建对象（私有构造函数）
                {
                    ////这个功能 还用在我们的单例模式里面（一个对象只能创建一次），这个也叫反射破坏单例
                    //Console.WriteLine("************************ctor&Private************************");
                    //// PrivateCtor privateCtor = new PrivateCtor();
                    //Assembly assembly = Assembly.LoadFrom("Ant.DB.SQLServer.dll");//加载DLL文件
                    //Type type = assembly.GetType("Ant.DB.SQLServer.PrivateCtor");//获取到类型
                    //object oPrivate = Activator.CreateInstance(type,true);
                }
                #endregion

                #region 使用反射创建泛型类
                {
                    
                   // Console.WriteLine("************************Generic&Class************************");
                   // Assembly assembly = Assembly.LoadFrom("Ant.DB.SQLServer.dll");//获取DLL文件
                   // Type type = assembly.GetType("Ant.DB.SQLServer.GenericClass`3");//获取到类型名称 
                   //Type makeType= type.MakeGenericType(new Type[] { typeof(int), typeof(string), typeof(double) });
                   // object oGeneric = Activator.CreateInstance(makeType);
                }
                #endregion

                #region 通过反射调用方法
                //{
                ////这个第二种调用方法的方式：通过反向调用
                //Console.WriteLine("************************Method&Reflection************************");
                //Assembly assembly = Assembly.LoadFrom("Ant.DB.SQLServer.dll");//获取DLL文件
                //Type type = assembly.GetType("Ant.DB.SQLServer.ReflectionTest");//获取到类型名称 
                //object oReflection = Activator.CreateInstance(type);
                //foreach (var method in type.GetMethods())
                //{
                //    Console.WriteLine(method.Name);
                //    foreach (var parameter in method.GetParameters())
                //    {
                //        Console.WriteLine(parameter.Name + " " + parameter.ParameterType);
                //    }
                //}
                //{
                //    //调用无参数方法
                //    MethodInfo methodInfo = type.GetMethod("Test1");
                //    methodInfo.Invoke(oReflection, null);//调用方法
                //}
                //    {
                //        //调用带参数方法
                //        MethodInfo methodInfo = type.GetMethod("Test2");
                //        methodInfo.Invoke(oReflection, new object[] {123456 });//调用方法
                //    }
                //    //有参数重载方法
                //    {

            //    MethodInfo methodInfo = type.GetMethod("Test3", new Type[] { typeof(int), typeof(string) });
            //    methodInfo.Invoke(oReflection, new object[] { 133, "Ant编程" });//调用方法
            //}
            //        {

            //    MethodInfo methodInfo = type.GetMethod("Test3", new Type[] { typeof(string), typeof(int) });
            //    methodInfo.Invoke(oReflection, new object[] { "Ant编程", 133 });//调用方法
            //}
            //{

            //    MethodInfo methodInfo = type.GetMethod("Test3", new Type[] { typeof(int) });
            //    methodInfo.Invoke(oReflection, new object[] { 133 });//调用方法
            //}
            //{

                //        MethodInfo methodInfo = type.GetMethod("Test3", new Type[] { typeof(string) });
                //        methodInfo.Invoke(oReflection, new object[] { "Ant编程"});//调用方法
                //    }
                //    //无参数重载方法
                //    {
                //        MethodInfo methodInfo = type.GetMethod("Test3",new Type[] { });
                //        methodInfo.Invoke(oReflection, null);//调用方法
                //    }
                //    //静态方法的调用 方式一
                //    {
                //        MethodInfo methodInfo = type.GetMethod("Test5");
                //        methodInfo.Invoke(oReflection, new object[] { "Ant编程" });//调用方法
                //    }
                //    //静态方法的调用 方式二
                //    {
                //        MethodInfo methodInfo = type.GetMethod("Test5");
                //        methodInfo.Invoke(null, new object[] { "Ant编程" });//调用方法
                //    }



                //}
                #endregion

                #region 反射与MVC和AOP
                {

                    ////在显示之前做一点其他事情
                    //Console.WriteLine("************************反射与MVC和AOP************************");
                    ////显示之后做一点事件

                    ////dll文件名称+类型名称+方法名称（就可以拿到我们的方法）
                    ////https://localhost:44375/Home/Index
                    ////反射在MVC中的一些缺点
                    ////什么AOP，他是面向切面编程，是OOP对象技术的一种补充

                }
                #endregion

                #region 通过反射调用私有方法
                {
                    
                    //Console.WriteLine("************************PrivateMethod&Reflection************************");
                    //Assembly assembly = Assembly.LoadFrom("Ant.DB.SQLServer.dll");//获取DLL文件
                    //Type type = assembly.GetType("Ant.DB.SQLServer.ReflectionTest");//获取到类型名称 
                    //object oReflection = Activator.CreateInstance(type);
                    //MethodInfo methodInfo = type.GetMethod("Test4", BindingFlags.Instance | BindingFlags.NonPublic);
                    //methodInfo.Invoke(oReflection,new object[] { "Ant编程" });
                }
                #endregion


                #region 通过反射调用泛型方法(普通类里面的泛型方法调用)
                //{

                //    Console.WriteLine("************************GenericMethod************************");
                //    Assembly assembly = Assembly.LoadFrom("Ant.DB.SQLServer.dll");//获取DLL文件
                //    Type type = assembly.GetType("Ant.DB.SQLServer.GenericMethod");//获取到类型名称 
                //    object oReflection = Activator.CreateInstance(type);//实例化类型
                //     MethodInfo methodInfo= type.GetMethod("Test");//找到要调用的方法
                //    MethodInfo methodGeneric = methodInfo.MakeGenericMethod(new Type[] { typeof(int), typeof(string), typeof(DateTime) });//确定方法的参数类型和个数
                //    methodGeneric.Invoke(oReflection, new object[] { 1, "Ant编程", DateTime.Now });

                //}
                #endregion

                #region 泛型类里的泛型方法调用
                {

                    //Console.WriteLine("*****************GenericMethod+GenericClass***************");
                    //Assembly assembly = Assembly.LoadFrom("Ant.DB.SQLServer.dll");//获取DLL文件
                    //Type type = assembly.GetType("Ant.DB.SQLServer.GenericClass`3");//获取到类型名称 
                    //Type typeNew = type.MakeGenericType(new Type[] { typeof(int), typeof(string), typeof(DateTime) });//确定泛型方法的参数类型
                    //object oReflection = Activator.CreateInstance(typeNew);//实例化类型
                    //MethodInfo methodInfo = typeNew.GetMethod("Test");//找到方法
                    //MethodInfo methodInfoNew = methodInfo.MakeGenericMethod(new Type[] { typeof(int), typeof(string), typeof(DateTime) });
                    //methodInfoNew.Invoke(oReflection, new object[] { 1, "Ant编程", DateTime.Now });


                    //Console.WriteLine("*****************GenericMethod+GenericClass***************");
                    //Assembly assembly = Assembly.LoadFrom("Ant.DB.SQLServer.dll");//获取DLL文件
                    //Type type = assembly.GetType("Ant.DB.SQLServer.GenericClass`3").MakeGenericType(new Type[] { typeof(int), typeof(string), typeof(DateTime) });//获取到类型名称 
                    ////Type typeNew = type.MakeGenericType(new Type[] { typeof(int), typeof(string), typeof(DateTime) });//确定泛型方法的参数类型
                    //object oReflection = Activator.CreateInstance(type);//实例化类型
                    //MethodInfo methodInfo = type.GetMethod("Test").MakeGenericMethod(new Type[] { typeof(int), typeof(string), typeof(DateTime) }); ;//找到方法
                    ////MethodInfo methodInfoNew = methodInfo.MakeGenericMethod(new Type[] { typeof(int), typeof(string), typeof(DateTime) });
                    //methodInfo.Invoke(oReflection, new object[] { 1, "Ant编程", DateTime.Now });

                }
                #endregion

                #region 通过反射操作字段和属性等成员
                {
                    //Student studen = new Student()
                    //{
                    //    Id = 1,
                    //    StudentAddress = "杭州",
                    //    StudentName = "Ant编程"
                    //};

                    ////反射方式
                    //Assembly assembly = Assembly.LoadFrom("Ant.DB.SQLServer.dll");//获取到DLL信息
                    //Type type = assembly.GetType("Ant.DB.SQLServer.Student");//找到需要操作的对象类型
                    //object oStudent = Activator.CreateInstance(type);//创建对象
                    ////方式一
                    //foreach (var prop in type.GetProperties())
                    //{
                    //    Console.WriteLine($"{prop.PropertyType}+{prop.Name}={prop.GetValue(studen)}");
                    //    Console.WriteLine("-------------------------------------------------");
                    //    if (prop.Name.Equals("Id"))
                    //    {
                    //        prop.SetValue(studen, 2);
                    //    }
                    //    if (prop.Name.Equals("StudentName"))
                    //    {
                    //        prop.SetValue(studen, "Ant小程序教程");
                    //    }
                    //    if (prop.Name.Equals("StudentAddress"))
                    //    {
                    //        prop.SetValue(studen, "杭州1111");
                    //    }
                    //    Console.WriteLine($"{prop.PropertyType}+{prop.Name}={prop.GetValue(studen)}");
                    //}
                    ////方式二
                    //PropertyInfo[] propertyInfos = type.GetProperties();//查找所有的属性
                    //PropertyInfo propertyInfo = type.GetProperty("Id");

                    //用反射来操作字段(作业)

                }

                #endregion

                #region 通过反射来完善SQLHelper类
                //SQLServerHelper serverHelper = new SQLServerHelper();
                //Students students = serverHelper.Find(10000);
                //Students NewStudent = serverHelper.Find<Students>(10000);
                #endregion

                #region 作业安排
                //继续完善SQLHelper类的增、删、改的三个方法
                #endregion

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
