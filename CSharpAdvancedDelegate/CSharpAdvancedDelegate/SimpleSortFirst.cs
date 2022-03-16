using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedDelegate
{
   static class SimpleSortFirst
    {
        public static void BubbleSort(int[] items)
        {

            //1234567898
            int i;
            int j;
            int temp;
            if (items==null)
            {
                return;
            }
            for (i = items.Length-1; i >=0; i--)
            {
                for ( j = 1; j <=i; j++)
                {
                    if (items[j-1]>items[j])
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
