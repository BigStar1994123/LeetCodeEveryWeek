using System;

namespace LeetCode_424_Longest_Repeating_Character_Replacement
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();

            var text = "ABCDAA";
            var k = 2;

            Console.WriteLine(s.CharacterReplacement(text, k));
        }

        public class Solution
        {
            public int CharacterReplacement(string s, int k)
            {
                var len = s.Length;
                if (len < 2)
                {
                    return len;
                }

                var charArray = s.ToCharArray();
                var freq = new int[26];
                var maxCount = 0;

                int left = 0, right = 0, result = 0;
                while (right < len)
                {
                    freq[charArray[right] - 'A']++;
                    maxCount = Math.Max(maxCount, freq[charArray[right] - 'A']);
                    right++;

                    if (right - left > maxCount + k)
                    {
                        freq[charArray[left] - 'A']--;
                        left++;
                    }

                    result = Math.Max(result, right - left);
                }

                return result;
            }
        }
    }
}