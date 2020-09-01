using System;

namespace Trie
{

    class Program
    {
        public class Trie
        {

            public class TrieNode
            {
                static readonly int AlphbetSize = 26;
                public TrieNode[] children = new TrieNode[AlphbetSize];
                //marker for end of a word
                public bool isEndOfWord;
                public TrieNode()
                {
                    isEndOfWord = false;
                    for (int i = 0; i < AlphbetSize; i++)
                    {
                        children[i] = null;
                    }
                }

            };
            static TrieNode root;

            //If not present then insert key
            //If key is prefix of trie node, mark leaf node
            public static void insert(string key)
            {
                int level;
                int length = key.Length;
                int index;
                TrieNode runner = root;
                for (level = 0; level < length; level++)
                {
                    index = key[level] - 'a'; //a=97 b=98 c=99
                    if (runner.children[index] == null)
                        runner.children[index] = new TrieNode();
                    runner = runner.children[index];
                }
                //mark last node as leaf
                runner.isEndOfWord = true;
            }
            //return true if key
            //presents in trie, else false
            public static bool search(String key)
            {
                int level;
                int length = key.Length;
                int index;
                TrieNode pCrawl = root;

                for (level = 0; level < length; level++)
                {
                    index = key[level] - 'a';

                    if (pCrawl.children[index] == null)
                        return false;

                    pCrawl = pCrawl.children[index];
                }

                return (pCrawl != null && pCrawl.isEndOfWord);
            }
            static void Main(string[] args)
            {
                // Input keys (use only 'a'  
                // through 'z' and lower case) 
                String[] keys = {"the", "a", "there", "answer",
                        "any", "by", "bye", "their"};

                String[] output = { "Not present in trie", "Present in trie" };


                root = new TrieNode();

                // Construct trie 
                int i;
                for (i = 0; i < keys.Length; i++)
                    insert(keys[i]);

                // Search for different keys 
                if (search("the") == true)
                    Console.WriteLine("the --- " + output[1]);
                else Console.WriteLine("the --- " + output[0]);

                if (search("these") == true)
                    Console.WriteLine("these --- " + output[1]);
                else Console.WriteLine("these --- " + output[0]);

                if (search("their") == true)
                    Console.WriteLine("their --- " + output[1]);
                else Console.WriteLine("their --- " + output[0]);

                if (search("thaw") == true)
                    Console.WriteLine("thaw --- " + output[1]);
                else Console.WriteLine("thaw --- " + output[0]);

            }
        };

    }
}

