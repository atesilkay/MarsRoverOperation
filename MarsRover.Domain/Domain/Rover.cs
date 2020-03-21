using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Domain
{
    public class Rover : IRover
    {
        public Coordinate Coordinate { get; set; }
        public Direction Direction { get; set; }
        public char[] Instructions { get; set; }

        public void TurnLeft()
        {
            switch (this.Direction)
            {
                case Direction.South:
                    this.Direction = Direction.East;
                    break;
                case Direction.North:
                    this.Direction = Direction.West;
                    break;
                case Direction.West:
                    this.Direction = Direction.South;
                    break;
                case Direction.East:
                    this.Direction = Direction.North;
                    break;
                default:
                    throw new InvalidOperationException("Invalid TurnLeft operation.");
            }
        }

        public void TurnRight()
        {
            switch (this.Direction)
            {
                case Direction.South:
                    this.Direction = Direction.West;
                    break;
                case Direction.North:
                    this.Direction = Direction.East;
                    break;
                case Direction.West:
                    this.Direction = Direction.North;
                    break;
                case Direction.East:
                    this.Direction = Direction.South;
                    break;
                default:
                    throw new InvalidOperationException("Invalid TurnRight operation.");
            }
        }

        public void MoveForward()
        {
            switch (this.Direction)
            {
                case Direction.South:
                    this.Coordinate.Y = this.Coordinate.Y - 1;
                    break;
                case Direction.West:
                    this.Coordinate.X = this.Coordinate.X - 1;
                    break;
                case Direction.East:
                    this.Coordinate.X = this.Coordinate.X + 1;
                    break;
                case Direction.North:
                    this.Coordinate.Y = this.Coordinate.Y + 1;
                    break;
                default:
                    break;
            }
        }
    }
}
