using System.ComponentModel;
using System.Reflection.PortableExecutable;

namespace Day_01
{
    internal class Program
    {
        private static string puzzleInput =
            "R4, R1, L2, R1, L1, L1, R1, L5, R1, R5, L2, R3, L3, L4, R4, R4, R3, L5, L1, R5, R3, L4, R1, R5, L1, R3, L2, R3, R1, L4, L1, R1, L1, L5, R1, L2, R2, L3, L5, R1, R5, L1, R188, L3, R2, R52, R5, L3, R79, L1, R5, R186, R2, R1, L3, L5, L2, R2, R4, R5, R5, L5, L4, R5, R3, L4, R4, L4, L4, R5, L4, L3, L1, L4, R1, R2, L5, R3, L4, R3, L3, L5, R1, R1, L3, R2, R1, R2, R2, L4, R5, R1, R3, R2, L2, L2, L1, R2, L1, L3, R5, R1, R4, R5, R2, R2, R4, R4, R1, L3, R4, L2, R2, R1, R3, L5, R5, R2, R5, L1, R2, R4, L1, R5, L3, L3, R1, L4, R2, L2, R1, L1, R4, R3, L2, L3, R3, L2, R1, L4, R5, L1, R5, L2, L1, L5, L2, L5, L2, L4, L2, R3";

        static void Main(string[] args)
        {
            var inputs = puzzleInput.Split(',', StringSplitOptions.TrimEntries);

            var loc = new AoC2016_Day1();

            foreach (var x in inputs)
            {
                Console.WriteLine($"Move: {x} = {loc.X}, {loc.Y} -> {loc.Distance}");

                loc.Move(x);
            }

            Console.WriteLine($"Part 1 Distance: {loc.X}, {loc.Y} -> {loc.Distance} = (expected) 161");

            Console.WriteLine($"Part 2 Distance: {loc.FirstDupeLocation!.X}, {loc.FirstDupeLocation.Y} -> {loc.FirstDupeLocation.Distance}  = (expected) 110");
        }
    }
}