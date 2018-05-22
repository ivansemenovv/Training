#include "stdafx.h"
#include "TaskScheduler.h"

using namespace std;

#define EMPTY_SLOT '#'

void TaskScheduler::RunTestCases()
{
    vector<char> tasks{ 'A','B', 'B','A','B','B','C' };
    TestHelper::IsEquals(13, GetMinTime(tasks, 3));
    TestHelper::IsEquals(10, GetMinTime(tasks, 2));
    TestHelper::IsEquals(16, GetMinTime(tasks, 4));
    TestHelper::IsEquals(19, GetMinTime(tasks, 5));
}

int TaskScheduler::GetMinTime(std::vector<char> tasks, int k)
{
    int taskCount = tasks.size();
    auto frequencyMap = GetTaskFrequencies(tasks);
    TaskFreq emptySlot(EMPTY_SLOT, 0);

    queue<TaskFreq> restQueue;
    int time = 0;
    while (taskCount > 0)
    {
        if (!frequencyMap.empty())
        {
            auto top = frequencyMap.top();
            frequencyMap.pop();
            top.second = top.second - 1;
            taskCount--;
            if (top.second > 0)
            {
                restQueue.push(top);
            }
            else
                restQueue.push(emptySlot);
        }
        else
        { 
            restQueue.push(emptySlot);
        }
        time++;

        if (restQueue.size() == k + 1)
        {
            auto restTop = restQueue.front();
            restQueue.pop();
            if(restTop.first != EMPTY_SLOT)
                frequencyMap.push(restTop);
        }
    }

    return time;
}

TaskFreqMap TaskScheduler::GetTaskFrequencies(vector<char> tasks)
{
    unordered_map<char, int> taskMap; 
    TaskFreqMap result(comparator);
    for (auto& t : tasks)
    {
        auto it = taskMap.find(t);
        if (it != taskMap.end())
        {
            it->second = it->second + 1;
        }
        else
        {
            taskMap[t] = 1;
        }
    }

    for (const auto& pair : taskMap)
    {
        result.push(pair);
    }
    return result;
}



