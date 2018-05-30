#include "stdafx.h"
#include "ConvexHull.h"

using namespace std;

void ConvexHull::RunTestCases()
{
    vector<Point> points
    { 
        Point(-4, -1),
        Point(-3, 1),
        Point(-2, 2),
        Point(-2, -1),
        Point(-1, 4),
        Point(-1, 1),
        Point(-1, -1),
        Point(-1, -2),
        Point(0, -3),
        Point(1, 5),
        Point(1, 3),
        Point(1, 2),
        Point(1, 1),
        Point(1, -1),
        Point(1, -2),
        Point(2, 3),
        Point(2, 2),
        Point(2, 1),
        Point(2, -1),
        Point(3, 3),
        Point(3, 2),
        Point(3, 1)
    };

    vector<Point> hull = GetConvexHull(points);
}

std::vector<Point> ConvexHull::GetConvexHull(std::vector<Point>& points)
{
    std::vector<Point> hull;
    auto minElementIterator =  std::min_element(points.begin(), points.end(), 
        [](const auto& first, const auto& second) { return first.x < second.x; });
    

    int startPointIndex =  minElementIterator - points.begin();
    int currentPointIndex = startPointIndex;

    do
    {
        hull.push_back(points[currentPointIndex]);
        int nextPointIndex = (currentPointIndex + 1) % points.size();
        for (int i = 0; i < points.size(); i++)
        {
            if (CrossProduct(points[currentPointIndex], points[nextPointIndex], points[i]) > 0)
                nextPointIndex = i;
        }
        currentPointIndex = nextPointIndex;

    } while (startPointIndex != currentPointIndex);

    return hull;
}

float ConvexHull::CrossProduct(Point p, Point r, Point q)
{
    Point v1(r.x - p.x, r.y - p.y);
    Point v2(q.x - p.x, q.y - p.y);
    return v1.x * v2.y - v1.y * v2.x;
}
