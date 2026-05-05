using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnakeProject
{
    internal class Snake : Unit
    {
        private IMoveInput _input;
        private Direction _currentDirection;      
        private List<Vector2> _body;
        private bool _shouldGrow = false;

        public bool IsAlive { get; private set; } = true;
        public IReadOnlyList<Vector2> Body => _body.AsReadOnly();
        public int Score => Body.Count - 1;

        public Snake(Vector2 startPosition, IMoveInput input, ConsoleRenderer renderer)
        {
            _position = startPosition;
            _body = new List<Vector2> { startPosition };
            _renderer = renderer;                    

            _currentDirection = Direction.Right;   
            _view = '■';
            _colorId = 1;

            _input = input;
        }

        public void Grow()
        {
            _shouldGrow = true;
        }

        public override void Update()
        {
            var newDir = _input.GetDirection();
            if (newDir.HasValue)
            {
                _currentDirection = newDir.Value;
            }

            Vector2 newHead = _position;
            switch (_currentDirection)
            {
                case Direction.Up: newHead.Y--; break;
                case Direction.Down: newHead.Y++; break;
                case Direction.Left: newHead.X--; break;
                case Direction.Right: newHead.X++; break;
            }

            if (_body.Contains(newHead) ||
                newHead.X < 0 || newHead.X >= _renderer.width ||
                newHead.Y < 0 || newHead.Y >= _renderer.height)
            {
                IsAlive = false;      
                return;
            }

            _body.Insert(0, newHead);
            _position = newHead;

            if (!_shouldGrow)
            {
                _body.RemoveAt(_body.Count - 1);
            }
            else
            {
                _shouldGrow = false;
            }

            Draw();
        }

        private void Draw()
        {
            for (int i = 1; i < _body.Count; i++)
            {
                _renderer.SetPixel(_body[i].X, _body[i].Y, 'O', _colorId);
            }
            _renderer.SetPixel(this);
        }


    }
}
