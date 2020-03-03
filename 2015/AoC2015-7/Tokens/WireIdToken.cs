using System.Collections.Generic;

namespace AoC2015_7.Tokens
{
    public class WireIdToken : ValueToken
    {
        public string WireId { get; }

        public WireIdToken(string wireId) => WireId = wireId;

        public override int Value(Dictionary<string, Connection> c) => c[WireId].Value(c);
    }
}