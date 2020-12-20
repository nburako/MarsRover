using MarsRoverApp.Infrastructure.Enums;
using System;
using System.Text.RegularExpressions;

namespace MarsRoverApp.Command
{
    public class CommandResolver
    {
        public static CommanTypes ResolveCommand(string command)
        {
            if (new Regex("^\\d+ \\d+$").IsMatch(command)) //example: 5 5
            {
                return CommanTypes.PlateauSizeCommand;
            }
            else if (new Regex("^\\d+ \\d+ [ESWN]$").IsMatch(command)) //example: 5 5 E
            {
                return CommanTypes.RoverDeployCommand;
            }
            else if (new Regex("^[LRM]+$").IsMatch(command)) //example: LMMMRRMLML
            {
                return CommanTypes.RoverMovementCommand;
            }

            throw new ArgumentException(command);
        }
    }
}
