#pragma once
#include <string>

using namespace std;

class RegexpMatcher
{
public:
    static void RunTestCases();
    static bool isMatch(const string str, const string pattern);
};

