using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MarsRover.Domain;

namespace MarsRover.Operation
{
    interface IRoverProcessor
    {
        List<OperationResult> Start(Coordinate marsCoordinate);
    }
}
