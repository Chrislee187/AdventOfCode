using System.Collections.Generic;

namespace AoC2015_7.Tokens
{
    public abstract class ValueToken : Token
    {
        public abstract int Value(Dictionary<string, Connection> c);
    }
}