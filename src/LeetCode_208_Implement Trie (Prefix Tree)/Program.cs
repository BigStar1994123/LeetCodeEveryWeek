using System;

namespace LeetCode_208_Implement_Trie__Prefix_Tree_
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Trie trie = new Trie();
            trie.Insert("apple");
            Console.WriteLine(trie.Search("apple"));   // return True
            Console.WriteLine(trie.Search("app"));     // return False
            Console.WriteLine(trie.StartsWith("app")); // return True
            trie.Insert("app");
            Console.WriteLine(trie.Search("app"));     // return True
        }

        public class TrieNode
        {
            public bool isWord;
            public TrieNode[] nodes = new TrieNode[26];
        }

        public class Trie
        {
            private TrieNode root;

            /** Initialize your data structure here. */

            public Trie()
            {
                root = new TrieNode();
            }

            /** Inserts a word into the trie. */

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

                node.isWord = true;
            }

            /** Returns if the word is in the trie. */

            public bool Search(string word)
            {
                var node = root;

                foreach (var c in word)
                {
                    int index = c - 'a';
                    if (node.nodes[index] == null)
                    {
                        return false;
                    }

                    node = node.nodes[index];
                }

                return node.isWord;
            }

            /** Returns if there is any word in the trie that starts with the given prefix. */

            public bool StartsWith(string prefix)
            {
                var node = root;

                foreach (var c in prefix)
                {
                    int index = c - 'a';
                    if (node.nodes[index] == null)
                    {
                        return false;
                    }

                    node = node.nodes[index];
                }

                return true;
            }
        }
    }
}