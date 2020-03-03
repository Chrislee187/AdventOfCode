using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AoC2015_7.Tokens;

namespace AoC2015_7
{
    public class Connection
    {
        private int? _value;
        private readonly IList<Token> _parsedTokens;
        public string Line { get; }
        public string WireId { get; }

        public int Value(Dictionary<string, Connection> connections)
        {
            if (!_value.HasValue)
            {
                _value = GetSignal(connections);
            }
                
            return _value.Value;
        }

        public Connection(string line, List<Token> parsedTokens, string wireId)
        {
            Line = line;
            _parsedTokens = parsedTokens;
            WireId = wireId;
        }

        public static Connection Parse(string line)
        {
            var tokens= line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var parsedTokens = new List<Token>();

            foreach (var token in tokens)
            {
                if (ParseToken(parsedTokens, token))
                {
                    break;
                }
            }

            return new Connection(line, parsedTokens, tokens.Last());
        }

        static bool ParseToken(IList<Token> tokens, string token)
        {
            switch (token)
            {
                case "->":
                    Console.WriteLine($"Assignment: {token}");
                    return true;
                case { } when int.TryParse(token, out var value):
                    Console.WriteLine($"Value token: {value}");
                    tokens.Add(new IntegerToken(value));
                    break;
                case { } s when s.Equals(s.ToLower()):
                    Console.WriteLine($"Wire WireId: {token}");
                    tokens.Add(new WireIdToken(token));
                    break;
                case { } s when s.Equals(s.ToUpper()):
                    Console.WriteLine($"Operator: {token}");
                    tokens.Add(new OperatorToken(token));
                    break;

            }

            return false;
        }
        private int GetSignal(Dictionary<string, Connection> connections)
        {
            Console.WriteLine($"{Line}");
            var valueTokens = _parsedTokens.OfType<ValueToken>().ToArray();

            var opToken = _parsedTokens.OfType<OperatorToken>()
                .SingleOrDefault();

            int result;
            if (opToken == null)
            {
                result = valueTokens[0].Value(connections);
            }
            else
            {
                result = ResolveExpression(connections, opToken, valueTokens);
            }
            
            Console.WriteLine($"  {WireId} = {result}");
            return result;
        }

        private static int ResolveExpression(Dictionary<string, Connection> connections, OperatorToken opToken, ValueToken[] valueTokens)
        {
            int v1, v2;
            int result;
            switch (opToken.Operation)
            {
                case "NOT":
                    v1 = valueTokens[0].Value(connections);
                    result = ~v1;
                    break;
                case "AND":
                    v1 = valueTokens[0].Value(connections);
                    v2 = valueTokens[1].Value(connections);
                    result = v1 & v2;
                    break;
                case "OR":
                    v1 = valueTokens[0].Value(connections);
                    v2 = valueTokens[1].Value(connections);
                    result = v1 | v2;
                    break;
                case "LSHIFT":
                    v1 = valueTokens[0].Value(connections);
                    v2 = valueTokens[1].Value(connections);
                    result = v1 << v2;
                    break;
                case "RSHIFT":
                    v1 = valueTokens[0].Value(connections);
                    v2 = valueTokens[1].Value(connections);
                    result = v1 >> v2;
                    break;
                default:
                    throw new InvalidDataException($"Unsupported optoken {opToken.Operation}");
            }

            return result;
        }

        public void OverrideValue(int i)
        {
            _value = i;
        }
    }
}