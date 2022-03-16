using System;

namespace Ant.DB.SQLServer
{
    public class PrivateCtor
    {
        private PrivateCtor()
        {
            Console.WriteLine("PrivateCtor对象创建成功");
        }
    }
}
