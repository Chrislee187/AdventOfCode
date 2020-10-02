namespace AoC2015_11
{
    public static class StringMathExtensions
    {
        public static string Increment(this string input)
        {
            char IncrementChar(char c) => c == 'z' ? 'a' : ++c;

            var charToIncrement = input.Length - 1;
            var array = input.ToCharArray();
            while (true)
            {
                var inc = IncrementChar(array[charToIncrement]);

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
}