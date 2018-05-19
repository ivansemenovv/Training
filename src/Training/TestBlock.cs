using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class TestBlock
    {
        public void Test()
        {
            SortedDictionary<string, string> dic = new SortedDictionary<string, string>();
            dic.Add("2", "second");
            dic.Add("1", "first");
            foreach (KeyValuePair<string, string> pair in dic)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }

            Dictionary<string, string> dic2 = new Dictionary<string, string>();
            dic2.Add("2", "second");
            dic2.Add("1", "first");
            foreach (KeyValuePair<string, string> pair in dic2)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
        }
    }
}
