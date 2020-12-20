using MarsRoverApp.Enums;
using MarsRoverApp.RoverSpace;
using System;

namespace MarsRoverApp.Command
{
    public class RoverMovementCommand
    {
        public void RunCommand(string command, Rover rover)
        {
            MoveRoverWithCommand(command, rover);
            WriteRoverLocation(rover);
        }

        private static void MoveRoverWithCommand(string command, Rover rover)
        {
            foreach (var order in command)
            {
                var movement = Enum.Parse<Movements>(order.ToString());
                rover.Move(movement);
            }
        }

        private static void WriteRoverLocation(Rover rover)
        {
            Console.WriteLine($"{rover.Coordinate.X} {rover.Coordinate.Y} {rover.Direction}");
        }
    }
}
