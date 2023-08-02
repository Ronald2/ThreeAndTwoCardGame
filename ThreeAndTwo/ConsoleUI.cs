namespace ThreeAndTwo
{
    public static class ConsoleUI
    {
        public static void DisplayMessage(string message)
        {
            Console.WriteLine(message);
        }

        public static void DisplayPlayer(Player player)
        {
            Console.WriteLine(player);
        }

        public static void ClearScreen()
        {
            Console.Clear();
        }
    }
}