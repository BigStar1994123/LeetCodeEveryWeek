using System;
using System.Collections.Generic;

namespace LeetCode_212_Word_Search_II
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var array2d = new char[][]
            {
                new char[] { 'o', 'a', 'a', 'n' },
                new char[] { 'e', 't', 'a', 'e'},
                new char[] { 'i','h','k','r'},
                new char[] { 'i', 'f', 'l', 'v' }
            };

            var words = new string[]
            {
                "eat","oath"
            };

            var s = new Solution();
            var list = s.FindWords(array2d, words);
        }

        public class Solution
        {
            private int xLength;
            private int yLength;
            private List<string> ans = new List<string>();

            public IList<string> FindWords(char[][] board, string[] words)
            {
                var trie = new Trie();
                foreach (var word in words)
                {
                    trie.Insert(word);
                }

                xLength = board.Length;
                yLength = board[0].Length;

                for (int i = 0; i < xLength; i++)
                {
                    for (int j = 0; j < yLength; j++)
                    {
                        DFS(i, j, trie.root, board);
                    }
                }

                return ans;
            }

            private void DFS(int x, int y, TrieNode node, char[][] board)
            {
                if (x < 0 || x == xLength || y < 0 || y == yLength || board[x][y] == '#')
                {
                    return;
                }

                var cur = board[x][y];
                var index = cur - 'a';
                var nextNode = node.nodes[index];
                if (nextNode == null)
                {
                    return;
                }

                if (!string.IsNullOrEmpty(nextNode.word))
                {
                    ans.Add(nextNode.word);
                    nextNode.word = null;
                }

                board[x][y] = '#';
                DFS(x + 1, y, nextNode, board);
                DFS(x - 1, y, nextNode, board);
                DFS(x, y + 1, nextNode, board);
                DFS(x, y - 1, nextNode, board);
                board[x][y] = cur;
            }
        }

        public class Trie
        {
            public TrieNode root;

            public Trie()
            {
                root = new TrieNode();
            }

            public void Insert(string word)
            {
                var node = root;
                foreach (var c in word)
                {
                    int index = c - 'a';
                    if (node.nodes[index] == null)
                    {
                        node.nodes[index] = new TrieNode();
                    }

                    node = node.nodes[index];
                }

                node.word = word;
            }
        }

        public class TrieNode
        {
            public string word;
            public TrieNode[] nodes = new TrieNode[26];
        }
    }
}