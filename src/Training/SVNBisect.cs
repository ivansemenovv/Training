using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class SVNBisect
    {
        public static void RunTestCases()
        {
            int firstBadRevision = 2;
            TestHelper.IsEquals(firstBadRevision, findBadRevision(0, 4, (rev) => rev >= firstBadRevision));

            firstBadRevision = 7;
            TestHelper.IsEquals(firstBadRevision, findBadRevision(0, 11, (rev) => rev >= firstBadRevision));
        }

        public static int findBadRevision(int goodRevision, int badRevision, Func<int, bool> hasBug)
        {
            int firstBadRevision = badRevision;
            while(badRevision - goodRevision != 1)
            {
                int mid = (badRevision + goodRevision) / 2;
                if(hasBug(mid))
                {
                    badRevision = mid;
                }
                else
                {
                    goodRevision = mid;
                }
            }
            firstBadRevision = badRevision;

            return firstBadRevision;
        }
    }
}
