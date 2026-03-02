using Shared;
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
        private directions _currentDirection;

        public PlaybleUnitSnake(Vector2 startPosition, IMoveInput input) 
        {
            _currentPosition = startPosition;
            _currentDirection = directions.Right;

            _view = '■';
            _unitColorID = 1;

            _input = input;
            _input.MoveUp += moveUp;
            _input.MoveDown += moveDown;
            _input.MoveLeft += moveLeft;
            _input.MoveRight += moveRight;
        }

        private void moveUp()
        {
            _currentDirection = directions.Up;
        }
        private void moveDown()
        {
            _currentDirection = directions.Down;
        }
        private void moveLeft()
        {
            _currentDirection = directions.Left;
        }
        private void moveRight()
        {
            _currentDirection = directions.Right;
        }

        public override void Update(ConsoleRenderer renderer)
        {
            switch (_currentDirection)
            {
                 case directions.Up:
                    _currentPosition.Y--;
                    renderer.SetUnitPixel(this);
                    break;
                 case directions.Down:
                    _currentPosition.Y++;
                    renderer.SetUnitPixel(this);
                    break;
                 case   directions.Left:
                    _currentPosition.X--;
                    renderer.SetUnitPixel(this);
                    break;
                 case directions.Right:
                    _currentPosition.X++;
                    renderer.SetUnitPixel(this);
                    break;
            }
        }

        private enum directions
        { 
            Up,
            Down, 
            Left,
            Right
        }

    }
}
