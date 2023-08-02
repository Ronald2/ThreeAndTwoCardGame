using System;
using System.Collections.Generic;
using Test;

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
}

public static class ConsoleInputParser
{
    public static bool TryParseCardIndex(string input, int maxIndex, out int index)
    {
        return int.TryParse(input, out index) && index >= 0 && index < maxIndex;
    }
}
