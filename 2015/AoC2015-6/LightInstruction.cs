using System.IO;
using System.Text.RegularExpressions;

namespace AoC2015_6
{
    public class LightInstruction
    {
        public Mode Mode { get; set; }
        public Point From { get; set; }
        public Point To { get; set; }

        public static LightInstruction Parse(string input)
        {
            var regex = new Regex(@"^(?<mode>turn off|turn on|toggle) (?<fromX>\d{1,3}),(?<fromY>\d{1,3}) through (?<toX>\d{1,3}),(?<toY>\d{1,3})");// (?<fromX>\d{3}),(?<fromY>\d{3}) through (?<toX>\d{3}),(?<toY>\d{3})");
            
            var match = regex.Match(input);

            if (match.Success)
            {
                return new LightInstruction
                {
                    Mode = ParseMode(match.Groups["mode"]
                        .Value),
                    From = new Point(int.Parse(match.Groups["fromX"]
                        .Value), int.Parse(match.Groups["fromY"]
                        .Value)),
                    To = new Point(int.Parse(match.Groups["toX"]
                        .Value), int.Parse(match.Groups["toY"]
                        .Value)),
                };
            }

            return new LightInstruction();
        }

        public bool Contains(Light l)
        {
            return l.X >= From.X && l.X <= To.X 
                    && l.Y >= From.Y && l.Y <= To.Y;
        }
        private static Mode ParseMode(string mode)
        {
            switch (mode)
            {
                case "turn on":
                    return Mode.On;
                case "turn off":
                    return Mode.Off;
                case "toggle":
                    return Mode.Toggle;
                default:
                    throw new InvalidDataException($"Invalid mode: {mode}");
            }

        }
    }
}