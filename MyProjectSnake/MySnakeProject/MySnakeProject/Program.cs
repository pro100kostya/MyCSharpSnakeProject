using MySnakeProject;

internal class Program
{
    public static void Main()
    {
        ConsoleInput consoleInput = new ConsoleInput();
        PlaybleUnitSnake player = new("Snake", new Vector2(0, 0), consoleInput);

        while (true)
        {
            consoleInput.Update();
            player.Update();

            Thread.Sleep(1000);  
        }
    }
}