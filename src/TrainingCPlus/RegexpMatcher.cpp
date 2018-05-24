#include "stdafx.h"
#include "TestHelper.h"
#include "RegexpMatcher.h"

void RegexpMatcher::RunTestCases()
{
    TestHelper::IsEquals(isMatch("aa", "a"), false);
    TestHelper::IsEquals(isMatch("aa", "aa"), true);
    TestHelper::IsEquals(isMatch("aaa", "aa"), false);
    TestHelper::IsEquals(isMatch("aa", "a*"), true);
    TestHelper::IsEquals(isMatch("aa", ".*"), true);
    TestHelper::IsEquals(isMatch("ab", ".*"), true);
    TestHelper::IsEquals(isMatch("aab", "c*c*b*"), true);
}

bool RegexpMatcher::isMatch(const string str, const string pattern)
{
    return true;
}
