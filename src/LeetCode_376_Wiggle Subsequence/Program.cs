using System;

namespace LeetCode_376_Wiggle_Subsequence
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //var nums = new int[] { 1, 7, 4, 9, 2, 5 };
            //var nums = new int[] { 1, 17, 5, 10, 13, 15, 10, 5, 16, 8 };
            var nums = new int[] { 0, 0, 0 };

            var s = new Solution();
            Console.WriteLine(s.WiggleMaxLength(nums));
        }

        public class Solution
        {
            private enum Directory
            {
                Unknown,
                Up,
                Down
            }

            public int WiggleMaxLength(int[] nums)
            {
                if (nums.Length <= 1)
                {
                    return nums.Length;
                }

                var count = 1;
                var directory = Directory.Unknown;

                for (int i = 1; i < nums.Length; i++)
                {
                    if (directory == Directory.Unknown)
                    {
                        if (nums[i] < nums[i - 1])
                        {
                            directory = Directory.Down;
                            count++;
                        }
                        else if (nums[i] > nums[i - 1])
                        {
                            directory = Directory.Up;
                            count++;
                        }
                    }

                    if (directory == Directory.Up && nums[i] < nums[i - 1])
                    {
                        directory = Directory.Down;
                        count++;
                    }
                    else if (directory == Directory.Down && nums[i] > nums[i - 1])
                    {
                        directory = Directory.Up;
                        count++;
                    }
                }

                return count;
            }
        }
    }
}