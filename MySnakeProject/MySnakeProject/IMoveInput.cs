using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnakeProject
{
    internal interface IMoveInput
    {
        public event Action MoveUp;
        public event Action MoveDown;
        public event Action MoveLeft;
        public event Action MoveRight;
    }
}
