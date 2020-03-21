using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover.Operation;
using MarsRover.Domain;

namespace MarRover.Test
{
    [TestClass]
    public class RoverProcessorTest
    {
        [TestMethod]
        public void Start_WhenCalledWithValidParams_ShouldReturnResult()
        {
            List<Rover> roverSquad = new List<Rover>();
            roverSquad.Add(new Rover
                {
                    Coordinate = new Coordinate
                    {
                        X = 1,
                        Y = 2
                    },
                    Direction = Direction.North,
                    Instructions = new char[] { 'L', 'M', 'L','M','L','M','L','M','M' }
                });
            roverSquad.Add(new Rover
            {
                Coordinate = new Coordinate
                {
                    X = 3,
                    Y = 3
                },
                Direction = Direction.East,
                Instructions = new char[] { 'M', 'M', 'R', 'M', 'M', 'R', 'M', 'R', 'R', 'M' }
            });
            Coordinate marsCoordinate = new Coordinate
            {
                X=5,
                Y=5
            };

            RoverProcessor roverProcessor = new RoverProcessor(roverSquad);

            var operationResult=roverProcessor.Start(marsCoordinate);

            Assert.AreEqual(operationResult.Count, 2);

            Assert.AreEqual(operationResult[0].Direction, Direction.North);
            Assert.AreEqual(operationResult[0].Coordinate.X, 1);
            Assert.AreEqual(operationResult[0].Coordinate.Y, 3);

            Assert.AreEqual(operationResult[1].Direction, Direction.East);
            Assert.AreEqual(operationResult[1].Coordinate.X, 5);
            Assert.AreEqual(operationResult[1].Coordinate.Y, 1);
        }
    }
}
