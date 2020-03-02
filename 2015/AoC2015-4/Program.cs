using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AoC2015_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // var testInput = "abcdef609043";
            var testInput = "ckczppom";

            var index = 1;

            var numberOfZeroesToMatch = 10;
            var matchValue = new string('0', numberOfZeroesToMatch);
            using (MD5 md5 = MD5.Create())
            {
                while (true)
                {
                    var hex = Hash(md5, $"{testInput}{index}");

                    var matchPrefix = hex[..numberOfZeroesToMatch];

                    if (matchPrefix == matchValue)
                    {
                        Console.WriteLine($"First matched five zeroes using: {index}");
                        break;
                    }

                    index++;

                    if (index >= int.MaxValue)
                    {
                        Console.WriteLine("No match found");
                        break;
                    }
                }

            }
        }

        private static string Hash(MD5 md5, string testInput)
        {
            var hash = md5
                .ComputeHash(Encoding.UTF8.GetBytes(testInput));
            // .Select(v => (int) v);

            var sb = new StringBuilder();

            var hex = hash
                .Aggregate("", (s, v) => s += v.ToString("X2"));
            return hex;
        }
    }
}
