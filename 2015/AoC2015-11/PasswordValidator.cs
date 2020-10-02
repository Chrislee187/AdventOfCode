using System.Linq;

namespace AoC2015_11
{
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