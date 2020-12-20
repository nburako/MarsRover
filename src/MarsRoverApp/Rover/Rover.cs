using MarsRoverApp.Enums;
using MarsRoverApp.PlateauSpace;
using System;

namespace MarsRoverApp.RoverSpace
{
    public class Rover : IRover
    {
        public Coordinate Coordinate { get; set; }
        public Directions Direction { get; set; }
        public IPlateau Plateau { get; set; }

        public Rover(Coordinate coordinate, Directions direction, IPlateau plateau)
        {
            Coordinate = coordinate;
            Direction = direction;
            Plateau = plateau;
        }

        public void Move(Movements movement)
        {
            switch (movement)
            {
                case Movements.L:
                    TurnLeft();
                    break;
                case Movements.R:
                    TurnRight();
                    break;
                case Movements.M:
                    MoveForward();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(movement), movement, null);
            }
        }

        private void TurnLeft()
        {
            switch (Direction)
            {
                case Directions.N:
                    Direction = Directions.W;
                    break;

                case Directions.W:
                    Direction = Directions.S;
                    break;

                case Directions.S:
                    Direction = Directions.E;
                    break;

                case Directions.E:
                    Direction = Directions.N;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void TurnRight()
        {
            switch (Direction)
            {
                case Directions.N:
                    Direction = Directions.E;
                    break;

                case Directions.E:
                    Direction = Directions.S;
                    break;

                case Directions.S:
                    Direction = Directions.W;
                    break;

                case Directions.W:
                    Direction = Directions.N;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MoveForward()
        {
            switch (Direction)
            {
                case Directions.N:
                    if (Coordinate.Y + 1 <= Plateau.Size.Height)
                        Coordinate.Y += 1;
                    break;

                case Directions.E:
                    if (Coordinate.X + 1 <= Plateau.Size.Width)
                        Coordinate.X += 1;
                    break;

                case Directions.S:
                    if (Coordinate.Y - 1 >= 0)
                        Coordinate.Y -= 1;
                    break;

                case Directions.W:
                    if (Coordinate.X - 1 >= 0)
                        Coordinate.X -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
