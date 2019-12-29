using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Abstract
{
    public interface IPosition
    {
        int xPoint { get; set; }
        int yPoint { get; set; }
    }
}
