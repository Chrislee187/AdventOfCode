using System;
using System.Collections.Generic;
using System.IO;

namespace AoC2015_3
{
    class Program
    {
        static void Main()
        {
            var data = File.ReadAllText("data.txt");

            var presentLocations = new Dictionary<(int,int), int>();

            (int x, int y) santaLoc = (0,0);
            (int x, int y) roboLoc = (0,0);

            presentLocations.Add(santaLoc, 2);

            bool robosTurn = false;
            foreach (var direction in data)
            {
                var trans = DirectionToTransformation(direction);

                if (!robosTurn)
                {
                    santaLoc.x += trans.x;
                    santaLoc.y += trans.y;

                    AddPresent(presentLocations, santaLoc);
                }
                else
                {
                    roboLoc.x += trans.x;
                    roboLoc.y += trans.y;

                    AddPresent(presentLocations, roboLoc);

                }

                robosTurn = !robosTurn;

            }
             Console.WriteLine($"# Locations with >= 1 presents: {presentLocations.Count }");

        }

        private static void AddPresent(Dictionary<(int, int), int> locations, (int x, int y) currentLoc)
        {
            if (!locations.ContainsKey(currentLoc))
            {
                locations.Add(currentLoc, 1);
            }
            else
            {
                locations[currentLoc] += 1;
            }
        }

        static (int x, int y) DirectionToTransformation(char direction)
        {
            switch (direction)
            {
                case '^':
                    return (0, 1);
                case '>':
                    return (1, 0);
                case 'v':
                    return (0, -1);
                case '<':
                    return (-1, 0);
                default:
                    throw new InvalidDataException($"Invalid direction '{direction}'");
            }
        }
    }
}
