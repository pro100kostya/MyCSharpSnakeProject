using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnakeProject
{
    internal interface IMoveInput
    {
        Direction? GetDirection();
    }
}
