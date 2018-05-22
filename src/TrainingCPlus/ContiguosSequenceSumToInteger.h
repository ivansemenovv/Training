#pragma once
#include <vector>

using namespace std;
class Interval
{
public:
    int Start;
    int End;

    Interval(int start, int end)
    {
        Start = start;
        End = end;

        cout << "Constructor Interval" << std::endl;
    }

    Interval(Interval&& other)
    {
        Start = other.Start;
        End = other.End;

        cout << "Move Constructor Interval" << std::endl;
    }

    Interval(Interval& other)
    {
        Start = other.Start;
        End = other.End;

        cout << "Copy Constructor Interval" << std::endl;
    }

    ~Interval()
    {
        cout << "Destructor Interval" << std::endl;
    }
    
    bool operator !=(Interval& other)
    {
        return Start != other.Start || End != other.End;
    }
};

class ContiguosSequenceSumToInteger
{
public:
    static void RunTestCases();
    static Interval GetIntervalToMatchSum(std::vector<int> a, int sum);
};

