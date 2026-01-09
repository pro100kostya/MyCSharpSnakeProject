using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnakeProject
{
    internal abstract class Unit
    {
        public Vector2 CurrentPosition;

        public abstract void Update();
    }
}
