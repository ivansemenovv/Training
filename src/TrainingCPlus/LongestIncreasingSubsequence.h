#pragma once

class LongestIncreasingSubsequence
{
public:
    static void RunTestCases();
    static int GetLongestIncreasingSubsequence(const std::vector<int>& sequence, const int start = 0);
    static int GetLongestIncreasingSubsequenceDp(const std::vector<int>& sequence);
};

