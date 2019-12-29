using MarsRover.Models;
using MarsRover.Models.Abstract;
using MarsRover.Models.Enums;
using MarsRover.Services;
using MarsRover.Services.Abstract;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Test
{
    [TestFixture]
    public class RoverTests
    {
        IRoverService roverService;
        IRover rover;
        Result result;

        [Test]
        public void Create_Rover_Should_Throw_Exception()
        {
            result = new Result();
            rover = new Rover(new Position(6, 2), Direction.N);
            roverService = new RoverService(rover, new Plateau(5, 5, new Result()), result);
            Assert.AreEqual(result.IsSuccess, false);
        }

        [Test]
        public void Create_Rover_Get_Success()
        {
            result = new Result();
            rover = new Rover(new Position(2, 2), Direction.N);
            roverService = new RoverService(rover, new Plateau(5, 5, new Result()), result);
            Assert.AreEqual(result.IsSuccess, true);
        }

        [Test]
        public void Get_Rover_Location_Without_Commands()
        {
            result = new Result();
            rover = new Rover(new Position(2, 2), Direction.N);
            roverService = new RoverService(rover, new Plateau(5, 5, new Result()), new Result());
            Assert.AreEqual(roverService.GetCurrentLocation(), "2 2 N");
        }

        [Test]
        public void First_Rover_Check_Location_Success()
        {
            result = new Result();
            rover = new Rover(new Position(1, 2), Direction.N);
            roverService = new RoverService(rover, new Plateau(5, 5, new Result()), new Result());
            roverService.Process("LMLMLMLMM");
            Assert.AreEqual(roverService.GetCurrentLocation(), "1 3 N");
        }

        [Test]
        public void First_Rover_Check_Location_Error()
        {
            result = new Result();
            rover = new Rover(new Position(1, 2), Direction.N);
            roverService = new RoverService(rover, new Plateau(5, 5, new Result()), new Result());

            var ex = Assert.Throws<Exception>(() => roverService.Process("LRAR"));

            Assert.AreEqual("Commands invalid", ex.Message);
        }

        [Test]
        public void Second_Rover_Check_Location_Success()
        {
            result = new Result();
            rover = new Rover(new Position(3, 3), Direction.E);
            roverService = new RoverService(rover, new Plateau(5, 5, new Result()), new Result());
            roverService.Process("MMRMMRMRRM");
            Assert.AreEqual(roverService.GetCurrentLocation(), "5 1 E");
        }

        [Test]
        public void Rover_Check_Location_Success()
        {
            result = new Result();
            rover = new Rover(new Position(1, 1), Direction.N);
            roverService = new RoverService(rover, new Plateau(5, 5, new Result()), new Result());
            roverService.Process("MRML");
            Assert.AreEqual(roverService.GetCurrentLocation(), "2 2 N");
        }

        [Test]
        public void When_Command_Exceeds_The_Limits()
        {
            result = new Result();
            rover = new Rover(new Position(3, 3), Direction.N);
            roverService = new RoverService(rover, new Plateau(5, 5, new Result()), new Result());
            roverService.Process("MMMMMMMMMMR");
            Assert.AreEqual(roverService.GetCurrentLocation(), "3 5 E");
        }
    }
}
