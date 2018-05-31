#include "stdafx.h"
#include "NetworkComputerCounter.h"


void NetworkComputerCounter::RunTestCases()
{
    shared_ptr<Computer> c1 = make_shared<Computer>(1);
    shared_ptr<Computer> c2 = make_shared<Computer>(2);
    shared_ptr<Computer> c3 = make_shared<Computer>(3);
    shared_ptr<Computer> c4 = make_shared<Computer>(4);
    shared_ptr<Computer> c5 = make_shared<Computer>(5);

    c1->Connections.push_back(c2);
    c1->Connections.push_back(c3);
    c1->Connections.push_back(c4);

    c2->Connections.push_back(c1);
    c2->Connections.push_back(c3);

    c3->Connections.push_back(c1);
    c3->Connections.push_back(c2);
    c3->Connections.push_back(c5);

    c4->Connections.push_back(c1);
    c4->Connections.push_back(c5);

    c5->Connections.push_back(c3);
    c5->Connections.push_back(c4);

    TestHelper::IsEquals(5, GetComputersCount(c1.get()));
}


int NetworkComputerCounter::GetComputersCount(Computer* computer)
{
    int counter = 0;
    return computer->OnReceive(computer, counter);
}
