
namespace Car_Race
{
    internal class CarUI
    {
        private static readonly string NL = Environment.NewLine;

        public static void GetUI(string TypeUI)
        {
            switch (TypeUI.ToLower())
            {
                case "init":
                    InitMenu();
                    break;
                case "main":
                    MainMenu();
                    break;
                case "race":
                    RaceMenu2();
                    break;
                case "exit":
                    ExitMenu();
                    break;
                default:
                    ErrorMenu();
                    break;
            }
        }

        public static void GetUI(string NameUI, int val1, int val2)
        {
            switch(NameUI)
            {
                case "race":
                    RaceMenu1(val1, val2);
                    break;
            }
        }

        private static void InitMenu() 
        {
            MainMenu();
            Console.WriteLine("To choose a mode, please type \"1\" or \"2\".");
            Console.WriteLine("Your options are:");
            Console.WriteLine($"1: Looped (Only 1 racer).{NL}2: Random speed (2 racers competing).");
        }

        private static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("----- The Car Race 2023 -----");
        }

        private static void RaceMenu1(int CurrentSpeed, int Sec) 
        {
            MainMenu();
            Console.WriteLine($"Your car is currently travelling {CurrentSpeed}m/s");
            Console.WriteLine($"Time passed: {Sec}s");
        }

        private static void RaceMenu2() 
        {
            MainMenu();
            Console.WriteLine("Who will win? Let it be up to the fastest racer.");
            Console.WriteLine();
        }

        private static void ErrorMenu()
        {
            Console.WriteLine("Invalid menu.");
            Thread.Sleep(1400);
            Environment.Exit(0);
        }

        private static void ExitMenu()
        {
            MainMenu();
            Console.WriteLine("Would you like to continue? Y/N");
        }

    }
}
