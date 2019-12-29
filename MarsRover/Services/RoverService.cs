using MarsRover.Models;
using MarsRover.Models.Abstract;
using MarsRover.Models.Enums;
using MarsRover.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MarsRover.Services
{
    public class RoverService : IRoverService
    {
        public IRover Rover { get; set; }
        public IPlateau Plateau { get; set; }

        public RoverService(IRover rover, IPlateau plateau, Result result)
        {
            if (!Validate(rover, plateau))
                result.SetError("Rover location is invalid. Please check again.");
            else
            {
                Rover = rover;
                Plateau = plateau;
            }
        }

        public bool Validate(IRover rover, IPlateau plateau)
        {
            return 0 <= rover.Position.xPoint && rover.Position.xPoint <= plateau.Width && 0 <= rover.Position.yPoint && rover.Position.yPoint <= plateau.Height;
        }

        public string GetCurrentLocation()
        {
            string result = "Rover location not found";
            if (!object.Equals(Rover, null))
                result = string.Format("{0} {1} {2}", Rover.Position.xPoint, Rover.Position.yPoint, Rover.Direction);
            return result;
        }

        public void Process(string commands)
        {
            Regex r = new Regex(@"^[LMR]*$");
            if (r.IsMatch(commands))
            {
                foreach (var command in commands)
                {
                    switch (command)
                    {
                        case ('L'):
                            TurnLeft();
                            break;
                        case ('R'):
                            TurnRight();
                            break;
                        case ('M'):
                            Move();
                            break;
                    }
                }
            }
            else
                throw new Exception("Commands invalid");
        }

        private void TurnLeft()
        {
            Rover.Direction = (Rover.Direction - 1) < Direction.N ? Direction.W : Rover.Direction - 1;
        }

        private void TurnRight()
        {
            Rover.Direction = (Rover.Direction + 1) > Direction.W ? Direction.N : Rover.Direction + 1;
        }

        private void Move()
        {
            switch (Rover.Direction)
            {
                case Direction.N:
                    Rover.Position.yPoint = Rover.Position.yPoint < Plateau.Height ? Rover.Position.yPoint + 1 : Rover.Position.yPoint;
                    break;
                case Direction.E:
                    Rover.Position.xPoint = Rover.Position.xPoint < Plateau.Width ? Rover.Position.xPoint + 1 : Rover.Position.xPoint;
                    break;
                case Direction.S:
                    Rover.Position.yPoint = 0 < Rover.Position.yPoint ? Rover.Position.yPoint - 1 : Rover.Position.yPoint;
                    break;
                case Direction.W:
                    Rover.Position.xPoint = 0 < Rover.Position.xPoint ? Rover.Position.xPoint - 1 : Rover.Position.xPoint;
                    break;
            }
        }
    }
}
