namespace MarsRover
{
    public interface IPlateau
    {
        Position PlateauPosition { get; }
    }
    public class Plateau : IPlateau
    {
        public Position PlateauPosition { get; private set; }

        public Plateau(Position position)
        {
            PlateauPosition = position;
        }
    }
}
