using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnakeProject
{
    internal class ConsoleInput : IMoveInput
    {
        public Direction? GetDirection()
        {
            Direction? result = null;

            while (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true); 

                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        result = Direction.Up;
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        result = Direction.Down;
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        result = Direction.Left;
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        result = Direction.Right;
                        break;
                }
            }

            return result;
        }
    }
}
