using MarsRover.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Abstract
{
    public interface IRover
    {
        Position Position { get; set; }

        Direction Direction { get; set; }
    }
}
