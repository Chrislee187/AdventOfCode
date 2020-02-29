using System;
using System.IO;
using System.Linq;

namespace AoC2015_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = File.ReadLines("data.txt");
            var totalPaperArea = 0;
            var totalRibbonLength = 0;
            foreach (var line in data)
            {
                var dimensions
                    = line
                        .Split('x', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .OrderBy(d => d)
                        .ToArray();

                totalPaperArea += WrappingPaperArea(dimensions[0], dimensions[1], dimensions[2]);
                totalRibbonLength += RibbonLength(dimensions[0], dimensions[1], dimensions[2]);
            }

            Console.WriteLine($"Total Paper Area: {totalPaperArea}");
            Console.WriteLine($"Total Ribbon Length: {totalRibbonLength}");
        }

        private static int WrappingPaperArea(int length, int width, int height)
            => (3 * length * width)
               + (2 * width * height)
               + (2 * height * length);

        private static int RibbonLength(int length, int width, int height)
            => 2 * length + 2 * width
                + length * width * height;
    }
}
