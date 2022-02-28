using System;

namespace LeetCode58_Length_of_Last_Word
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var s = new Solution();
            var result = s.LengthOfLastWord("a ");
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

    public class Solution
    {
        public int LengthOfLastWord(string s)
        {
            var array = s.Trim().Split(' ');
            var index = array.Length - 1;
            return array[index].Length;
        }
    }
}
