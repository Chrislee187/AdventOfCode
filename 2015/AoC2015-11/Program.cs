using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace AoC2015_11
{
    class Program
    {
        private static PasswordValidator _chk = new PasswordValidator();

        static void Main(string[] args)
        {
            var input = "vzbxkghb";

            input = GenerateNextPassword(input);
            Console.WriteLine($"{input} is next valid password");
            Debug.Assert(input == "vzbxxyzz", "Part 1 failed");

            input = GenerateNextPassword(input.Increment());
            Console.WriteLine($"{input} is next valid password");
            Debug.Assert(input == "vzcaabcc", "Part 1 failed");
        }


        public static string GenerateNextPassword(string input)
        {
            var validate = _chk.Validate(input);
            while (!validate)
            {
                input = input.Increment();
                validate = _chk.Validate(input);
            }


            return input;
        }
    }
}
