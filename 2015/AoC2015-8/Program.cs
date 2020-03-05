using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC2015_8
{
    class Program
    {
        static void Main()
        {
            var data = File.ReadLines("data.txt");

            var totalPhysical = 0;
            var totalParsed = 0;
            var totalEscaped = 0;
            foreach (var line in data)
            {
                totalPhysical += line.Length;

                var parsed = ParseEscapes(line);
                totalParsed += parsed.Length;
                
                var escaped = Escape(line);
                totalEscaped += escaped.Length;
                // Console.WriteLine($"{line} = {parsed}");
                Console.WriteLine($"{line} = {escaped}");
            }

            Console.WriteLine($"Physical {totalPhysical} ");
            Console.WriteLine($"Parsed {totalParsed}");
            Console.WriteLine($"Escaped {totalEscaped}");
            Console.WriteLine($"Parsed Diff {totalPhysical - totalParsed} - Part 1 should equal 1342");
            Console.WriteLine($"Escaped Diff {totalEscaped - totalPhysical} - Part 2 should equal 2074");
        }

        private static string Escape(string line)
        {
            string Quote(string stringBuilder) => 
                @"""" + stringBuilder + @"""";

            var sb = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                var c = line[i];

                if(char.IsWhiteSpace(c)) continue;

                _ = c switch
                {
                    '\\' => sb.Append(@"\\"),
                    '"' => sb.Append(new[] { '\\', '"' }),
                    _ => sb.Append(c),
                };
            }

            return Quote(sb.ToString());
        }

        private static string ParseEscapes(string line)
        {
            var sb = new StringBuilder();
            var trimmed = Unquote(line);
            
            for (int i = 0; i < trimmed.Length; i++)
            {
                var c = trimmed[i];

                if (char.IsWhiteSpace(c)) continue;
                
                if (IsEscaped(c))
                {
                    var c2 = trimmed[++i];
                    sb.Append(IsHexCode(c2)
                        ? GetHexChar(trimmed, ref i)
                        : c2.ToString());
                }
                else
                {
                    sb.Append(c);
                }

                if (i >= trimmed.Length) break;
            }

            return sb.ToString();

            static bool IsEscaped(char c) => 
                c == '\\';

            static bool IsHexCode(char c2) => 
                c2 == 'x';

            static string GetHexChar(string s, ref int i) => 
                char.ConvertFromUtf32(int.Parse(
                    new string(new[] { s[++i], s[++i] }),
                    NumberStyles.AllowHexSpecifier));

            static string Unquote(string line)
                => new string(line.Skip(1)
                    .Take(line.Length - 2)
                    .ToArray());
        }
    }
}
