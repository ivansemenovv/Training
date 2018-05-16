using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class QuickSort
    {
        public static void RunTestCases()
        {
            int[] a = new int[] { 4, 8, 7, 6, 5, 3, 2, 1 };
            Sort(ref a, 0, a.Length - 1);
        }

        static void Sort(ref int[] a, int l = 0, int r = -1)
        {
            if( l < r)
            {
                var p = partition(ref a, l, r);
                Sort(ref a, l, p - 1);
                Sort(ref a, p + 1, r);
            }
        }

        static int partition(ref int[] a, int l, int r)
        {
            int pivot = a[r];
            int i = l - 1;
            for (int j = l; j < r; j++)
            {
                if(a[j] <= pivot)
                {
                    i++;
                    Swap(ref a, i, j);
                }
            }
            i++;
            Swap(ref a, i, r);
            return i;
        }

        static void Swap(ref int[] a, int i, int j)
        {
            int t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }
}
