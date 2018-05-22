#include "stdafx.h"
#include "ContiguosSequenceSumToInteger.h"

using namespace std;

ContiguosSequenceSumToInteger::ContiguosSequenceSumToInteger()
{
    cout << L"Constructor ContiguosSequenceSumToInteger" << std::endl;
}


ContiguosSequenceSumToInteger::~ContiguosSequenceSumToInteger()
{
    cout << L"Destructor ContiguosSequenceSumToInteger" << std::endl;
}

void ContiguosSequenceSumToInteger::RunTestCases()
{
    vector<int> a{ 1,3,4,5,6,7,8,9 };
    auto interval = GetIntervalToMatchSum(a, 7);
    TestHelper::IsEquals(interval, Interval(1,2));

    auto interval1 = GetIntervalToMatchSum(a, 18);
    TestHelper::IsEquals(interval1, Interval(1, 4));
}

Interval ContiguosSequenceSumToInteger::GetIntervalToMatchSum(std::vector<int> a, int sum)
{
    int cur_sum = 0;
    int start = 0;
    int end = 0;

    while(end < a.size() && start < a.size())
    {
        if (cur_sum < sum)
        {
            cur_sum += a[end++];
        }
        else if (cur_sum > sum)
        { 
            cur_sum -= a[start++];
        }
        else
        {
            return Interval(start, end - 1);
        }
    }
    return Interval(-1, -1);
}
