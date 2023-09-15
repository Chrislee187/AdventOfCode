using System.ComponentModel;
using System.IO;

namespace Day_01;

public class AoC2016_Day1
{
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;
    public Bearing Heading { get; set; } = Bearing.North;

    public int Distance => Math.Abs(X) + Math.Abs(Y);

    private readonly HashSet<(int X, int Y)> _visited = new();
    public AoC2016_Day1? FirstDupeLocation;

    public AoC2016_Day1()
    {
    }

    public AoC2016_Day1(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void Move(string s)
    {
        SetHeading(s);

        if (s.Length > 1)
        {
            var move = s[1..];
            MoveToNextLocation(move);
        }
    }

    private void MoveToNextLocation(string move)
    {
        var distance = int.Parse(move);

        Action moveFunc = Heading switch
        {
            Bearing.North => () => Y++,
            Bearing.East => () => X++,
            Bearing.South => () => Y--,
            Bearing.West => () => X--,
            _ => throw new ArgumentOutOfRangeException()
        };

        for (var i = 0; i < distance; i++)
        {
            moveFunc();

            if (_visited.TryGetValue((X,Y), out _) && FirstDupeLocation is null)
            {
                FirstDupeLocation = new AoC2016_Day1(X, Y);
            }
            else
            {
                _visited.Add((X, Y));
            }
        }
    }

    private void SetHeading(string s)
    {
        switch (char.ToUpperInvariant(s[0]))
        {
            case 'R':
                Heading++;
                break;
            case 'L':
                Heading--;
                break;
        }

        Heading = (int)Heading switch
        {
            4 => Bearing.North,
            -1 => Bearing.West,
            _ => Heading
        };
    }
}