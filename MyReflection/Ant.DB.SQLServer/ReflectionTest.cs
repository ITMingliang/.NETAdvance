using System;

namespace Ant.DB.SQLServer
{
    public class ReflectionTest
    {

        #region ctor

        public ReflectionTest()
        {
            Console.WriteLine($"这是{this.GetType()}无参数构造函数");
        }

        public ReflectionTest(string name)
        {
            Console.WriteLine($"这是{this.GetType()}有参数构造函数,类型为{name.GetType()}");
        }

        public ReflectionTest(int id)
        {
            Console.WriteLine($"这是{this.GetType()}有参数构造函数,类型为{id.GetType()}");
        }

        public ReflectionTest(int id, string name)
        {
            Console.WriteLine($"这是{this.GetType()}有2个参数构造函数,类型为{id.GetType()}和{name.GetType()}");
        }

        #endregion

        #region Method
        /// <summary>
        /// 无参方法
        /// </summary>
        public void Test1()
        {
            Console.WriteLine("这里是{0}的Test1", this.GetType());
        }
        /// <summary>
        /// 有参数方法
        /// </summary>
        /// <param name="id"></param>
        public void Test2(int id)
        {

            Console.WriteLine("这里是{0}的Test2", this.GetType());
        }
        /// <summary>
        /// 重载方法一
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void Test3(int id, string name)
        {
            Console.WriteLine("这里是{0}的Test3-1", this.GetType());
        }
        /// <summary>
        /// 重载方法二
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        public void Test3(string name, int id)
        {
            Console.WriteLine("这里是{0}的Show3-2", this.GetType());
        }
        /// <summary>
        /// 重载方法三
        /// </summary>
        /// <param name="id"></param>
        public void Test3(int id)
        {

            Console.WriteLine("这里是{0}的Test3-3", this.GetType());
        }
        /// <summary>
        /// 重载方法四
        /// </summary>
        /// <param name="name"></param>
        public void Test3(string name)
        {

            Console.WriteLine("这里是{0}的Test3-4", this.GetType());
        }
        /// <summary>
        /// 重载方法五
        /// </summary>
        public void Test3()
        {

            Console.WriteLine("这里是{0}的Test3-5", this.GetType());
        }
        /// <summary>
        /// 私有方法
        /// </summary>
        /// <param name="name"></param>
        private void Test4(string name)
        {
            Console.WriteLine("这里是{0}的Test4私有方法", this.GetType());
        }
        /// <summary>
        /// 静态方法
        /// </summary>
        /// <param name="name"></param>
        public static void Test5(string name)
        {
            Console.WriteLine("这里是{0}的Test5静态方法", typeof(ReflectionTest));
        }
        #endregion

    }
}
