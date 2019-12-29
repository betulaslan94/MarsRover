using MarsRover.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models
{
    public class Position : IPosition
    {
        public int xPoint { get; set; }
        public int yPoint { get; set; }

        public Position(int x, int y)
        {
            xPoint = x;
            yPoint = y;
        }
    }
}
