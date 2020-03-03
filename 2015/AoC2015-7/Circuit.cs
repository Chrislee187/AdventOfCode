using System.Collections.Generic;
using System.Linq;

namespace AoC2015_7
{
    internal class Circuit
    {
        private readonly Dictionary<string, Connection> _connections;

        public Circuit(List<Connection> connections) 
            => _connections = connections
                .ToDictionary(k => k.WireId, v => v);

        public int GetSignal(string testWire) 
            => _connections[testWire].Value(_connections);
    }
}