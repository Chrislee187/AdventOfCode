using System;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;

namespace AoC2015_11
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = "vzbxkghb";

            var chk = new PasswordValidator();

            var validate = chk.Validate(input);
            while (!validate)
            {

                input = Increment(input);
                validate = chk.Validate(input);
            }

            Console.WriteLine($"{input} is next valid password");

            Debug.Assert(input == "vzbxxyzz", "Part 1 failed");
        }

        private static string Increment(string input)
        {

            var charToIncrement = input.Length - 1;
            var array = input.ToCharArray();
            while (true)
            {
                char c = array[charToIncrement];
                var inc = c == 'z' ? 'a' : ++c;

                array[charToIncrement] = inc;

                if (inc == 'a')
                {
                    charToIncrement--;
                    if (charToIncrement == -1)
                    {
                        return "a" + new string(array);
                    }
                }
                else
                {
                    return new string(array);
                }
            }
        }
    }

    internal class PasswordValidator
    {
        public bool Validate(string input)
        {
            var invalidChars = new[] {'i', 'o', 'u'};

            var hasInvalidChars = input.Any(c => invalidChars.Contains(c));

            return !hasInvalidChars && HasPairs(input) && HasStraight(input);
        }

        private bool HasStraight(string input)
        {
            
            for (int i = 0; i < input.Length - 2; i++)
            {
                if (input[i+1] == input[i] + 1 
                    && input[i+2] == input[i] + 2)
                {
                    return true;
                }
            }

            return false;
        }

        private bool HasPairs(string input)
        {
            int pairCount = 0;
            char firstPairChar = '\0';

            for (int i = 0; i < input.Length -1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    if (pairCount == 0)
                    {
                        firstPairChar = input[i];
                        pairCount++;
                        i++;
                    }
                    else if(firstPairChar != input[i])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
