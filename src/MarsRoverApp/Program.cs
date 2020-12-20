using MarsRoverApp.Command;
using MarsRoverApp.Infrastructure.Enums;
using MarsRoverApp.PlateauSpace;
using MarsRoverApp.RoverSpace;
using System;
using System.Collections.Generic;

namespace MarsRoverApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var exitKey = "X";
            string command = "";
            Plateau plateau = null;
            List<Rover> rovers = new List<Rover>();

            try
            {
                while (!(command == exitKey))
                {
                    command = Console.ReadLine();
                    var commandType = CommandResolver.ResolveCommand(command);

                    switch (commandType)
                    {
                        case CommanTypes.PlateauSizeCommand:
                            var plateauCommand = new PlateauSizeCommand();
                            plateau = plateauCommand.RunCommand(command);
                            break;
                        case CommanTypes.RoverDeployCommand:
                            var deployCommand = new RoverDeployCommand();
                            var rover = deployCommand.RunCommand(command, plateau);
                            rovers.Add(rover);
                            break;
                        case CommanTypes.RoverMovementCommand:
                            var movement = new RoverMovementCommand();
                            movement.RunCommand(command, rovers[rovers.Count - 1]);
                            break;
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
