using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training
{
    class IslandCounter
    {
        public static void RunTestsCases()
        {
            int[][] land1 = new int[][] {
                new int[]{ 1, 1, 0},
                new int[]{ 0, 0, 0},
                new int[]{ 0, 1, 1},
            };
            TestHelper.IsEquals(CountIslands(land1), 2);

            int[][] land2 = new int[][] {
                new int[]{ 1, 1, 0, 1},
                new int[]{ 0, 0, 1, 0},
                new int[]{ 0, 1, 1, 0},
                new int[]{ 0, 0, 1, 0},
            };
            TestHelper.IsEquals(CountIslands(land2), 1);

            int[][] land3 = new int[][] {
                new int[]{ 1, 0, 1, 0},
                new int[]{ 0, 0, 0, 0},
                new int[]{ 0, 1, 0, 1},
                new int[]{ 0, 0, 0, 0},
            };
            TestHelper.IsEquals(CountIslands(land3), 4);
        }

        public static int CountIslands(int[][] land)
        {
            int counter = 0;
            for (int i = 0; i < land.Length; i++)
            {
                for (int j = 0; j < land[i].Length; j++)
                {
                    if(land[i][j] > 0)
                    {
                        RemoveIsland(ref land, new KeyValuePair<int, int>(i, j));
                        counter++;
                    }
                }
            }
            return counter;
        }

        private static void RemoveIsland(ref int[][] land, KeyValuePair<int, int> start_pos)
        {
            Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();
            q.Enqueue(start_pos);
            while(q.Count > 0)
            {
                var sp = q.Dequeue();
                int i = sp.Key;
                int j = sp.Value;
                land[i][j] = 0;

                List<KeyValuePair<int, int>> neigbors = new List<KeyValuePair<int, int>>(8);
                neigbors.Add(new KeyValuePair<int, int>(i - 1, j - 1));
                neigbors.Add(new KeyValuePair<int, int>(i - 1, j));
                neigbors.Add(new KeyValuePair<int, int>(i - 1, j + 1));
                neigbors.Add(new KeyValuePair<int, int>(i, j - 1));
                neigbors.Add(new KeyValuePair<int, int>(i, j + 1));
                neigbors.Add(new KeyValuePair<int, int>(i + 1, j - 1));
                neigbors.Add(new KeyValuePair<int, int>(i + 1, j));
                neigbors.Add(new KeyValuePair<int, int>(i + 1, j + 1));

                foreach (var pos in neigbors)
                {
                    if(pos.Key >= 0 && pos.Key < land.Length &&
                        pos.Value >= 0 && pos.Value < land[pos.Key].Length)
                    {
                        if(land[pos.Key][pos.Value] > 0)
                        {
                            q.Enqueue(new KeyValuePair<int, int>(pos.Key, pos.Value));
                        }
                    }
                }
            }
        }
    }
}
