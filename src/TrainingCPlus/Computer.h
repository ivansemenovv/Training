#pragma once
class Computer
{
public:
    Computer(int id);
    ~Computer();

    std::vector<std::shared_ptr<Computer>> Connections;

    int Send(Computer* computer, int value);
    int OnReceive(Computer* fromComputer, int value);

private: 
    int id;
    bool isCounted = false;
};

