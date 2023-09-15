using Day_01;
using Shouldly;

namespace AoC2016.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Should_default_location_to_zero_zero()
        {
            var loc = new AoC2016_Day1();

            loc.X.ShouldBe(0);
            loc.Y.ShouldBe(0);
        }

        [Fact]
        public void Should_move_in_cardinal_directions_clockwise()
        {
            var loc = new AoC2016_Day1();
            loc.Move("R1");
            loc.Move("R1");
            loc.Move("R1");
            loc.Move("R1");

            loc.X.ShouldBe(0);
            loc.Y.ShouldBe(0);
        }

        [Fact]
        public void Should_move_in_cardinal_directions_anti_clockwise()
        {
            var loc = new AoC2016_Day1();
            loc.Move("L1");
            loc.Move("L1");
            loc.Move("L1");
            loc.Move("L1");

            loc.X.ShouldBe(0);
            loc.Y.ShouldBe(0);
        }
        [Fact]
        public void Should_default_heading_to_north()
        {
            var loc = new AoC2016_Day1();

            loc.Heading.ShouldBe(Bearing.North);
        }

        [Fact]
        public void Should_correctly_resolve_right_rotations()
        {
            var loc = new AoC2016_Day1();
            loc.Move("R");
            loc.Heading.ShouldBe(Bearing.East);

            loc.Move("R");
            loc.Heading.ShouldBe(Bearing.South);

            loc.Move("R");
            loc.Heading.ShouldBe(Bearing.West);

            loc.Move("R");
            loc.Heading.ShouldBe(Bearing.North);

            loc.Move("R");
            loc.Heading.ShouldBe(Bearing.East);
        }


        [Fact]
        public void Should_correctly_resolve_left_rotations()
        {
            var loc = new AoC2016_Day1();
            loc.Move("L");
            loc.Heading.ShouldBe(Bearing.West);

            loc.Move("L");
            loc.Heading.ShouldBe(Bearing.South);

            loc.Move("L");
            loc.Heading.ShouldBe(Bearing.East);

            loc.Move("L");
            loc.Heading.ShouldBe(Bearing.North);

            loc.Move("L");
            loc.Heading.ShouldBe(Bearing.West);
        }

        [Fact]
        public void Should_correctly_resolve_movement()
        {
            var loc = new AoC2016_Day1();
            loc.Move("L2");
            loc.X.ShouldBe(-2);
        }

        [Theory]
        [InlineData(5, 5, 10)]
        [InlineData(5, -5, 10)]
        [InlineData(-5, 5, 10)]
        [InlineData(-5, -5, 10)]
        public void Should_correctly_calc_distance_by_adding_x_and_y_values(int x, int y, int expectedDistance)
        {
            new AoC2016_Day1(x,y).Distance.ShouldBe(expectedDistance);
        }

    }
}