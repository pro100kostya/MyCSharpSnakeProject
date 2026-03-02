using MySnakeProject;
using Shared;

internal class Program
{
    public static void Main()
    {
        ConsoleInput consoleInput = new ConsoleInput();
        PlaybleUnitSnake player = new(new Vector2(0, 0), consoleInput);

        ConsoleColor[] colors = { ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.White };
        ConsoleRenderer renderer = new ConsoleRenderer(colors);

        while (true)
        {
            consoleInput.Update();
            player.Update(renderer);
            renderer.Render();
            renderer.Clear();


            Thread.Sleep(100);
        }
    }
}