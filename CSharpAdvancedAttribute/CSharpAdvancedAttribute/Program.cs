using CSharpAdvancedAttribute.EnumExtend;
using CSharpAdvancedAttribute.ShowExtend;
using CSharpAdvancedAttribute.ValidateExtend;
using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace CSharpAdvancedAttribute
{
    /// <summary>
    /// 泛型：把类型做到通用--》代表着动态
    /// 反射：读取DLL文件描述信息的一个类库
    /// 特性：贴标签--贴上标签就产生了新功能
    /// 
    /// 
    /// 进阶语法--》特性：他就是一类，继承自Attribute,如果是的话他就是特性
    /// 
    /// 目前那些地方使用到了特性：几乎所有框架都用到了，MVC---WebApi--EF--IOC--AOP
    /// 特性使用场景：可以用来做数据验证
    /// 
    /// 特性分类 ：
    ///         一、系统自带特性（DebuggerStepThrough、Obsolete）有一些是影响到了编译器的运行
    ///        二、自定义
    ///   
    /// 特性三大步：
    ///             第一步--定义特性
    ///             第二步--标记、
    ///             第三步--调用
    /// 
    /// 学会后要做一个O/RM框架
    /// </summary>
    class Program
    {

        static void Main(string[] args)
        {


            //UseAttributeClass useAttribute = new UseAttributeClass();
            //useAttribute.DoMethod();

            ////AttributeTestClass attributeTestClass = new AttributeTestClass();
            //AttribteTest attribteTest = new AttribteTest();
            //attribteTest.Test();
            //实验一
            //UserState userState = UserState.Frozen;
            //if (userState==UserState.Normal)
            //{
            //    Console.WriteLine("正常");
            //}
            //else if (userState == UserState.Frozen)
            //{
            //    Console.WriteLine("冻结");
            //}
            ////通过特性来操作
            //AttributeInvoke attributeInvoke = new AttributeInvoke();
            //Console.WriteLine(attributeInvoke.GetRemark(userState));

            ////实验二
            ////1--普通方式
            ////ShowTest showTest = new ShowTest();
            ////InvokeConter invokeConter = new InvokeConter();
            ////invokeConter.InvokeManager(showTest);
            ////2-扩展方法
            //ShowTest showTest = new ShowTest();
            //showTest.InvokeManager();

            //实验三（特性验证）
            Student student = new Student()
            {
                 Id=1,
                  PoneNumber=12345678900,
                   StudentName= "Ant"
            };

            if (student.Validate())
            {
                Console.WriteLine("验证成功");
            }
            else
            {
                Console.WriteLine("验证失败");
            }


            Console.ReadKey();
        }

    }

    #region 认识Attribute
    public class UseAttributeClass
    {
        [DebuggerStepThrough]
        public void DoMethod()
        {
            //这个方法很简单
            Console.WriteLine("我这个方法很简单");
        }
    }

    #endregion

    #region 特性分类
    [Obsolete("11111", true)]
    public class AttributeTestClass
    {

    }

    #endregion

    #region 特性创建
    class AttribteTest
    {
        public void Test()
        {
            Type type = typeof(UseAttibute);
            object[] customAttributes = type.GetCustomAttributes(true);
            foreach (object customAttribute in customAttributes)
            {
                DefindAttribute defindAttribute = customAttribute as DefindAttribute;
                if (defindAttribute!=null)
                {
                    Console.WriteLine(defindAttribute.ShowInfo);
                }
            }
        }
    }
 


    [Defind("这是第一个特性的创建！")]
    class UseAttibute
    {
            
    }

    public class DefindAttribute : Attribute
    {
        public DefindAttribute(string showInfo)
        {
            ShowInfo = showInfo;
        }

        public string ShowInfo { get; set; }
    }




    #endregion

}




