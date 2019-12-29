using MarsRover.Models;
using MarsRover.Models.Enums;
using MarsRover.Services;
using System;

namespace MarsRover
{
    class Program
    {
        static Plateau plateau;
        static void Main(string[] args)
        {
            try
            {
                Result result;
                result = new Result();
                Console.WriteLine("Input:");
                result = ReadPlateau();

                if (!result.IsSuccess)
                    Console.WriteLine(result.ResultDescription);
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        result = ReadRovers();
                        Console.WriteLine(result.ResultDescription);
                        if (!result.IsSuccess) break;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadKey();
        }

        static Result ReadPlateau()
        {
            Result result = new Result();
            var plateauInput = Console.ReadLine().Split(' ');

            var width = Convert.ToInt32(plateauInput[0]);
            var height = Convert.ToInt32(plateauInput[1]);
            plateau = new Plateau(width, height, result);
            return result;
        }

        static Result ReadRovers()
        {
            Result result = new Result();
            var roverInput = Console.ReadLine().Split(' ');

            int x = Convert.ToInt32(roverInput[0]);
            int y = Convert.ToInt32(roverInput[1]);
            Direction direction = new Direction();
            switch (roverInput[2].ToString())
            {
                case ("N"):
                    direction = Direction.N;
                    break;
                case ("E"):
                    direction = Direction.E;
                    break;
                case ("S"):
                    direction = Direction.S;
                    break;
                case ("W"):
                    direction = Direction.W;
                    break;
                default:
                    result.SetError("Wrong direction");
                    break;
            }
            if (result.IsSuccess)
            {
                Rover rover = new Rover(new Position(x, y), direction);
                RoverService roverService = new RoverService(rover, plateau, result);
                if (result.IsSuccess)
                {
                    roverService.Process(Console.ReadLine());
                    result.ResultDescription = roverService.GetCurrentLocation();
                }
                return result;
            }
            return result;
        }
    }
}
