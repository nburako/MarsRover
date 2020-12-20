using MarsRoverApp.Enums;
using MarsRoverApp.PlateauSpace;
using MarsRoverApp.RoverSpace;
using System;

namespace MarsRoverApp.Command
{
    public class RoverDeployCommand
    {
        public Rover Rover { get; set; }

        public Rover RunCommand(string command, Plateau plateau)
        {
            var coordinate = new Coordinate();
            ParseCommand(command, coordinate, out var direction);
            var rover = DeployRover(coordinate, direction, plateau);

            return rover;
        }

        public Rover DeployRover(Coordinate coordinate, Directions direction, Plateau plateau)
        {
            CheckIfLocationToDeployIsValid(coordinate, plateau);
            var rover = new Rover(coordinate, direction, plateau);
            Rover = rover;

            return rover;
        }

        private static void ParseCommand(string command, Coordinate coordinate, out Directions direction)
        {
            var splittedCommand = command.Split(' ');
            coordinate.X = int.Parse(splittedCommand[0]);
            coordinate.Y = int.Parse(splittedCommand[1]);
            direction = Enum.Parse<Directions>(splittedCommand[2]);
        }

        private void CheckIfLocationToDeployIsValid(Coordinate coordinate, Plateau plateau)
        {
            if (!IsAppropriateLocationToDeployRover(coordinate, plateau))
                throw new Exception("Rover outside of bounds");
        }

        private bool IsAppropriateLocationToDeployRover(Coordinate coordinate, Plateau plateau)
        {
            return coordinate.X >= 0 && coordinate.X < plateau.Size.Width &&
                   coordinate.Y >= 0 && coordinate.Y < plateau.Size.Height;
        }
    }
}
