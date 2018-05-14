using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class DivideWithoutDiv
    {
        public static void RunTestsCases()
        {
            int r = Divide(8, 2);
            TestHelper.IsEquals(r, 4);

            r = Divide(9, 2);
            TestHelper.IsEquals(r, 4);

            r = Divide(9, 3);
            TestHelper.IsEquals(r, 3);

            r = Divide(129, 23);
            TestHelper.IsEquals(r, 5);
        }

        public static int Divide(int dividend, int divisor)
        {
            int quotient = 0, temp = 0;
            for (int i = 31; i >= 0; --i)
            {

                if (temp + ((long)divisor << i) <= dividend)
                {
                    temp += divisor << i;
                    quotient |= 1 << i;
                }
            }

            return quotient;
        }
    }
}



