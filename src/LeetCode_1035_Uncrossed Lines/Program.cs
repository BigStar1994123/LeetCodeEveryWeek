// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var s = new Solution();
var nums1 = new int[] { 1, 3, 7, 1, 7, 5 };
var nums2 = new int[] { 1, 9, 2, 5, 1 };

Console.WriteLine(s.MaxUncrossedLines(nums1, nums2));

public class Solution
{
    public int MaxUncrossedLines(int[] nums1, int[] nums2)
    {
        var dp = Enumerable.Repeat(0, nums1.Length + 1).Select(x => Enumerable.Repeat(0, nums2.Length + 1).ToArray()).ToArray();

        for (int i = 1; i <= nums1.Length; i++)
        {
            for (int j = 1; j <= nums2.Length; j++)
            {
                if (nums1[i - 1] == nums2[j - 1])
                {
                    dp[i][j] = dp[i - 1][j - 1] + 1;
                }
                else
                {
                    dp[i][j] = Math.Max(dp[i - 1][j], dp[i][j - 1]);
                }
            }
        }

        return dp[nums1.Length][nums2.Length];
    }
}