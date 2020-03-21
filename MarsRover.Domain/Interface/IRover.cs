using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsRover.Domain
{
    interface IRover
    {
        void TurnLeft();
        void TurnRight();
        void MoveForward();
    }
}
