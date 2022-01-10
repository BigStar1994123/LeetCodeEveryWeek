// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var s = new Solution();
var text1 = "bl";
var text2 = "yby";

Console.WriteLine(s.LongestCommonSubsequence(text1, text2));

public class Solution
{
    public int LongestCommonSubsequence(string text1, string text2)
    {
        //Enumerable.Range(0, nums1.Length + 1).Select(x => Enumerable.Repeat(0, nums2.Length + 1).ToArray()).ToArray();
        var dp = Enumerable.Range(0, text1.Length + 1).Select(x => Enumerable.Repeat<int>(0, text2.Length + 1).ToArray()).ToArray();

        for (int i = 1; i <= text1.Length; i++)
        {
            for (int j = 1; j <= text2.Length; j++)
            {
                if (text1[i - 1] == text2[j - 1])
                {
                    dp[i][j] = dp[i - 1][j - 1] + 1;
                }
                else
                {
                    dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]);
                }
            }
        }

        return dp[text1.Length][text2.Length];
    }
}