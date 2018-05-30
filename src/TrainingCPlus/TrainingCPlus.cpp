// TrainingCPlus.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include "ContiguosSequenceSumToInteger.h"
#include "TaskScheduler.h"
#include "RegexpMatcher.h"
#include "ConvexHull.h"

using namespace std;

int main()
{
    //ContiguosSequenceSumToInteger::RunTestCases();
    //TaskScheduler::RunTestCases();
    //RegexpMatcher::RunTestCases();
    ConvexHull::RunTestCases();

    std::cout << "Please press 'Enter' to exit";
    string line;
    std::getline(std::cin, line);
    
    return 0;
}

