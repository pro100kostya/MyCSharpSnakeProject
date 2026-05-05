using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnakeProject
{
    internal class Apple : IDrawable
    {
        public Vector2 position { get; private set; }
        public char view => '@';
        public byte colorId => 0; 

        public Apple(Vector2 position)
        {
            this.position = position;
        }

        public void SetPosition(Vector2 newPosition)
        {
            position = newPosition;
        }
    }
}
