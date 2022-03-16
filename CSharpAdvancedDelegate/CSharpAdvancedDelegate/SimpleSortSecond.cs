using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAdvancedDelegate
{
    public enum SortType
    {
        Ascending,
        Descending
    }
    public   class SimpleSortSecond
    {
        public static void BubbleSort(int[] items,SortType sortType)
        {

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
                    bool swap = false;
                    switch (sortType)
                    {
                        case SortType.Ascending:
                            swap = items[j - 1] > items[j];
                            break;
                        case SortType.Descending:
                            swap = items[j - 1] < items[j];
                            break;
                        default:
                            break;
                    }


                    if (swap)
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
