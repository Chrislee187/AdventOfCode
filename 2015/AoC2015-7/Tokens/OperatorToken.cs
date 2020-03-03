namespace AoC2015_7.Tokens
{
    public class OperatorToken : Token
    {
        public string Operation { get; }

        public OperatorToken(string operation) => Operation = operation;
    }
}
