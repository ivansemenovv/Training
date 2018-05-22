#pragma once
#include <vector>
#include <queue>

using namespace std;

typedef pair<char, int> TaskFreq;
typedef vector<TaskFreq> TaskFreqContainer;
__declspec(selectany) auto comparator = [](const TaskFreq& left, const TaskFreq& right) { return left.second < right.second; };
typedef priority_queue <TaskFreq, TaskFreqContainer, decltype(comparator)> TaskFreqMap;

class TaskScheduler
{
public:
    static void RunTestCases();
    static int GetMinTime(std::vector<char> tasks, int k);

private:
    
    static TaskFreqMap GetTaskFrequencies(vector<char> tasks);
};

