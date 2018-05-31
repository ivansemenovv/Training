#include "stdafx.h"
#include "AddTwoNumbersAsLists.h"

void AddTwoNumbersAsLists::RunTestCases()
{
    Node* number1 = new Node(1);
    number1->Next = new Node(2);
    number1->Next->Next = new Node(6);

    Node* number2 = new Node(4);
    number2->Next = new Node(8);
    number2->Next->Next = new Node(3);
    number2->Next->Next->Next = new Node(5);
    number2->Next->Next->Next->Next = new Node(1);

    Node* expectedResult = new Node(5);
    expectedResult->Next = new Node(0);
    expectedResult->Next->Next = new Node(0);
    expectedResult->Next->Next->Next = new Node(6);
    expectedResult->Next->Next->Next->Next = new Node(1);

    Node* result = AddNumbers(number1, number2);
    Node* t = result;
    Node* te = expectedResult;
    while (t != nullptr && te != nullptr)
    {
        TestHelper::IsEquals(t->Value, te->Value);
        t = t->Next;
        te = te->Next;
    }
}

Node* AddTwoNumbersAsLists::AddNumbers(const Node* number1, const Node* number2, int remaining)
{
    if (number1 == nullptr && number2 == nullptr && remaining == 0)
    {
        return nullptr;
    }

    int newValue = remaining;
    if (number1 != nullptr)
    {
        newValue += number1->Value;
    }

    if (number2 != nullptr)
    {
        newValue += number2->Value;
    }

    int r = newValue / 10;
    int v = newValue % 10;
    Node* newNode = new Node(v);
    newNode->Next = AddNumbers(number1 == nullptr ? nullptr : number1->Next,
                               number2 == nullptr ? nullptr : number2->Next, r);
    return newNode;
}