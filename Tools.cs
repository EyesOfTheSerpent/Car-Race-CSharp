
namespace Car_Race
{
    internal class Tools
    {
        //Tving brukeren til å skrive et gyldig tall.
        public static string ForceNumber()
        {
            bool isNum = int.TryParse(Console.ReadLine() ?? String.Empty, out int Num);
            while (!isNum)
            {
                Console.WriteLine("Invalid number. Try again.");
                isNum = int.TryParse(Console.ReadLine() ?? String.Empty, out Num);
            }

            return Num.ToString();
        }

        //Tvinger brukeren til å skrive noe.
        public static string ForceInput()
        {
            string UserInput = Console.ReadLine() ?? String.Empty;

            return UserInput switch
            {
                null or "" => ForceInput(),
                _ => UserInput,
            };

            //Gamlere versjon. Trengs ikke ettersom det gjøres i metoden PrepareRace2() sin switch. Gjorde ForceInput() mer fleksibel isteden.
            /*
            switch (UserInput.ToLower())
            {
                case "mercedes":
                case "volvo":
                    return UserInput;
                default:
                    //Console.WriteLine("Invalid car!");
                    return ForceInput();
            }
            */
        }

        /*
        private static string ForceInput()
        {
            string UserInput = Console.ReadLine() ?? String.Empty;
            return UserInput.ToLower() switch
            {
                "mercedes" or "volvo" => UserInput,
                _ => ForceInput(),
            };
        }
        */
    }
}
