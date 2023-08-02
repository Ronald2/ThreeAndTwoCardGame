namespace TestClass
{
    public static class ConsoleInputParser
    {
        public static bool TryParseCardIndex(string input, int maxIndex, out int index)
        {
            return int.TryParse(input, out index) && index >= 0 && index <= maxIndex;
        }
    }
}