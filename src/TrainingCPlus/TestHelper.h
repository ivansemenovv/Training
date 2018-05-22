#pragma once
#include <exception>

using namespace std;
class TestHelper
{
public:
    template <typename T>
    static void IsEquals(T first, T second)
    {
        if (first != second)
        {
            throw exception("values are not equal");
        }
    }
};