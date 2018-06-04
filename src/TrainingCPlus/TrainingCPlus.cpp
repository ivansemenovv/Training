// TrainingCPlus.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

#include "ContiguosSequenceSumToInteger.h"
#include "TaskScheduler.h"
#include "RegexpMatcher.h"
#include "ConvexHull.h"
#include "AddTwoNumbersAsLists.h"
#include "SpellCheckWildcard.h"
#include "NetworkComputerCounter.h"
#include "LongestIncreasingSubsequence.h"
#include "UniquePathsInGrid.h"

using namespace std;

int main()
{
    // ContiguosSequenceSumToInteger::RunTestCases();
    // TaskScheduler::RunTestCases();
    // RegexpMatcher::RunTestCases();
    // ConvexHull::RunTestCases();
    // AddTwoNumbersAsLists::RunTestCases();
    // SpellCheckWildcard::RunTestCases();
    // NetworkComputerCounter::RunTestCases();
    // LongestIncreasingSubsequence::RunTestCases();

    UniquePathsInGrid::RunTestCases();

    std::cout << "Please press 'Enter' to exit";
    string line;
    std::getline(std::cin, line);
    
    return 0;
}

