using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class kbonacci
    {
        public static void RunTestCases()
        {
            TestHelper.IsEquals(calc(3, 4), "5");
        }

        public static string calc(int k, int n)
        {
            List<long> sequence = new List<long>();
            for (int i = 0; i < k; i++)
                sequence.Add(1);

            for (int i = k; i <= n; i++)
            {
                sequence.Add(2 * sequence[k - 1] - sequence[0]);
                sequence.RemoveAt(0);
            }
            return sequence[k - 1].ToString();
        }
    }
}
