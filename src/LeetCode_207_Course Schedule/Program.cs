using System;
using System.Collections.Generic;

namespace LeetCode_207_Course_Schedule
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var numCourses = 2;
            var prerequisites = new int[][]
            {
                new int[] { 1,0 },
                new int[] { 0,1 }
            };

            var s = new Solution();
            Console.WriteLine(s.CanFinish(numCourses, prerequisites));
        }

        public class Solution
        {
            public bool CanFinish(int numCourses, int[][] prerequisites)
            {
                //  Approach: Topological Sort
                //  We first start to take the independent courses (no prerequisites or 0 indegree).
                // After taking the courses, we remove it out and update indegree of its dependent courses.
                //  Have a count variable to keep track of taken independent courses (0 indegree)
                //  Repeat process until
                //      1.  There is a circle in the graph which means there are still courses left and no course has 0 indegree
                //          => Cannot Finish
                //      2.  We take/travel all courses (count == numCourses) => Can finish
                //  BFS because we do layer by layer (independent courses => its neighbors)
                // ------------------------------------------------------------------------

                // Construct inDegree array and adjacency neighbor List
                int[] inDegreeArr = new int[numCourses];
                List<int>[] neighbors = new List<int>[numCourses];//neighbor of 3 is 4     3 --> 4   3 = {4}
                for (int i = 0; i < numCourses; i++)
                    neighbors[i] = new List<int>();

                //   c pre
                //  [0,1]    1-->0
                foreach (var p in prerequisites)
                {
                    neighbors[p[1]].Add(p[0]);
                    inDegreeArr[p[0]]++;
                }

                //BFS travel to all the courses
                //Starting with courses doesn't have prerequisite (indegree == 0)
                Queue<int> qu = new Queue<int>();
                for (int i = 0; i < numCourses; i++)
                    if (inDegreeArr[i] == 0)
                        qu.Enqueue(i);

                int count = 0; // count of courses has been visited
                while (qu.Count > 0)
                {
                    int course = qu.Dequeue();
                    count++;
                    foreach (var neighbor in neighbors[course])
                    {
                        //already visited the course => take the course out and decrease indegree of its neighbor
                        inDegreeArr[neighbor]--;
                        if (inDegreeArr[neighbor] == 0)
                            qu.Enqueue(neighbor);
                    }
                }
                return count == numCourses;
            }
        }
    }
}