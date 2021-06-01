using System;

namespace LeetCode_211_Design_Add_and_Search_Words_DataStructure
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var wordDictionary = new WordDictionary();
            wordDictionary.AddWord("at");
            wordDictionary.AddWord("and");
            wordDictionary.AddWord("an");
            wordDictionary.AddWord("add");
            Console.WriteLine(wordDictionary.Search(".")); // return False
            //Console.WriteLine(wordDictionary.Search("bad")); // return True
            //Console.WriteLine(wordDictionary.Search(".ad")); // return True
            //Console.WriteLine(wordDictionary.Search("b..")); // return True
        }

        public class WordDictionary
        {
            /** Initialize your data structure here. */
            private TrieNode root;

            public WordDictionary()
            {
                root = new TrieNode();
            }

            public void AddWord(string word)
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

            public bool Search(string word)
            {
                return Search(word, root);
            }

            private bool Search(string word, TrieNode node)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    var c = word[i];
                    if (c == '.')
                    {
                        foreach (var childNode in node.nodes)
                        {
                            if (childNode != null)
                            {
                                var w = word[(i + 1)..];
                                if (Search(w, childNode))
                                {
                                    return true;
                                }
                            }
                        }

                        return false;
                    }
                    else
                    {
                        int index = c - 'a';
                        if (node.nodes[index] == null)
                        {
                            return false;
                        }
                        node = node.nodes[index];
                    }
                }

                return node.isWord;
            }
        }

        public class TrieNode
        {
            public bool isWord;
            public TrieNode[] nodes = new TrieNode[26];
        }
    }
}