using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AoC2015_5
{
    class Program
    {

        static void Main(string[] args)
        {
            Debug.Assert(IsNaughty("ugknbfddgicrmopn") == false );
            Debug.Assert(IsNaughty("aaa") == false );
            Debug.Assert(IsNaughty("jchzalrnumimnmhp") == true );
            Debug.Assert(IsNaughty("haegwjzuvuyypxyu") == true );
            Debug.Assert(IsNaughty("dvszwmarrgswjxmb") == true );
            
            Debug.Assert(IsNice("qjhvhtzxzqqjkmpb") == true );
            Debug.Assert(IsNice("xxyxx") == true);
            Debug.Assert(IsNice("uurcxstgmygtbstg") == false );
            Debug.Assert(IsNice("ieodomkazucvgmuy") == false);

            var data = File.ReadLines("data.txt");
            var niceCount = 0;

            foreach (var line in data)
            {
                if (IsNice(line)) niceCount++;
            }

            Console.WriteLine($"Nice lines = {niceCount}");
        }

        // NOTE: Part2 Checks
        private static bool IsNice(string line)
        {
            if (HasNonOverlappingPairs(line) && HasSplitRepeatPair(line)) return true;

            return false;
        }

        private static bool HasSplitRepeatPair(string line)
        {
            for (int i = 0; i < line.Length -2; i++)
            {
                if(line[i] == line[i+2]) return true;
            }

            return false;
        }

        private static bool HasNonOverlappingPairs(string line)
        {
            var pairs = new List<(string pair, int index)>(); // pair, string index

            var lineIdx = 0;

            for (int i = 0; i < line.Length-1; i++)
            {
                pairs.Add((line.Substring(i, 2), i));
            }

            var doublePairs = pairs
                .GroupBy(p => p.pair)
                .Where(p => p.Count() > 1)
                .OrderBy(p => p.Count());

            if (!doublePairs.Any()) return false;

            foreach (var doublePair in doublePairs)
            {
                var lastPairIdx = int.MinValue;
                foreach (var pairItem in doublePair)
                {
                    if (pairItem.index <= lastPairIdx + 1) return false;

                    lastPairIdx = pairItem.index;
                }
            }

            return true;
        }

        // NOTE: Part1 Checks
        private static bool IsNaughty(string line)
        {
            if (CountVowels(line) < 3) return true;
            if (!ContainsASequentialDuplicate(line)) return true;
            if (ContainsNaughtyPairs(line)) return true;

            return false;
        }

        private static List<string> NaughtyPairs = new List<string>{"ab", "cd", "pq", "xy"};
        private static bool ContainsNaughtyPairs(string line)
        {
            return NaughtyPairs.Any(line.Contains);
        }

        private static bool ContainsASequentialDuplicate(string line)
        {
            char lastChar = '\0';

            foreach (var c in line)
            {
                if (c == lastChar) return true;
                lastChar = c;
            }

            return false;
        }

        private const string vowels = "aeiou";

        private static int CountVowels(string input)
        {
            return vowels.Sum(v => CountLetter(input, v));
        }

        private static int CountLetter(string input, char letter)
        {
            return input.Count(c => c == letter);
        }
    }
}
