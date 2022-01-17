// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var s = new Solution();
Console.WriteLine(s.IsSubsequence("abc", "ahbgd"));

public class Solution
{
    public bool IsSubsequence(string s, string t)
    {
        var i = 0;

        for (int j = 0; j < t.Length; j++)
        {
            if (i == s.Length)
            {
                return true;
            }

            if (s[i] == t[j])
            {
                i++;
            }
        }

        return i == s.Length;
    }
}