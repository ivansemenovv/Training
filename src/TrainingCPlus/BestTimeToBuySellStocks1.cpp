#include "stdafx.h"
#include "BestTimeToBuySellStocks1.h"

using namespace std;

// Say you have an array for which the ith element is the price of a given stock on day i.
// If you were only permitted to complete at most one transaction(ie, buy one and sell one share of the stock), 
// design an algorithm to find the maximum profit.
//
//Example :
//Input: [1 2 1 4]
// diff [1 -1 3]
//    Return : 3


using namespace std;

void BestTimeToBuySellStocks1::RunTestCases()
{
    TestHelper::IsEquals(0, GetBestProfit(vector<int>{}));
    TestHelper::IsEquals(0, GetBestProfit(vector<int>{2, 1}));
    TestHelper::IsEquals(3, GetBestProfit(vector<int>{1, 2, 1, 4}));
}

int BestTimeToBuySellStocks1::GetBestProfit(const std::vector<int>& A)
{
    if (A.size() < 2) return 0;

    vector<int> diff(A.size() - 1);

    for (size_t i = 0; i < A.size() - 1; i++)
    {
        diff[i] = A[i + 1] - A[i];
    }

    int max_diff = diff[0];
    for (int i = 1; i < diff.size(); i++)
    {
        if (diff[i - 1] > 0)
            diff[i] += diff[i - 1];
        if (max_diff < diff[i])
            max_diff = diff[i];
    }

    return max_diff > 0 ? max_diff : 0;
}
