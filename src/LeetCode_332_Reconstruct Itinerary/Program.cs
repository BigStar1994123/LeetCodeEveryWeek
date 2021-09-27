using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCode_332_Reconstruct_Itinerary
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var tickets = new List<IList<string>>
            {
                new List<string> { "JFK", "KUL" },
                new List<string> { "JFK", "NRT" },
                new List<string> { "NRT", "JFK" }
            };

            var s = new Solution();
            var result = s.FindItinerary(tickets);

            Console.WriteLine(string.Join(" -> ", result));
        }

        public class Solution
        {
            private IList<string> _result = new List<string>();
            private Dictionary<string, Dictionary<string, int>> _map = new Dictionary<string, Dictionary<string, int>>();

            public IList<string> FindItinerary(IList<IList<string>> tickets)
            {
                foreach (var ticket in tickets)
                {
                    if (_map.ContainsKey(ticket[0]))
                    {
                        if (_map[ticket[0]].ContainsKey(ticket[1]))
                        {
                            _map[ticket[0]][ticket[1]]++;
                        }
                        else
                        {
                            _map[ticket[0]][ticket[1]] = 1;
                        }
                    }
                    else
                    {
                        _map[ticket[0]] = new Dictionary<string, int>
                        {
                            [ticket[1]] = 1
                        };
                    }
                }

                foreach (var mapKeyValuePair in _map.ToDictionary(x => x.Key, x => x.Value))
                {
                    // Sort dictionary
                    var d = mapKeyValuePair.Value;
                    var sd = d.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
                    _map[mapKeyValuePair.Key] = sd;
                }

                _result.Add("JFK");
                BackTracking(tickets.Count);
                return _result;
            }

            private bool BackTracking(int ticketNum)
            {
                if (_result.Count == ticketNum + 1)
                {
                    return true;
                }

                var nowPosition = _result[_result.Count - 1];
                if (!_map.ContainsKey(nowPosition))
                {
                    return false;
                }

                foreach (var targetPair in _map[nowPosition].ToDictionary(x => x.Key, x => x.Value))
                {
                    if (targetPair.Value > 0)
                    {
                        _result.Add(targetPair.Key);
                        _map[nowPosition][targetPair.Key]--;
                        if (BackTracking(ticketNum))
                        {
                            return true;
                        }
                        _result.RemoveAt(_result.Count - 1);
                        _map[nowPosition][targetPair.Key]++;
                    }
                }

                return false;
            }
        }
    }
}