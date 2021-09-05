using System;

namespace LeetCode_371_Sum_of_Two_Integers
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var a = 5;
            var b = 0;

            var s = new Solution();
            Console.WriteLine(s.GetSum(a, b));
        }

        public class Solution
        {
            public int GetSum(int a, int b)
            {
                var sa = Convert.ToString(a, 2);
                var sb = Convert.ToString(b, 2);
                var _2csb = findTwoscomplement(sb);
                var resultBinaryString = AddTwoBinaryString(sa, _2csb);
                var result = Convert.ToInt64(resultBinaryString, 2);

                return (int)result;
            }

            /// <summary>
            /// Copied from https://www.geeksforgeeks.org/program-to-add-two-binary-strings/
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            private string AddTwoBinaryString(string a, string b)
            {
                // Initialize result
                string result = "";

                // Initialize digit sum
                int s = 0;

                // Traverse both strings starting
                // from last characters
                int i = a.Length - 1, j = b.Length - 1;
                while (i >= 0 || j >= 0 || s == 1)
                {
                    // Comput sum of last
                    // digits and carry
                    s += ((i >= 0) ? a[i] - '0' : 0);
                    s += ((j >= 0) ? b[j] - '0' : 0);

                    // If current digit sum is
                    // 1 or 3, add 1 to result
                    result = (char)(s % 2 + '0') + result;

                    // Compute carry
                    s /= 2;

                    // Move to next digits
                    i--; j--;
                }
                return result;
            }

            /// <summary>
            /// Copied from https://www.geeksforgeeks.org/efficient-method-2s-complement-binary-string/
            /// </summary>
            /// <param name="str"></param>
            /// <returns></returns>
            private string findTwoscomplement(string str)
            {
                if (str == "0")
                {
                    return "00000000";
                }

                int n = str.Length;

                // Traverse the string to get
                // first '1' from the last of string
                int i;
                for (i = n - 1; i >= 0; i--)
                {
                    if (str[i] == '1')
                    {
                        break;
                    }
                }

                // If there exists no '1' concat 1
                // at the starting of string
                if (i == -1)
                {
                    return "1" + str;
                }

                // Continue traversal after the
                // position of first '1'
                for (int k = i - 1; k >= 0; k--)
                {
                    // Just flip the values
                    if (str[k] == '1')
                    {
                        str.Remove(k, k + 1 - k).Insert(k, "0");
                    }
                    else
                    {
                        str.Remove(k, k + 1 - k).Insert(k, "1");
                    }
                }

                // return the modified string
                return str.ToString();
            }
        }
    }
}