using System;

namespace Leetcode67_Add_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var s = new Solution();
            var result = s.AddBinary(  "11", 
                                     "1011"); 
                                   //  110 
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }

    public class Solution
    {
        public string AddBinary(string a, string b)
        {
            if (a.Length > b.Length)
            {
                var diff = a.Length - b.Length;
                for (int i = 0; i < diff; i++)
                {
                    b = "0" + b;
                }
            }
            else
            {
                var diff = b.Length - a.Length;
                for (int i = 0; i < diff; i++)
                {
                    a = "0" + a;
                }
            }

            var carry = false;
            var r = '0';
            var result = "";
            for (var i = a.Length - 1; i >= 0; i--)
            {
                (r, carry) = AddChar(a[i], b[i], carry);

                result = r + result;
            }

            if (carry)
            {
                result = '1' + result;
            }

            return result;
        }

        private (char, bool) AddChar(char a, char b, bool carry)
        {
            var r = '0';
            var nextCarry = false;

            if (a == '1' && b == '1')
            {
                r = '0';
                nextCarry = true;
            }
            else if (a == '0' && b == '1')
            {
                r = '1';
                nextCarry = false;
            }
            else if (a == '1' && b == '0')
            {
                r = '1';
                nextCarry = false;
            }
            else if(a == '0' && b == '0')
            {
                r = '0';
                nextCarry = false;
            }

            var nextCarry1 = false;
            if (carry)
            {
                (r, nextCarry1) = AddChar(r, '1', false);
            }

            return (r, nextCarry || nextCarry1);
        }
    }
}
