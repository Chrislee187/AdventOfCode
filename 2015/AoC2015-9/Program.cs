using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2015_9
{
    class Program
    {

        static void Main(string[] args)
        {
            var data = File.ReadLines("data.txt");

            var network = Network.Parse(data);

            var shortest = network.FindLoop(true);
            var longest = network.FindLoop(false);

            DumpRoute(shortest);
            DumpRoute(longest);
        }

        private static void DumpRoute(IEnumerable<RouteStep> route)
        {
            var routeSteps = route as RouteStep[] ?? route.ToArray();
            foreach (var step in routeSteps)
            {
                Console.Write($"{step.From.Substring(0, 2)}:{step.To.Substring(0, 2)}({step.Distance}) ");
            }
            Console.WriteLine($"={routeSteps.Sum(rd => rd.Distance)}");
        }


    }

    public static class Extensions
    {

    }
}
