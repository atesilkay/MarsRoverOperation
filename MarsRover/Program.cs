using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Operation;
using MarsRover.Domain;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter upper-right coordinates:");
            var marsCoordinate = ValidationHelper.ValidateAndMapArea(Console.ReadLine());
            List<Rover> roverSquad = new List<Rover>();

            for (int i = 1; ; i++)
            {
                Console.WriteLine(string.Format("Please enter {0}. Rover's position:",i));
                var positionString=Console.ReadLine();
                Console.WriteLine(string.Format("Please enter {0}. Rover's Instructions:", i));
                var instructionString = Console.ReadLine();
                var rover = ValidationHelper.ValidateAndMapRoverInputs(positionString, instructionString);
                roverSquad.Add(rover);
                Console.WriteLine(string.Format("Please press C to enter new rover or press any key to start process."));
                if (Console.ReadLine().ToUpper() != "C")
                    break;
            }

            RoverProcessor roverProcessor = new RoverProcessor(roverSquad);
            var operationResult=roverProcessor.Start(marsCoordinate);
            
            foreach(var operation in operationResult)
            {
                Console.WriteLine(string.Format("{0} {1} {2}", operation.Coordinate.X, operation.Coordinate.Y, operation.Direction.ToString()[0]));
            }

        }

        

    }
}
