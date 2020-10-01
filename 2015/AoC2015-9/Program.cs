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
            foreach (var routeData in route)
            {
                Console.Write($"{routeData.From.Substring(0, 2)}:{routeData.To.Substring(0, 2)}({routeData.Distance}) ");
            }
            Console.WriteLine($"={route.Sum(rd => rd.Distance)}");
        }


    }

    public static class Extensions
    {

    }
}
