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
            if(!first.Equals(second))
            {
                throw new Exception(string.Format("Value {0} is not equal value {1}", first, second));
            }
        }

    }
}
