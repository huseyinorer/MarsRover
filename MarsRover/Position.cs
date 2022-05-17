namespace MarsRover
{
    public interface IPosition
    {
        int X { get; set; }
        int Y { get; set; }
    }
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
