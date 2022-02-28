using System;

namespace Leetcode942_DI_String_Match
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var testString = "DIDI";
            foreach(var s in DiStringMatch(testString))
            {
                Console.WriteLine(s + " ");
            }
            
        }
        static int[] DiStringMatch(string S)
        {
            if (S.Length > 10000)
            {
                return new int[0];
            }
            var maxValue = S.Length;
            var minValue = 0;
            var retArray = new int[S.Length + 1];
            for(var i  = 0; i < S.Length; i++)
            {
                if (S[i] == 'I')
                {
                    retArray[i] = minValue;
                    minValue++;
                }
                else if (S[i] == 'D')
                {
                    retArray[i] = maxValue;
                    maxValue--;
                }
            }
            retArray[S.Length] = maxValue;

            return retArray;
        }

    }
}
