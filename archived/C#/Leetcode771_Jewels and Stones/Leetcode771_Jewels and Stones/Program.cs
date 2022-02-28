using System;

namespace Leetcode771_Jewels_and_Stones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public int NumJewelsInStones(string J, string S)
        {
            int count = 0;
            foreach(char c1 in J)
            {
                foreach(char c2 in S)
                {
                    if (c1 == c2)
                    {
                        count += 1;
                    }
                }
            }
            return count;
        }

    }
}
