using MarsRover.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Models
{
    public class Plateau : IPlateau
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Plateau(int width, int height, Result result)
        {
            if (Validate(width, height))
            {
                Width = width;
                Height = height;
            }
            else
                result.SetError("Plateau width or height value is invalid");
        }

        public bool Validate(int width, int height)
        {
            return width > 0 && height > 0;
        }
    }
}
