using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedDelegate
{

    delegate bool SortThan(int first, int second);//委托定义
    class DelegateSort
    {
        public static void BubbleSort(int[] items, SortThan sortThan)
        {

            //1234567898
            int i;
            int j;
            int temp;
            if (items == null)
            {
                return;
            }
            for (i = items.Length - 1; i >= 0; i--)
            {
                for (j = 1; j <= i; j++)
                {
                    //if (items[j - 1] > items[j])
                    if (sortThan(items[j - 1] , items[j]) )
                    {
                        temp = items[j - 1];
                        items[j - 1] = items[j];
                        items[j] = temp;
                    }
                }
            }


        }


     

    }
}
