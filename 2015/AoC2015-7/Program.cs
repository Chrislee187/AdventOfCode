using System;
using System.Collections.Generic;
using System.IO;

namespace AoC2015_7
{
    // I suspect there is a better way than this reverse engineering approach
    class Program
    {
        static void Main()
        {
            var data = File.ReadLines("data.txt");

            var connections = new List<Connection>();
            foreach (var line in data)
            {
                connections.Add(Connection.Parse(line));
            }

            var circuit = new Circuit(connections);

            var testWire = "a";
            Console.WriteLine($"Result for wire {testWire}: {circuit.GetSignal(testWire)}"); // Result: 16076
        }
    }
}