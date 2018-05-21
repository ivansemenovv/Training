using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class Interval
    {
        public int Start
        {
            get;
        }

        public int End
        {
            get;
        }

        public Interval(int start, int end)
        {
            Start = start;
            End = end;
        }

        public override bool Equals(object obj)
        {
            return ((Interval)obj).Start == this.Start && ((Interval)obj).End == this.End;
        }
    }
    class IntervalIntersection
    {
        public static void RunTestCases()
        {
            List<Interval> A = new List<Interval>() {
                new Interval(2, 5),
                new Interval(5, 7),
                new Interval(8, 14),
                new Interval(15, 20)
            };

            List<Interval> B = new List<Interval>() {
                new Interval(1, 3),
                new Interval(4, 7),
                new Interval(9, 15),
                new Interval(16, 25)
            };

            List<Interval> intersection = new List<Interval>
            {
                new Interval(2, 3),
                new Interval(4, 5),
                new Interval(9, 14),
                new Interval(16, 20)
            };

            TestHelper.IsEquals(intersection.ToArray(), GetIntersection(A, B).ToArray());
        }

        public static List<Interval> GetIntersection(List<Interval> A, List<Interval> B)
        {
            int curB = 0;
            List<Interval> result = new List<Interval>();
            foreach (var intA in A)
            {
                Interval intersection;
                while(curB < B.Count && (intersection = GetIntersection(intA, B[curB])) != null)
                {
                    result.Add(intersection);
                    curB++;
                }
            }

            return result;
        }

        public static Interval GetIntersection(Interval A, Interval B)
        {
            if (A.Start <= B.Start && A.End >= B.End)
                return B;
            if (B.Start <= A.Start && B.End >= A.End)
                return A;
            if (A.Start < B.Start && A.End >= B.Start && A.End < B.End)
                return new Interval(B.Start, A.End);
            if (B.Start < A.Start && B.End >= A.Start && B.End < A.End)
                return new Interval(A.Start, B.End);
            return null;
        }
    }
}
