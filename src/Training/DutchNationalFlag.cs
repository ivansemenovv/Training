using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class DutchNationalFlag
    {
        public static void RunTestCases()
        {
            int[] dutchNationalFlag = new int[] { 0, 1, 1, 2, 2, 2, 1, 1, 0, 0 };
            sort012(ref dutchNationalFlag);
            TestHelper.IsEquals(dutchNationalFlag, new int[] { 0, 0, 0, 1, 1, 1, 1, 2, 2, 2 });

            dutchNationalFlag = new int[] { 2, 1, 1, 2, 2, 2, 1, 1, 1, 0 };
            sort012(ref dutchNationalFlag);
            TestHelper.IsEquals(dutchNationalFlag, new int[] { 0, 1, 1, 1, 1, 1, 2, 2, 2, 2 });
        }

        public static void sort012(ref int[] dutchNationalFlag)
        {
            int leftIndex = 0;
            int curIndex = 1;
            int rightIndex = dutchNationalFlag.Length - 1;
            while(curIndex <= rightIndex)
            {
                if (dutchNationalFlag[curIndex] < 1)
                {
                    Swap(ref dutchNationalFlag, curIndex, leftIndex);
                    leftIndex++;
                }
                else if (dutchNationalFlag[curIndex] > 1)
                {
                    Swap(ref dutchNationalFlag, curIndex, rightIndex);
                    rightIndex--;
                }
                else
                {
                    curIndex++;
                }
            }
        }

        // swap in place
        private static void Swap(ref int[] dutchNationalFlag, int i, int j)
        {
            int a = dutchNationalFlag[i];
            int b = dutchNationalFlag[j];

            a = a + b;
            b = a - b;
            a = a - b;

            dutchNationalFlag[i] = a;
            dutchNationalFlag[j] = b;
        }
    }
}
