#include "stdafx.h"
#include "LongestIncreasingSubsequence.h"

using namespace std;
void LongestIncreasingSubsequence::RunTestCases()
{
    TestHelper::IsEquals(6, GetLongestIncreasingSubsequence(vector<int>{0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15}));
}

int LongestIncreasingSubsequence::GetLongestIncreasingSubsequence(const std::vector<int>& sequence, const int start)
{
    int max = 1;
    for (int i = start + 1; i < sequence.size(); i++)
    {
        int subMax = GetLongestIncreasingSubsequence(sequence, i);
        if (sequence[start] < sequence[i] && (subMax + 1) > max)
            max = subMax + 1;
    }

    return max;
}
