#include "stdafx.h"
#include "LongestIncreasingSubsequence.h"

using namespace std;

    //Longest Increasing Subsequence
    //Find the longest increasing subsequence of a given sequence / array.

    //In other words, find a subsequence of array in which the subsequence’s elements are in strictly increasing order, and in which the subsequence is as long as possible.
    //This subsequence is not necessarily contiguous, or unique.
    //In this case, we only care about the length of the longest increasing subsequence.

    //Example:

    //Input: [0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15]
    //    Output : 6
    //    The sequence : [0, 2, 6, 9, 13, 15] or [0, 4, 6, 9, 11, 15] or [0, 4, 6, 9, 13, 15]



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
