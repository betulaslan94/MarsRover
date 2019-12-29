using MarsRover.Models.Abstract;
using MarsRover.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models
{
    public class Rover : IRover
    {
        public Position Position { get; set; }

        public Direction Direction { get; set; }

        public Rover(Position position, Direction direction)
        {
            Position = position;
            Direction = direction;
        }
    }
}
