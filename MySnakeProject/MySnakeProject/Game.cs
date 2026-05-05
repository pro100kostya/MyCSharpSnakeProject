using Shared;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MySnakeProject
{
    internal class Game
    {
        private const int InitialApplesForLevel = 2;
        private const int InitialTickDelayMs = 100;
        private const int SpeedDivider = 2;
        private const int ApplesPerLevelIncrement = 2;
        private const int MessageDisplayTimeoutMs = 1500;
        private const int GameOverTimeoutMs = 3000;

        private ConsoleRenderer _renderer;
        private ConsoleInput _input;
        private Snake _snake;
        private Apple _apple;
        private Random _random = new Random();

        private int _level = 1;
        private int _tickDelayMs = InitialTickDelayMs;
        private int _applesForNextLevel = InitialApplesForLevel;

        public Game()
        {
            ConsoleColor[] colors = { ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.Red, ConsoleColor.Yellow };
            _renderer = new ConsoleRenderer(colors);
            _input = new ConsoleInput();
        }

        public void Run()
        {
            while (true)
            {
                _snake = new Snake(new Vector2(_renderer.width / 2, _renderer.height / 2), _input, _renderer);
                spawnApple();

                showLevelMessage();

                while (_snake.IsAlive && !LevelCompleted())
                {
                    showGameState();
                    _snake.Update();

                    if (_snake.position == _apple.position)
                    {
                        _snake.Grow();
                        spawnApple();
                    }

                    _renderer.SetPixel(_apple);
                    _renderer.Render();
                    _renderer.Clear();

                    Thread.Sleep(_tickDelayMs);
                }

                if (_snake.IsAlive)
                {
                    nextLevel();
                }
                else
                {
                    gameOver();
                }
            }
        }

        private bool LevelCompleted() => _snake.Score >= _applesForNextLevel;

        private void spawnApple()
        {
            var body = _snake.Body;
            var freeCells = new List<Vector2>();
            for (int x = 0; x < _renderer.width; x++)
                for (int y = 0; y < _renderer.height; y++)
                {
                    var cell = new Vector2(x, y);
                    if (!body.Contains(cell))
                        freeCells.Add(cell);
                }

            var pos = freeCells[_random.Next(freeCells.Count)];
            if (_apple == null)
                _apple = new Apple(pos);
            else
                _apple.SetPosition(pos);
        }

        private void gameOver()
        {
            ShowTextState gameOver = new("Game over!", MessageDisplayTimeoutMs);

            _level = 1;
            _tickDelayMs = InitialTickDelayMs;
            _applesForNextLevel = InitialApplesForLevel;

            _renderer.Clear();
            Console.Clear();
            gameOver.Draw(_renderer);
            _renderer.Render();

            clearInputBuffer();
            Thread.Sleep(GameOverTimeoutMs);
        }

        private void nextLevel()
        {
            _level++;
            _tickDelayMs /= SpeedDivider;
            _applesForNextLevel += ApplesPerLevelIncrement;

            showLevelMessage();
        }

        private void showLevelMessage()
        {
            ShowTextState levelMsg = new($"Level: {_level}", MessageDisplayTimeoutMs);

            _renderer.Clear();
            Console.Clear();
            levelMsg.Draw(_renderer);
            _renderer.Render();

            clearInputBuffer();
            Thread.Sleep(MessageDisplayTimeoutMs);
        }

        private void clearInputBuffer()
        {
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }

        private void showGameState()
        {
            _renderer.DrawString($"Score: {_snake.Score}", 0, 0, ConsoleColor.White);
            _renderer.DrawString($"Level: {_level}", 0, 1, ConsoleColor.White);
        }
    }
}
