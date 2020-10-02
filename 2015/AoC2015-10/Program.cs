using System;
using System.Diagnostics;

namespace AoC2015_10
{
    class Program
    {
        static void Main(string[] args)
        {
            var lookNSay = new LookNSay();

            // Console.Write("Source Input: ");
            // var input = Console.ReadLine();
            // Console.Write("iterations: ");
            // var iterations = int.Parse(Console.ReadLine());

            var input = "1321131112";
            var iterations = 40;
            for (int i = 0; i < iterations; i++)
            {
                var result = lookNSay.Do(input);

                Console.WriteLine($"#{i:00} ({result.Length})");
                Debug.Assert(result.Length == 492982, "Part 1 failed");

                input = result;

            }


        }
    }

    internal class LookNSay
    {
        public string Do(string input)
        {
            var currentDigit = '\0';
            var currentCount = 0;
            var result = "";
            foreach (var c in input)
            {
                if (currentDigit == c)
                {
                    currentCount++;
                }
                if (currentDigit != c)
                {
                    if (currentDigit != '\0')
                    {
                        result += $"{currentCount}{currentDigit}";
                    }
                    currentDigit = c;
                    currentCount = 1;
                }
            }

            if (currentCount > 0)
            {
                result += $"{currentCount}{currentDigit}";
            }
            return result;
        }
    }
}
