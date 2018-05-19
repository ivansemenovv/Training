using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class IntersectionTwoSortedArrays
    {
        public static void RunTestCases()
        {
            TestHelper.IsEquals(new int[] { 3, 10 }, GetIntersection(new List<int>() { 1, 3, 7, 10 }, new List<int>() { 3, 6, 10, 15, 20 }).ToArray());
            TestHelper.IsEquals(new int[] { 1, 3, 6, 7, 10, 15, 20 }, GetUnion(new List<int>() { 1, 3, 7, 10 }, new List<int>() { 3, 6, 10, 15, 20 }).ToArray());
            

            TestHelper.IsEquals(new int[] { 1 }, GetIntersection(new List<int>() { 1 }, new List<int>() { 1 }).ToArray());
            TestHelper.IsEquals(new int[] { }, GetIntersection(new List<int>() { 1 }, new List<int>() { 2 }).ToArray());
            TestHelper.IsEquals(new int[] { }, GetIntersection(new List<int>() { 1, 3, 5, 7, 9 }, new List<int>() { 2, 4, 6, 8, 10 }).ToArray());
            TestHelper.IsEquals(new int[] { 1, 5, 9 }, GetIntersection(new List<int>() { 1, 3, 5, 7, 9 }, new List<int>() { 1, 4, 5, 8, 9 }).ToArray());
            TestHelper.IsEquals(new int[] { 3, 5 }, GetIntersection(new List<int>() { 1, 3, 4, 5, 7 }, new List<int>() { 2, 3, 5, 6 }).ToArray());
            TestHelper.IsEquals(new int[] { 6 }, GetIntersection(new List<int>() { 2, 5, 6 }, new List<int>() { 4, 6, 8, 10 }).ToArray());
        }

        static List<int> GetIntersection(List<int> a1, List<int> a2)
        {
            List<int> result = new List<int>();
            int a1p = 0;
            int a2p = 0;
            while (a1p < a1.Count && a2p < a2.Count)
            {
                if (a1[a1p] == a2[a2p])
                {
                    result.Add(a1[a1p]);
                    a1p++;
                    a2p++;
                }
                else if (a1[a1p] < a2[a2p])
                {
                    a1p++;
                }
                else
                {
                    a2p++;
                }
            }

            return result;
        }

        static List<int> GetUnion(List<int> a1, List<int> a2)
        {
            List<int> result = new List<int>();
            int a1p = 0;
            int a2p = 0;
            while (a1p < a1.Count && a2p < a2.Count)
            {
                if (a1[a1p] == a2[a2p])
                {
                    result.Add(a1[a1p]);
                    a1p++;
                    a2p++;
                }
                else if (a1[a1p] < a2[a2p])
                {
                    result.Add(a1[a1p]);
                    a1p++;
                }
                else
                {
                    result.Add(a2[a2p]);
                    a2p++;
                }
            }

            AddArray(ref result, a1, a1p);
            AddArray(ref result, a2, a2p);

            return result;
        }

        static void AddArray(ref List<int> res, List<int> a, int startPos)
        {
            for (int i = startPos; i < a.Count; i++)
            {
                res.Add(a[i]);
            }
        }
    }
}
