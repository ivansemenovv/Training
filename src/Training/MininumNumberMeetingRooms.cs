using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class MininumNumberMeetingRooms
    {
        public static void RunTestCases()
        {
            List<KeyValuePair<int, int>> timeRanges = new List<KeyValuePair<int, int>>()
            {
                new KeyValuePair<int, int>(1, 4),
                new KeyValuePair<int, int>(3, 4),
                new KeyValuePair<int, int>(5, 6),
                new KeyValuePair<int, int>(5, 8),
                new KeyValuePair<int, int>(7, 8)
            };

            int nr = GetMinNumberOfMeetingRooms(timeRanges);
            TestHelper.IsEquals(nr, 2);
        }

        public static int GetMinNumberOfMeetingRooms(List<KeyValuePair<int, int>> timeRanges)
        {
            timeRanges.Sort((first, second) => first.Key - second.Key);

            int counter = 0;
            Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();
            foreach (var pair in timeRanges)
            {
                while(q.Count > 0 && q.Peek().Value < pair.Key)
                {
                    q.Dequeue();
                }
                q.Enqueue(pair);
                counter = Math.Max(counter, q.Count);
            }
            return counter;
        }
    }
}
