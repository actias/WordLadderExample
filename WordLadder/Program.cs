using System;
using System.Collections.Generic;
using System.Linq;

namespace WordLadder
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new[] { "head", "bead", "beam", "heat", "heal", "teal", "tell", "yell", "yelp", "help", "tall", "fall", "fail", "tail", "mail" };
            var start = "head";
            var end = "tail";
            var results = GetWords(list, start, end);

            Console.WriteLine(string.Join(",", results));
            Console.ReadLine();
        }

        public static string[] GetWords(string[] input, string start, string end)
        {
            var source = input.ToList();
            var words = new List<string>();
            var previous = start;
            var l = source.Count;

            start = start.ToLower();
            end = end.ToLower();

            for(var i = 0; i < l; ++i)
            {
                var current = source[i].ToLower();

                if (current == end) break;

                if (previous == current)
                {
                    words.Add(current);
                    continue;
                }

                if (CompareWords(previous, current))
                {
                    words.Add(current);
                    previous = current;
                    continue;
                }
                
                words.Clear();
                source.Remove(previous);

                l = source.Count;
                i = 0;

                previous = start;
            }

            words.Insert(0, start);
            words.Add(end);

            return words.ToArray();
        }
        
        public static bool CompareWords(string a, string b)
        {
            int matchCount = 0;
            var l = a.Length;

            for(var i = 0; i < l; ++i)
            {
                matchCount += a[i] == b[i] ? 1 : 0;
            }

            return matchCount == l - 1;
        }
    }
}
