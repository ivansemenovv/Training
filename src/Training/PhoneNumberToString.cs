using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class PhoneNumberToString
    {
        private static Dictionary<char, List<string>> numberToLettesMap = new Dictionary<char, List<string>>()
        {
            {'0', new List<string>(){ " "} },
            {'1', new List<string>(){ "" } },
            {'2', new List<string>(){"a","b","c"}},
            {'3', new List<string>(){"d","e","f"}},
            {'4', new List<string>(){"g","h","i"}},
            {'5', new List<string>(){"j","k","l"}},
            {'6', new List<string>(){"m","n","o"}},
            {'7', new List<string>(){"p","q","r", "s"}},
            {'8', new List<string>(){"t","u","v"}},
            {'9', new List<string>(){"w","x","y","z"}},
        };

        public static void RunTestCases()
        {
            List<string> expectedResult = new List<string>()
            {
                "w a",
                "w b",
                "w c",
                "x a",
                "x b",
                "x c",
                "y a",
                "y b",
                "y c",
                "z a",
                "z b",
                "z c"
            };
            var combinations = GetCombinations("9012");

            TestHelper.IsEquals(expectedResult.ToArray(), combinations.ToArray());
        }

        public static List<string> GetCombinations(string phoneNumber)
        {
            List<string> combinations = new List<string>();
            if (phoneNumber.Length == 0) return combinations;

            if (phoneNumber.Length == 1)
            {
                foreach (var c in numberToLettesMap[phoneNumber[0]])
                {
                    combinations.Add(c);
                }
            }
            else
            {
                var subCombinations = GetCombinations(phoneNumber.Substring(1));
                foreach (var c in numberToLettesMap[phoneNumber[0]])
                {
                    foreach (var subCombination in subCombinations)
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.Append(c);
                        sb.Append(subCombination);
                        combinations.Add(sb.ToString());
                    }
                }
            }

            return combinations;
        }
    }
}
