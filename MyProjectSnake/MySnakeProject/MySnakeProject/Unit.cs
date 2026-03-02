using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnakeProject
{
    internal abstract class Unit
    {
        protected Vector2 _currentPosition;
        protected char _view;
        protected byte _unitColorID;

        public Vector2 CurrentPosition => _currentPosition;
        public char View => _view;
        public byte UnitColorID => _unitColorID;

        public abstract void Update(ConsoleRenderer renderer);
    }
}
