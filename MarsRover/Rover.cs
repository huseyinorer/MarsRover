
namespace MarsRover
{
    public enum Directions { N = 1, E, S, W }
    public interface IRover
    {
        IPlateau Plateau { get; set; }
        Directions RoverDirection { get; set; }
        IPosition RoverPosition { get; set; }

        void Process(string commands);
        string ToString();
    }
    public class Rover : IRover
    {
        public IPlateau Plateau { get; set; }
        public IPosition RoverPosition { get; set; }
        public Directions RoverDirection { get; set; }


        public Rover(IPlateau plateau, IPosition roverPosition, Directions roverDirection)
        {
            Plateau = plateau;
            RoverPosition = roverPosition;
            RoverDirection = roverDirection;
        }

        public void Process(string commands)
        {
            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'M':
                        Move();
                        break;
                    default:
                        throw new ArgumentException(string.Format($"Invalid value: {command}"));
                }
            }
        }

        private void TurnLeft()
        {
            RoverDirection = RoverDirection - 1 < Directions.N ? Directions.W : RoverDirection - 1;
        }

        private void TurnRight()
        {
            RoverDirection = RoverDirection + 1 > Directions.W ? Directions.N : RoverDirection + 1;
        }

        private void Move()
        {
            if (RoverDirection == Directions.N)
            {
                RoverPosition.Y++;
            }
            else if (RoverDirection == Directions.E)
            {
                RoverPosition.X++;
            }
            else if (RoverDirection == Directions.S)
            {
                RoverPosition.Y--;
            }
            else if (RoverDirection == Directions.W)
            {
                RoverPosition.X--;
            }
        }

        public override string ToString()
        {
            var PlateauAreaX = Plateau.PlateauPosition.X + 1;
            var PlateauAreaY = Plateau.PlateauPosition.Y + 1;
            var PlateauAreaDots = new string[PlateauAreaX, PlateauAreaY];


            for (int i = 0; i < PlateauAreaX; i++)
            {
                for (int k = 0; k < PlateauAreaY; k++)
                {
                    PlateauAreaDots[i, k] = "-";
                }
            }
            var arrow = string.Empty;
            switch (RoverDirection)
            {
                case Directions.N:
                    arrow = ((char)30).ToString();
                    break;
                case Directions.E:
                    arrow = ((char)16).ToString();
                    break;
                case Directions.S:
                    arrow = ((char)31).ToString();
                    break;
                case Directions.W:
                    arrow = ((char)17).ToString();
                    break;
                default:
                    break;
            }
            PlateauAreaDots[PlateauAreaY - 1 - RoverPosition.Y, RoverPosition.X] = arrow;

            for (int i = 0; i < PlateauAreaX; i++)
            {
                for (int j = 0; j < PlateauAreaY; j++)
                {
                    Console.Write(PlateauAreaDots[i, j] + " ");
                }
                Console.WriteLine();
            }

            return $"{RoverPosition.X} {RoverPosition.Y} {RoverDirection}";
        }
    }
}
