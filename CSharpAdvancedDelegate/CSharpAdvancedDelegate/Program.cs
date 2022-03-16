using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedDelegate
{
    /// <summary>
    /// ANT编程 QQ群：737763054
    /// 泛型：他就是把类型做到了通过;
    /// 反射：他能找出我们DLL文件里面的各种信息;
    /// 特性：特性是让我们的类，方法、属性，参数 之类的在不修改源码的情况下，产生了更多功能，或者其他功能（打一个标签就生产了新功能，本质他其实就是我们AOP的另一种 实现方式）
    /// 委托：有一只小白兔，有一个天出去玩东跑西跑的，后找不到妈妈了，然后通过委托叔叔找到了妈妈。
    /// 
    /// 
    /// 1--委托初始体验
    /// 委托是一个引用类型，其实他是一个类型，保存方法的指针，他指向一个方法，当我们调用 委托的时候这个方法就立即被执行。
    /// 
    /// 
    /// </summary>
    //delegate void HelloDelegate(string msg);//定义委托
    class Program
    {
        static void Main(string[] args)
        {

            {
                //HelloDelegate helloDelegate = new HelloDelegate(Hello);//创建委托实例
                //helloDelegate("您好委托！");//调用委托 

                //Hello("您好我不是委托！");
            }

            {
                //Console.WriteLine(  "========================================");
                //List<LearnVip> learnVips = new List<LearnVip>();
                //learnVips.Add(new LearnVip() { Id = 1, StudentName = "Ant1号", Price = 299 });
                //learnVips.Add(new LearnVip() { Id = 2, StudentName = "Ant2号", Price = 399 });
                //learnVips.Add(new LearnVip() { Id = 3, StudentName = "Ant3号", Price = 599 });
                //learnVips.Add(new LearnVip() { Id = 4, StudentName = "Ant4号", Price = 5999 });
                //IsCsharpVIP isCsharpVIP = new IsCsharpVIP(GetVip2);

                //LearnVip.CsharpVip(learnVips, isCsharpVIP);
            }

            #region Short
            //int[] items = new int[] { 22, 33, 44, 5, 6, 777, 888, 1123, 4532 };
            ////SimpleSortFirst.BubbleSort(items);
            //SortThan sortThan = new SortThan(GreateThan);
            //Console.WriteLine("-------------下面是委托产生的排序-----------------");
            //DelegateSort.BubbleSort(items, GreateThan2);

            //for (int i = 0; i < items.Length; i++)
            //{
            //    Console.WriteLine(items[i]+" ----");
            //}

            #endregion

            #region GenericDelegate
            //GenericDelegate.InvokeDelegate();
            #endregion

            #region MulticastDelegate
            MulticastDelegateTest multicastDelegateTest = new MulticastDelegateTest();
            multicastDelegateTest.Show();
            #endregion


            Console.ReadKey();

        }


        #region Sort

        public static bool GreateThan2(int first, int second)
        {
            return first < second;
        }

        public static bool GreateThan(int first, int second)
        {
            return first > second;
        }

        #endregion

        #region MyRegion1


        public static bool GetVip(LearnVip learnVip)
        {
            if (learnVip.Price == 599)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool GetVip2(LearnVip learnVip)
        {
            if (learnVip.Price == 5999)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //public static void Hello(string str)
        //{
        //    Console.WriteLine(str);
        //}

        #endregion
    }


    #region MyRegion2

    delegate bool IsCsharpVIP(LearnVip learnVip);//定义委托

    class LearnVip
    {
        public int Id { get; set; }
        public  string StudentName { get; set; }
        public int Price { get; set; }

        public static void CsharpVip(List<LearnVip> learnVips, IsCsharpVIP isCsharpVIP)
        {
            foreach (LearnVip  learnVip in learnVips)
            {
                //if (learnVip.Price==599)//5999,4999
                if(isCsharpVIP(learnVip))
                {
                    Console.WriteLine(learnVip.StudentName+" 是VIP学员！");
                }
            }
        }


        #endregion

    }
}
