using System;

namespace Ant.DB.SQLServer
{
    public class GenericClass<T, W, S>
    {
        public void Test<X, Y, Z>(X x, Y y, Z z)
        {
            Console.WriteLine("第一个类型是={0},第二个类型是={1},第三个类型是={2}", x.GetType().Name, y.GetType().Name, z.GetType().Name);
        }
    }

    public class GenericMethod
    {
        public void Test<T, W, S>(T t, W w, S s)
        {
            Console.WriteLine("第一个类型是={0},第二个类型是={1},第三个类型是={2}", t.GetType().Name, w.GetType().Name, s.GetType().Name);
        }
    }


}
