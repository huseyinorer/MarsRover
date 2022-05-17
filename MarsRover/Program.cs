
namespace MarsRover.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test Input:");
            Console.WriteLine();
            Console.WriteLine("5 5");

            //1 2 N > LMLMLMLMM
            Console.WriteLine("1 2 N");
            Console.WriteLine("LMLMLMLMM");
            Console.WriteLine();
            Plateau plateauFirst = new Plateau(new Position(5, 5));
            Rover firstRover = new Rover(plateauFirst, new Position(1, 2), Directions.N);
            firstRover.Process("LMLMLMLMM");

            // 3 3 E > MMRMMRMRRM
            Console.WriteLine("3 3 E");
            Console.WriteLine("MMRMMRMRRM");
            Console.WriteLine();
            Plateau plateauSecond = new Plateau(new Position(5, 5));
            Rover secondRover = new Rover(plateauSecond, new Position(3, 3), Directions.E);
            secondRover.Process("MMRMMRMRRM");

            Console.WriteLine("Expected Output:");
            Console.WriteLine();
            Console.WriteLine(firstRover.ToString());
            Console.WriteLine(secondRover.ToString());
            Console.WriteLine();

            Console.ReadLine();

        }
    }
}