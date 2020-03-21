using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Domain;

namespace MarsRover
{
    public class ValidationHelper
    {
        public static Direction ValidateDirectionString(string direction)
        {
            switch(direction)
            {
                case "N":
                    return Direction.North;
                case "S":
                    return Direction.South;
                case "W":
                    return Direction.West;
                case "E":
                    return Direction.East;
                default:
                    throw new ArgumentException("direction");

            }
        }

        public static Rover ValidateAndMapRoverInputs(string positionString, string instructionString)
        {
            if (string.IsNullOrEmpty(positionString))
                throw new ArgumentNullException("positionString", "positionString can not be empty.");

            var positionList = positionString.Split(' ');
            if (positionList.Length != 3)
                throw new ArgumentOutOfRangeException("positionString");

            int x;
            if (!int.TryParse(positionList[0].ToString(), out x))
                throw new ArgumentException("x position");

            int y;
            if (!int.TryParse(positionList[1].ToString(), out y))
                throw new ArgumentException("y position");

            var direction = ValidationHelper.ValidateDirectionString(positionList[2].ToString());

            if (instructionString.Except("MLR").Any())
                throw new ArgumentException("Invalid instructionString character.");

            return new Rover
            {
                Direction = direction,
                Coordinate = new Coordinate
                {
                    X = x,
                    Y = y
                },
                Instructions = instructionString.ToCharArray()

            };
        }

        public static Coordinate ValidateAndMapArea(string upperRightCoordinateString)
        {
            if (string.IsNullOrEmpty(upperRightCoordinateString))
                throw new ArgumentNullException("upperRightCoordinateString", "Upper Right Coordinate can not be empty.");

            var coordinateList = upperRightCoordinateString.Split(' ');
            if (coordinateList.Length != 2)
                throw new ArgumentOutOfRangeException("upperRightCoordinateString");

            int x;
            if (!int.TryParse(coordinateList[0].ToString(), out x))
                throw new ArgumentException("upperRightCoordinateString x");

            int y;
            if (!int.TryParse(coordinateList[1].ToString(), out y))
                throw new ArgumentException("upperRightCoordinateString y");

            return new Coordinate
            {
                X = x,
                Y = y
            };
        }

        public static bool ValidateBoundaries(Coordinate marsCoordinate, Coordinate roverPosition)
        {
            if (roverPosition.Y < 0 || roverPosition.X < 0 || roverPosition.Y > marsCoordinate.Y || roverPosition.X > marsCoordinate.X)
                return false;

            return true;
        }
    }
}
