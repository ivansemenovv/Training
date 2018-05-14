using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class TestHelper
    {

        public static void IsEquals<T>(T first, T second)
        {
            if (!first.Equals(second))
            {
                throw new Exception(string.Format("Value {0} is not equal value {1}", first, second));
            }
        }

        public static void IsEquals<T>(T[] first, T[] second)
        {
            if (first.Length != second.Length)
            {
                throw new Exception(string.Format("Value {0} is not equal value {1}", first, second));
            }

            for (int i = 0; i < first.Length; i++)
            {
                if (!first[i].Equals(second[i]))
                {
                    throw new Exception(string.Format("Value {0} is not equal value {1}", first, second));
                }
            }
        }
    }
}
