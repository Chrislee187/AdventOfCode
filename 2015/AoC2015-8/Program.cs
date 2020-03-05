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
            foreach (var line in data)
            {
                totalPhysical += line.Length;
                var parsed = ParseEscapes(line);
                totalParsed += parsed.Length;

                // Console.WriteLine($"{line} = {parsed}");
            }

            Console.WriteLine($"Physical {totalPhysical} ");
            Console.WriteLine($"Parsed {totalParsed}");
            Console.WriteLine($"Diff {totalPhysical - totalParsed} - Part 1 should equal 1342");
        }

        private static string ParseEscapes(string line)
        {
            var sb = new StringBuilder();
            var trimmed = Unquote(line);
            
            for (int i = 0; i < trimmed.Length; i++)
            {
                var c = trimmed[i];
                if (IsEscaped(c))
                {
                    var c2 = trimmed[++i];
                    sb.Append(IsAsciiCode(c2)
                        ? GetHexChar(trimmed, ref i)
                        : c2.ToString());
                }
                else
                {
                    if(!char.IsWhiteSpace(c)) sb.Append(c);
                }

                if (i >= trimmed.Length) break;
            }

            return sb.ToString();

            static string Unquote(string line) => 
                new string(line.Skip(1).Take(line.Length - 2).ToArray());

            static bool IsEscaped(char c) => 
                c == '\\';

            static bool IsAsciiCode(char c2) => 
                c2 == 'x';

            static string GetHexChar(string s, ref int i) => 
                char.ConvertFromUtf32(int.Parse(
                    new string(new[] { s[++i], s[++i] }),
                    NumberStyles.AllowHexSpecifier));
        }
    }
}
