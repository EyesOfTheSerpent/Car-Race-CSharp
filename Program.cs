namespace Car_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ArgumentNullException.ThrowIfNull(args);
            RunCode();
        }

        static void RunCode()
        {
            StyleConsole();
            CarRace.InitGame();
        }

        static void StyleConsole()
        {
            Console.Title = "Car Race 2023";
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
        }

    }
}
