#pragma once
#include <string>

using namespace std;

class RegexpMatcher
{
public:
    static void RunTestCases();
    static bool isMatch(const string& str, const string& pattern, const int posStr = 0, const int posPattern = 0);
    static bool isMatchDp(const string& str, const string& pattern);
};

