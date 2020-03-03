using System;
using System.IO;
using System.Linq;

namespace AoC2015_1
{
    class Program
    {
        static void Main()
        {
            var data = File.ReadAllText("data.txt").ToList();
            var index = 0;
            var sum = 0;
            var firstBasementIndex = 0;

            data.ForEach(d =>
            {
                index++;
                var move = d == '(' ? 1 : d == ')' ? -1 : 0;

                if (move == 0) throw new InvalidDataException($"Unexpected char '{d}'");
                sum += move;

                if (sum == -1 && firstBasementIndex == 0)
                {
                    firstBasementIndex = index;
                }
            });

            Console.WriteLine($"Final Floor: {sum}");
            Console.WriteLine($"First Basement Index: {firstBasementIndex}");
        }
    }
}
