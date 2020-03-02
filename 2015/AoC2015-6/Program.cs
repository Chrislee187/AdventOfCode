using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;


namespace AoC2015_6
{
    class Program
    {
        static void Main(string[] args)
        {

            var data = File.ReadLines("data.txt");

            var grid = new LightGrid();
            grid.Parse(data);
            Console.WriteLine($"Brightness: {grid.Brightness()}");

            var grid2 = new LightGrid();
            grid2.ParseSlowlyUsingLinq(data);
            Console.WriteLine($"Brightness: {grid.Brightness()}");

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
        static void Test2()
        {
            var grid = new LightGrid();

            foreach (var light in grid)
            {
                Console.WriteLine($"{light.X}, {light.Y}, {light.Brightness}");
            }


        }
    }

    public class LightGrid : IEnumerable<Light>
    {
        public int[,] Lights = new int[1000, 1000];

        public void Parse(IEnumerable<string> commands)
        {
            var count = 0;
            foreach (var line in commands)
            {
                var lightInstruction = LightInstruction.Parse(line);

                for (int y = lightInstruction.From.Y; y <= lightInstruction.To.Y; y++)
                {
                    for (int x = lightInstruction.From.X; x <= lightInstruction.To.X; x++)
                    {
                        ChangeLight(x, y, lightInstruction.Mode);
                        count++;
                    }
                }
            }
        }
        public void ParseSlowlyUsingLinq(IEnumerable<string> commands)
        {
            foreach (var line in commands)
            {
                var lightInstruction = LightInstruction.Parse(line);
            
                this.Where(lightInstruction.Contains)
                    .ToList()
                    .ForEach(light => light.ChangeLight(lightInstruction.Mode));

                // NOTE: You can parallize but its slower than the ToList() version
                // .AsParallel()
                // .ForAll(l => l.ChangeLight(lightInstruction.Mode));
            }
        }
        public int Brightness() => this.Sum(l => l.Brightness);

        private void ChangeLight(int x, int y, Mode mode)
        {
            if (mode == Mode.On)
                Lights[x, y] += 1;
            else if (mode == Mode.Off)
                Lights[x, y] -= 1;
            else
            {
                Lights[x, y] += 2;
            }

            if (Lights[x, y] < 0) Lights[x, y] = 0;
        }

        public IEnumerator<Light> GetEnumerator()
        {
            return new LightEnumerator(Lights);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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
