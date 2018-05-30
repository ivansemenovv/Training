#pragma once

class Point
{
public:
    int x;
    int y;
    Point(int x, int y)
    {
        this->x = x;
        this->y = y;
    }

    bool operator !=(Point p)
    {
        return this->x != p.x || this->y != p.y;
    }
};

class ConvexHull
{
public:
    static void RunTestCases();
    static std::vector<Point> GetConvexHull(std::vector<Point>& points);

private:
    static float CrossProduct(Point p, Point r, Point q);
};

