#pragma once
#include "Node.h"

class AddTwoNumbersAsLists
{
public:
    static void RunTestCases();
    static Node* AddNumbers(const Node* number1, const Node* number2, int remaining = 0);
};

