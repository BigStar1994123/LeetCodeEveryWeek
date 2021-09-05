using System;
using System.Collections.Generic;

namespace LeetCode_295_Find_Median_from_Data_Stream
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            MedianFinder medianFinder = new MedianFinder();
            medianFinder.AddNum(1);    // arr = [1]
            medianFinder.AddNum(2);    // arr = [1, 2]
            Console.WriteLine(medianFinder.FindMedian()); // return 1.5 (i.e., (1 + 2) / 2)
            medianFinder.AddNum(3);    // arr[1, 2, 3]
            Console.WriteLine(medianFinder.FindMedian()); // return 2.0
            medianFinder.AddNum(9999);    // arr[1, 2, 3,9999]
            Console.WriteLine(medianFinder.FindMedian()); // return 2.5
            medianFinder.AddNum(9998);
            medianFinder.AddNum(9997);
            Console.WriteLine(medianFinder.FindMedian());
        }

        public class MedianFinder
        {
            /** initialize your data structure here. */
            private readonly List<int> NumList;

            public MedianFinder()
            {
                NumList = new List<int>();
            }

            public void AddNum(int num)
            {
                var insertIndex = SearchInsert(NumList.ToArray(), num);
                NumList.Insert(insertIndex, num);
            }

            public double FindMedian()
            {
                var count = NumList.Count;
                if (count % 2 == 1)
                {
                    return NumList[count / 2];
                }
                else
                {
                    return (NumList[(count / 2) - 1] + NumList[count / 2]) / (double)2;
                }
            }

            private int SearchInsert(int[] nums, int target)
            {
                var left = 0;
                var right = nums.Length - 1;

                while (left <= right)
                {
                    var mid = (left + right) / 2;

                    if (nums[mid] > target)
                    {
                        right = mid - 1;
                    }
                    else if (nums[mid] < target)
                    {
                        left = mid + 1;
                    }
                    else
                    {
                        return mid;
                    }
                }

                return right + 1;
            }
        }
    }
}