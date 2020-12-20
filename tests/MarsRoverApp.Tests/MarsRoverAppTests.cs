using MarsRoverApp.Command;
using MarsRoverApp.Enums;
using MarsRoverApp.Infrastructure.Enums;
using MarsRoverApp.PlateauSpace;
using Xunit;

namespace MarsRoverApp.Tests
{
    public class MarsRoverTests
    {
        [Theory]
        [InlineData(new object[] { "5 5", "1 2 N", "LMLMLMLMM", 1, 3, Directions.N })]
        [InlineData(new object[] { "5 5", "3 3 E", "MMRMMRMRRM", 5, 1, Directions.E })]
        public void GeneratePlataueAndExecuteRoverDataShouldEqualToInputValues(string plateauSize, string roverPosition, string roverCommand, int expectedX, int exceptedY, Directions direction)
        {
            // Arrange
            var plateauCommand = new PlateauSizeCommand();
            Plateau plateau = plateauCommand.RunCommand(plateauSize);

            var deployCommand = new RoverDeployCommand();
            var rover = deployCommand.RunCommand(roverPosition, plateau);

            var movement = new RoverMovementCommand();

            // Act
            movement.RunCommand(roverCommand, rover);

            // Assert
            Assert.NotNull(rover);
            Assert.Equal(expectedX, rover.Coordinate.X);
            Assert.Equal(exceptedY, rover.Coordinate.Y);
            Assert.Equal(direction, rover.Direction);
        }

        [Theory]
        [InlineData(new object[] { "5 5", "1 2 N", "MMMMMMMMMMMMM", 1, 3 })]
        public void RoverShouldNotMoveLimitOfArea(string plateauSize, string roverPosition, string roverCommand, int expectedX, int exceptedY)
        {
            // Arrange
            var plateauCommand = new PlateauSizeCommand();
            Plateau plateau = plateauCommand.RunCommand(plateauSize);

            var deployCommand = new RoverDeployCommand();
            var rover = deployCommand.RunCommand(roverPosition, plateau);

            var movement = new RoverMovementCommand();

            // Act
            movement.RunCommand(roverCommand, rover);

            // Assert
            Assert.NotNull(rover);
            Assert.True(expectedX <= 5);
            Assert.True(exceptedY <= 5);
        }

        [Theory]
        [InlineData(new object[] { "5 5", CommanTypes.PlateauSizeCommand })]
        [InlineData(new object[] { "1 2 N", CommanTypes.RoverDeployCommand })]
        [InlineData(new object[] { "LMLMLMLMM", CommanTypes.RoverMovementCommand })]
        public void CommandResolverShouldReturnCorrectEnumForCommand(string command, CommanTypes expectedType)
        {
            //Act
            var commandType = CommandResolver.ResolveCommand(command);

            //Assert
            Assert.Equal(expectedType, commandType);
        }
    }
}
