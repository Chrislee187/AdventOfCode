using System;
using System.Diagnostics;
using System.Text;

namespace AoC2015_10
{
    internal class LookNSay
    {
        private double ConwaysConstant = 1.3035772699d;

        private string LookSay(string input)
        {
            var currentDigit = '\0';
            var currentCount = 0;

            // NOTE: 40+ iterations, started to slowdown with normal string concatenation so use SB, this starts to slow down after 60ish iterations
            // There is probably a better way, https://www.youtube.com/watch?v=ea7lJkEhytA might make more sense another time!
            var result = new StringBuilder(input.Length * 2); 
            foreach (var c in input)
            {
                if (currentDigit == c)
                {
                    currentCount++;
                }
                else
                {
                    if (currentDigit != '\0')
                    {
                        result.Append($"{currentCount}{currentDigit}");
                    }
                    currentDigit = c;
                    currentCount = 1;
                }
            }

            if (currentCount > 0)
            {
                result.Append($"{currentCount}{currentDigit}");
            }
            return result.ToString();
        }

        public void Say(string input, int iterations)
        {
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < iterations; i++)
            {
                var result = this.LookSay(input);

                Console.WriteLine($"#{i:00} ({result.Length}) in {sw.Elapsed}");
                if (result.Length <= 120)
                {
                    var lpad = (120 - result.Length) / 2;

                    Console.WriteLine($"{result.PadLeft(lpad + result.Length)}");
                }


                if (i == 39)
                {
                    Console.WriteLine($"    40 iterations Result length = {result.Length}");
                    Debug.Assert(result.Length == 492982, "Part 1 failed");
                    Console.WriteLine("    Part 1 passed");
                }

                if (i == 49)
                {
                    Console.WriteLine($"    50 iterations ({sw.Elapsed}) Result length = {result.Length}");
                    Debug.Assert(result.Length == 6989950, "Part 2 failed");
                    Console.WriteLine("    Part 2 passed");
                }


                input = result;
            }
        }

    }
}