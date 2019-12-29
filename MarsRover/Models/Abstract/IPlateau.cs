using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models.Abstract
{
    public interface IPlateau
    {
         int Width { get; set; }
         int Height { get; set; }
        bool Validate(int width, int height);
    }
}
