using MarsRoverApp.Enums;
using MarsRoverApp.PlateauSpace;

namespace MarsRoverApp.RoverSpace
{
    public interface IRover
    {
        Coordinate Coordinate { get; set; }
        Plateau Plateau { get; set; }
        Directions Direction { get; set; }
        void Move(Movements movement);
    }
}
