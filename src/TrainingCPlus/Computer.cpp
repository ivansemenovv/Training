#include "stdafx.h"
#include "Computer.h"


Computer::Computer(int id)
{
    this->id = id;
}

Computer::~Computer()
{

}

int Computer::Send(Computer* computer, int value)
{
    return computer->OnReceive(this, value);
}

int Computer::OnReceive(Computer* fromComputer, int value)
{
    if (isCounted)
        return value;
    isCounted = true;
    int newCounter = value + 1;
    for (auto& c : Connections)
    {
        if (c->id != fromComputer->id)
            newCounter = Send(c.get(), newCounter);
    }
    return newCounter;
}
