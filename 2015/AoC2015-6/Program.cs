using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.CompilerServices;

namespace AoC2015_6
{
    class Program
    {
        static void Main(string[] args)
        {
            // Test();

            var grid = new LightGrid();
            var data = File.ReadLines("data.txt");

            grid.Parse(data);

            Console.WriteLine($"{grid.Count(true)} lights are on");
            
        }

        static void Test()
        {
            var test = "turn off 660,55 through 986,197";

            var range = LightInstruction.Parse(test);

            Debug.Assert(range.Mode == Mode.Off);
            Debug.Assert(range.From.X == 660);
            Debug.Assert(range.From.Y == 55);
            Debug.Assert(range.To.X == 986);
            Debug.Assert(range.To.Y == 197);


        }
    }

    public class LightGrid
    {
        public bool[,] Lights = new bool[1000, 1000];

        public void Parse(IEnumerable<string> commands)
        {
            foreach (var line in commands)
            {
                var lightInstruction = LightInstruction.Parse(line);
                for (int y = lightInstruction.From.Y; y <= lightInstruction.To.Y; y++)
                {
                    for (int x = lightInstruction.From.X; x <= lightInstruction.To.X; x++)
                    {
                        ChangeLight(x, y, lightInstruction.Mode);
                    }
                }
            }
        }

        public int Count(bool onOff)
        {
            var count = 0;
            for (var y = 0; y < 1000; y++)
            {
                for (var x = 0; x < 1000; x++)
                {
                    if (Lights[x, y] == onOff) count++;
                }
            }

            return count;
        }

        private void ChangeLight(int x, int y, Mode mode)
        {
            if (mode == Mode.On)
                Lights[x, y] = true;
            else if (mode == Mode.Off)
                Lights[x, y] = false;
            else
            {
                Lights[x, y] = !Lights[x, y];
            }
        }
    }
    public class LightInstruction
    {
        public Mode Mode { get; set; }
        public Point From { get; set; }
        public Point To { get; set; }

        public static LightInstruction Parse(string input)
        {
            var regex = new Regex(@"^(?<mode>turn off|turn on|toggle) (?<fromX>\d{1,3}),(?<fromY>\d{1,3}) through (?<toX>\d{1,3}),(?<toY>\d{1,3})");// (?<fromX>\d{3}),(?<fromY>\d{3}) through (?<toX>\d{3}),(?<toY>\d{3})");
            
            var match = regex.Match(input);

            if (match.Success)
            {
                return new LightInstruction
                {
                    Mode = ParseMode(match.Groups["mode"]
                        .Value),
                    From = new Point(int.Parse(match.Groups["fromX"]
                        .Value), int.Parse(match.Groups["fromY"]
                        .Value)),
                    To = new Point(int.Parse(match.Groups["toX"]
                        .Value), int.Parse(match.Groups["toY"]
                        .Value)),
                };
            }

            return new LightInstruction();
        }

        private static Mode ParseMode(string mode)
        {
            switch (mode)
            {
                case "turn on":
                    return Mode.On;
                case "turn off":
                    return Mode.Off;
                case "toggle":
                    return Mode.Toggle;
                default:
                    throw new InvalidDataException($"Invalid mode: {mode}");
            }

        }
    }

    public enum Mode
    {
        Off, On, Toggle
    }

    public struct Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get;  }
        public int Y { get;  }
    }
}
