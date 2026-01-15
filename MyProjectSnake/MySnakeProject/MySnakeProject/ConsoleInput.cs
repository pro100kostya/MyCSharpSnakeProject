using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnakeProject
{
    internal class ConsoleInput : IMoveInput
    {
        public event Action MoveUp;
        public event Action MoveDown;
        public event Action MoveLeft;
        public event Action MoveRight;
        public void Update()
        {
            ConsoleKeyInfo keyInfo;
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true); //true позволяет не отображать нажатую клавишу 0_о

                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        MoveUp?.Invoke();
                        break;
                    case ConsoleKey.S:
                        MoveDown?.Invoke();
                        break;
                    case ConsoleKey.D:
                        MoveRight?.Invoke();
                        break;
                    case ConsoleKey.A:
                        MoveLeft?.Invoke();
                        break;
                }
            }
        }
    }
}
