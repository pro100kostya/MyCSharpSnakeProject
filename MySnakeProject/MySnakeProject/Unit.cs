using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnakeProject
{
    internal abstract class Unit : IDrawable
    {
        protected Vector2 _position;
        protected char _view;
        protected byte _colorId;
        protected ConsoleRenderer _renderer;

        public Vector2 position => _position;
        public char view => _view;
        public byte colorId => _colorId;

        public abstract void Update();
    }
}
