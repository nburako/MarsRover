using MarsRoverApp.PlateauSpace;

namespace MarsRoverApp.Command
{
    public class PlateauSizeCommand
    {
        public Plateau RunCommand(string command)
        {
            var plateau = new Plateau();
            ParseCommand(command, out var width, out var height);
            plateau.Determine(width, height);

            return plateau;
        }

        private static void ParseCommand(string command, out int width, out int height)
        {
            var splitCommand = command.Split(' ');
            width = int.Parse(splitCommand[0]) + 1;
            height = int.Parse(splitCommand[1]) + 1;
        }
    }
}
