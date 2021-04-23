using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_49_Group_Anagrams
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var strs = new string[] { "eat", "tea", "tan", "ate", "nat", "bat" };

            var s = new Solution();
            var list = s.GroupAnagrams(strs);
        }
    }

    public class Solution
    {
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            var result = new List<IList<string>>();

            var sortedStrs = strs.Select(x => string.Concat(x.OrderBy(c => c))).ToArray();

            var dict = new Dictionary<string, int>();
            for (int i = 0; i < sortedStrs.Length; i++)
            {
                var sortedStr = sortedStrs[i];
                var originStr = strs[i];

                if (dict.ContainsKey(sortedStr))
                {
                    var list = result[dict[sortedStr]];
                    list.Add(originStr);
                }
                else
                {
                    var list = new List<string>();
                    list.Add(originStr);
                    dict.Add(sortedStr, result.Count);
                    result.Add(list);
                }
            }

            //var alreadyUseIterator = new HashSet<int>();
            //for (var i = 0; i < sortedStrs.Length; i++)
            //{
            //    if (alreadyUseIterator.Contains(i))
            //    {
            //        continue;
            //    }

            //    alreadyUseIterator.Add(i);

            //    var targetStr = sortedStrs[i];
            //    var resultItem = new List<string>();
            //    resultItem.Add(strs[i]);

            //    for (var j = i + 1; j < sortedStrs.Length; j++)
            //    {
            //        var comparedStr = sortedStrs[j];
            //        if (comparedStr == targetStr)
            //        {
            //            resultItem.Add(strs[j]);
            //            alreadyUseIterator.Add(j);
            //        }
            //    }

            //    result.Add(resultItem);
            //}

            return result;
        }
    }
}