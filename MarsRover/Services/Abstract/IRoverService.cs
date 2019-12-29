using MarsRover.Models;
using MarsRover.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Services.Abstract
{
    public interface IRoverService
    {
        bool Validate(IRover rover, IPlateau plateau);
        IPlateau Plateau { get; set; }
        IRover Rover { get; set; }
        void Process(string commands);
        string GetCurrentLocation();
    }
}
