using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_406_Queue_Reconstruction_by_Height
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var people = new int[][]
            //{
            //    new int[] {7,0},
            //    new int[] {4,4},
            //    new int[] {7,1},
            //    new int[] {5,0},
            //    new int[] {6,1},
            //    new int[] {5,2}
            //};

            var people = new int[][]
            {
                new int[] {6,0},
                new int[] {5,0},
                new int[] {4,0},
                new int[] {3,2},
                new int[] {2,2},
                new int[] {1,4}
            };

            var s = new Solution();
            var result = s.ReconstructQueue(people);

            Console.WriteLine(string.Join(" | ", result.Select(x => string.Join(",", x))));
        }

        public class Solution2
        {
            public int[][] ReconstructQueue(int[][] people)
            {
                // 身高從大到小排序，身高相同則k小的在前面
                Array.Sort(people, Comparer<int[]>.Create((a, b) =>
                {
                    if (a[0] == b[0])
                    {
                        return a[1] - b[1];
                    }

                    return b[0] - a[0];
                }));

                //var sortedPeople = people.ToList().OrderByDescending(x => x[0]).ThenBy(x => x[1]);

                var result = new List<int[]>();

                foreach (var p in people)
                {
                    result.Insert(p[1], p);
                }

                return result.ToArray();
            }
        }

        public class Solution
        {
            // 自己寫的方法，會Timeout
            public int[][] ReconstructQueue(int[][] people)
            {
                var result = new List<int[]>();

                var count = 0;
                var peopleLength = people.Length;
                var recordHeightDict = new Dictionary<int, int>();

                // 總共就做 N 次，每次找一個答案塞進 result
                while (count < peopleLength)
                {
                    // 尋找可能成為答案的候選答案
                    var candidatePeople = new List<int[]>();

                    for (int i = 0; i < peopleLength - count; i++)
                    {
                        if (people[i][1] <= count)
                        {
                            // 候選答案和之前已經排序好的答案比一下身高和數字
                            var height = people[i][0];
                            var tallerThanHeightCounts = recordHeightDict.Where(x => x.Key >= height).Sum(x => x.Value);

                            if (tallerThanHeightCounts >= people[i][1])
                            {
                                candidatePeople.Add(people[i]);
                            }
                        }
                    }

                    // 從候選答案選出相對數字較小的當作答案
                    var winnerValue = candidatePeople.Min(x => x[0]);
                    var winner = candidatePeople.FirstOrDefault(x => x[0] == winnerValue);
                    result.Add(winner);

                    // 移除答案在原本的 Array
                    var tempList = people.ToList();
                    tempList.RemoveAll(x => x[0] == winner[0] && x[1] == winner[1]);
                    people = tempList.ToArray();

                    count++;
                    // 紀錄身高紀錄
                    if (!recordHeightDict.ContainsKey(winnerValue))
                    {
                        recordHeightDict.Add(winnerValue, 1);
                    }
                    else
                    {
                        recordHeightDict[winnerValue]++;
                    }
                }

                return result.ToArray();
            }
        }
    }
}