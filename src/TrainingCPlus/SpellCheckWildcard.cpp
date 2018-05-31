#include "stdafx.h"
#include "SpellCheckWildcard.h"

//"Implement wildcard pattern matching with support for '?' and '*'.
//
//'?' : Matches any single character.
//'*' : Matches any sequence of characters(including the empty sequence).
//The matching should cover the entire input string(not partial).
//
//The function prototype should be :
//
//int isMatch(const char *s, const char *p)
//Examples :
//
//    isMatch(""aa"", ""a"") → 0
//    isMatch(""aa"", ""aa"") → 1
//    isMatch(""aaa"", ""aa"") → 0
//    isMatch(""aa"", ""*"") → 1
//    isMatch(""aa"", ""a*"") → 1
//    isMatch(""ab"", ""?*"") → 1
//    isMatch(""aab"", ""c*a*b"") → 0"

using namespace std;

void SpellCheckWildcard::RunTestCases()
{
    TestHelper::IsEquals(false, isMatch("aa", "a"));
    TestHelper::IsEquals(true, isMatch("aa", "aa"));
    TestHelper::IsEquals(false, isMatch("aaa", "aa"));
    TestHelper::IsEquals(true, isMatch("aa", "*"));
    TestHelper::IsEquals(true, isMatch("aa", "a*"));
    TestHelper::IsEquals(true, isMatch("ab", "?*"));
    TestHelper::IsEquals(false, isMatch("aab", "c*a*b"));
}

bool SpellCheckWildcard::isMatch(const string& str, const string& pattern)
{
    int n = str.size() + 1;
    int m = pattern.size() + 1;
    vector<vector<bool>> dp(n, vector<bool>(m, false));

    dp[0][0] = true;
    for (int i = 1; i < m; i++)
    {
        if (pattern[i - 1] == '*')
            dp[0][i] = dp[0][i - 1];
    }

    for (int i = 1; i < n; i++)
    {
        for (int j = 1; j < m; j++)
        {
            if (pattern[j - 1] == '*')
            {
                dp[i][j] = dp[i][j - 1] || dp[i - 1][j];
            }
            else if (pattern[j - 1] == '?' || str[i - 1] == pattern[j - 1])
            {
                dp[i][j] = dp[i - 1][j - 1];
            }
            else
            {
                dp[i][j] = false;
            }
        }
    }

    return dp[n - 1][m - 1];
}