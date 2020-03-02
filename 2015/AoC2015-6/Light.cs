namespace AoC2015_6
{
    public class Light
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Brightness { get; set; }

        public void ChangeLight(Mode mode)
        {
            if (mode == Mode.On)
                Brightness += 1;
            else if (mode == Mode.Off)
                Brightness -= 1;
            else
            {
                Brightness += 2;
            }

            if (Brightness < 0) Brightness = 0;
        }
    }
}