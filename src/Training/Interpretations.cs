using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class Interpretations
    {
        public static void RunTestCases()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
            var res = GetInterpretations(list);
            TestHelper.IsEquals(res.Count, GetCountInterpretations(list));
        }

        static List<string> GetInterpretations(List<int> list)
        {
            List<string> res = new List<string>();
            if (list.Count == 0)
                return res;

            if (list.Count == 1)
            {
                res.Add(list[0].ToString());
                return res;
            }

            var sl1 = GetInterpretations(list.GetRange(1, list.Count - 1));
            var sl2 = GetInterpretations(list.GetRange(2, list.Count - 2));

            foreach (var ss1 in sl1)
            {
                res.Add(string.Format("{0} - {1}", list[0].ToString(), ss1));
            }


            if (sl2.Count > 0)
            {
                foreach (var ss2 in sl2)
                {
                    res.Add(string.Format("{0}{1} - {2}", list[0].ToString(), list[1].ToString(), ss2));
                }
            }
            else
            {
                res.Add(string.Format("{0}{1}", list[0].ToString(), list[1].ToString()));
            }
            return res;
        }

        static int GetCountInterpretations(List<int> list)
        {
            if (list.Count == 0)
                return 0;

            int dpn1 = 1;
            int dpn2 = 2;
            if (list.Count == 1)
                return dpn1;
            for (int i = 3; i <= list.Count; i++)
            {
                int t = dpn2;
                dpn2 = dpn2 + dpn1;
                dpn1 = t;
            }
            return dpn2;
        }
    }
}
