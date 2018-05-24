#include "stdafx.h"
#include "TestHelper.h"
#include "RegexpMatcher.h"

//"Implement regular expression matching with support for '.' and '*'.
//
//'.' Matches any single character.
//'*' Matches zero or more of the preceding element.
//
//The matching should cover the entire input string(not partial).

void RegexpMatcher::RunTestCases()
{
    TestHelper::IsEquals(isMatch("aa", "a"), false);
    TestHelper::IsEquals(isMatch("aa", "aa"), true);
    TestHelper::IsEquals(isMatch("aaa", "aa"), false);
    TestHelper::IsEquals(isMatch("aa", "a*"), true);
    TestHelper::IsEquals(isMatch("aa", ".*"), true);
    TestHelper::IsEquals(isMatch("ab", ".*"), true);
    TestHelper::IsEquals(isMatch("aab", "c*a*b*"), true);

    TestHelper::IsEquals(isMatchDp("aa", "a"), false);
    TestHelper::IsEquals(isMatchDp("aa", "aa"), true);
    TestHelper::IsEquals(isMatchDp("aaa", "aa"), false);
    TestHelper::IsEquals(isMatchDp("aa", "a*"), true);
    TestHelper::IsEquals(isMatchDp("aa", ".*"), true);
    TestHelper::IsEquals(isMatchDp("ab", ".*"), true);
    TestHelper::IsEquals(isMatchDp("aab", "*a*b*"), true);
}

bool RegexpMatcher::isMatchDp(const string& str, const string& pattern)
{
    if (str.size() == 0 && pattern.size() == 0)
        return true;

    vector<vector<bool>> dp(str.size() + 1, vector<bool>(pattern.size() + 1));
    dp[0][0] = true; // empty string and empty pattern

    for (int i = 1; i < pattern.size(); i++)
    {
        if (pattern[i - 1] == '*')
        {
            dp[0][i - 1] = true;
            dp[0][i] = true;
        }
    }

    for (int i = 1; i <= str.size(); i++)
    {
        for (int j = 1; j <= pattern.size(); j++)
        {
            if (pattern[j - 1] == '*')
            {
                dp[i][j] = dp[i - 1][j] || dp[i][j - 1];
            }
            else if (pattern[j - 1] == '.' || str[i - 1] == pattern[i - 1])
            {
                dp[i][j] = dp[i - 1][j - 1];
            }
            else
            {
                dp[i][j] = false;
            }
        }
    }

    return dp[str.size()][pattern.size()];
}


bool RegexpMatcher::isMatch(const string& str, const string& pattern, const int posStr, const int posPattern)
{
    if (pattern.size() == posPattern && str.size() == posStr)
    {
        return true;
    }

    if (str.size() == posStr && 
        (pattern[posPattern] == '.' || pattern[posPattern] == '*'))
    {
        return true;
    }

    if (pattern.size() > posPattern && str.size() > posStr)
    {
        if (pattern[posPattern] == '.')
        {            
            return isMatch(str, pattern, posStr + 1, posPattern + 1);
        }

        if (pattern[posPattern] == '*' && posStr > 0 
            && (str[posStr] == str[posStr - 1] || pattern[posPattern - 1] == '.'))
        {
            return isMatch(str, pattern, posStr + 1, posPattern) || 
                   isMatch(str, pattern, posStr + 1, posPattern + 1);
        }

        if (str[posStr] == pattern[posPattern])
        {
            return isMatch(str, pattern, posStr + 1, posPattern + 1);
        }
        else if(posPattern < pattern.size() - 1 && pattern[posPattern + 1] == '*')
        {
            return isMatch(str, pattern, posStr, posPattern + 2);
        }
    }
    return false;
}
