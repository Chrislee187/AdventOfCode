using System.Collections.Generic;

namespace AoC2015_7.Tokens
{
    public class IntegerToken : ValueToken 
    {
        private readonly int _value;

        public override int Value(Dictionary<string, Connection> c) => _value;

        public IntegerToken(in int value) => _value = value;
    }
}