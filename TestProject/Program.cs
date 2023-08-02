using TestClass;

internal class Program
{
    private static void Main(string[] args)
    {
        var game = new ThreeAndTwoGame();
        game.AddPlayer("Ronald");
        game.AddPlayer("Miguel");
        game.Play();

        Console.WriteLine();
    }
}