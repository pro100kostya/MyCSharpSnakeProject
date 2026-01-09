using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnakeProject
{
    internal class PlaybleUnitSnake : Unit
    {
        private IMoveInput _input;
        private Directions _currentDirection;
        public PlaybleUnitSnake(Vector2 startPosition, IMoveInput input, Directions startDirection = Directions.Right) 
        {
            CurrentPosition = startPosition;
            _currentDirection = startDirection;

            _input = input;
            _input.MoveUp += MoveUp;
            _input.MoveDown += MoveDown;
            _input.MoveLeft += MoveLeft;
            _input.MoveRight += MoveRight;
        }

        private void MoveUp()
        {
            _currentDirection = Directions.Up;
        }
        private void MoveDown()
        {
            _currentDirection = Directions.Down;
        }
        private void MoveLeft()
        {
            _currentDirection = Directions.Left;
        }
        private void MoveRight()
        {
            _currentDirection = Directions.Right;
        }

        public override void Update()
        {
            switch (_currentDirection)
            {
                 case Directions.Up:
                    CurrentPosition.Y++;
                    ConsoleWriter.WriteCurrentUnitPosition(this);
                    break;
                 case Directions.Down:
                    CurrentPosition.Y--;
                    ConsoleWriter.WriteCurrentUnitPosition(this);
                    break;
                 case Directions.Left:
                    CurrentPosition.X--;
                    ConsoleWriter.WriteCurrentUnitPosition(this);
                    break;
                 case Directions.Right:
                    CurrentPosition.X++;
                    ConsoleWriter.WriteCurrentUnitPosition(this);
                    break;
            }
        }

        public void Dispose()
        {
            _input.MoveUp -= MoveUp;
            _input.MoveDown -= MoveDown;
            _input.MoveRight -= MoveRight;
            _input.MoveLeft -= MoveLeft;
        }

        public enum Directions
        { 
            Up,
            Down, 
            Left,
            Right
        }

    }
}
