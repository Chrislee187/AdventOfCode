using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace AoC2015_12
{
    class Program
    {
        static void Main()
        {
            var data = File.ReadAllText("data.txt");

            using (JsonDocument document = JsonDocument.Parse(data))
            {
                var aoC201512 = new AoC2015Day12(document);
                var part1 = aoC201512.SumAllValues(false);
                var part2 = aoC201512.SumAllValues(true);
                Console.WriteLine($"AoC2015_12 Sum Part 1: {part1}");
                Console.WriteLine($"AoC2015_12 Sum Part 2: {part2}");
            }

            // var (sum, count) = SumWithRegex(data);
            // Console.WriteLine($"Regex Sum: {sum}"); // 191164
        }

        // Quick, inflexible solution to part 1
        static (int,int) SumWithRegex(string data)
        {
            var pattern = @"-?\d+";

            var regex = new Regex(pattern);

            var match = regex.Matches(data);

            var sum = match.Select(m => int.Parse(m.Value)).Sum();
            return (sum, match.Count);


        }
    }
}
