using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Domain;

namespace MarsRover.Operation
{
    public class RoverProcessor : IRoverProcessor
    {
        private List<Rover> RoverSquad { get; set; }

        public RoverProcessor(List<Rover> roverSquad)
        {
            this.RoverSquad = roverSquad;
        }

        public List<OperationResult> Start(Coordinate marsCoordinate)
        {
            List<OperationResult> operationResult = new List<OperationResult>();

            foreach(var rover in RoverSquad)
            {
                foreach (var intruction in rover.Instructions)
                {
                    switch (intruction)
                    {
                        case 'L':
                            rover.TurnLeft();
                            break;
                        case 'R':
                            rover.TurnRight();
                            break;
                        case 'M':
                            rover.MoveForward();
                            break;
                        default:
                            throw new InvalidOperationException(string.Format("{0} instruction is invalid", intruction));
                    }

                    if (!ValidationHelper.ValidateBoundaries(marsCoordinate, rover.Coordinate))
                        throw new ArgumentOutOfRangeException("Rover cant go to location in instruction.");
                }

                operationResult.Add(new OperationResult
                    {
                        Direction = rover.Direction,
                        Coordinate = new Coordinate
                        {
                            X=rover.Coordinate.X,
                            Y=rover.Coordinate.Y
                        }
                    });
            }

            return operationResult;
        }

        
    }
}
