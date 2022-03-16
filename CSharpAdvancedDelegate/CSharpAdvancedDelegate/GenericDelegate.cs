using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedDelegate
{
   

    delegate void GenericDelegate<T>(T t);
   public class GenericDelegate
    {
        public static void InvokeDelegate()
        {
            //GenericDelegate<string> genericDelegate = new GenericDelegate<string>(Method1);
            //genericDelegate("我是泛型委托1");

            //官方版本（不带返回值）
            Action<string> action = new Action<string>(Method1);
            action("我是泛型委托1");
            //Action<string, string, string, string, string, string, string, string, string, string, string, string, string, string, string, string>

            GenericDelegate<int> genericDelegate1 = new GenericDelegate<int>(Method2);
            genericDelegate1(2);

            //官方版本（带回值）
            Func<string, string> func = new Func<string, string>(Method3);
            func("我是带返回值Func委托");
            //Func<string, string, string, string, string, string, string, string, string, string, string, string, string, string, string, string,string>
        }

        public static void Method1(string str)
        {
            Console.WriteLine(str);
        }

        public static void Method2(int num)
        {
            Console.WriteLine("我是泛型委托2 "+num);
        }

        public static string Method3(string str )
        {
            return str;
        }
    }
}
