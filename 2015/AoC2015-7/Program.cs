using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2015_7
{
    // I suspect there is a better way than this reverse engineering approach
    class Program
    {
        static void Main()
        {
            var connections = GetConnections();

            var circuit = new Circuit(connections);

            var testWire = "a";
            var wireA = circuit.GetSignal(testWire);
            Console.WriteLine($"Part 1: Result for wire {testWire}: {wireA}"); // Result: 16076

            // Reset the connections, could instead do a clear off all the individual connection values;
            connections = GetConnections();

            // Override b to the value of wireA
            var connection = connections.Single(c => c.WireId == "b");
            connection.OverrideValue(wireA);
            
            circuit = new Circuit(connections);

            Console.WriteLine($"Part 2: Result for wire {testWire}: {circuit.GetSignal(testWire)}"); // Result: 2797
        }

        private static List<Connection> GetConnections()
        {
            var data = File.ReadLines("data.txt");

            var connections = new List<Connection>();
            foreach (var line in data)
            {
                connections.Add(Connection.Parse(line));
            }

            return connections;
        }
    }
}