
using System.Dynamic;
using System.Net;

namespace Car_Race
{
    internal class CarRace
    {
        public static void InitGame()
        {
            CarUI.GetUI("init");
            string UserInput = Tools.ForceNumber();
            switch (UserInput)
            {
                case"1":
                    PrepareRace1();
                    break;
                case"2":
                    PrepareRace2();
                    break;
                default:
                    Console.WriteLine("Please select the chosen numbers.");
                    Thread.Sleep(1700);
                    InitGame();
                    break;
            }
        }

        private static void PrepareRace1()
        {
            int i = 0;
            CarUI.GetUI("main");

            while (i < 13) 
            {
                i++;
                Console.WriteLine($"Load nr: {i}");
            }

            Console.WriteLine("Preparing the car...");

            TheRace1();
        }

        private static void PrepareRace2()
        {
            CarUI.GetUI("main");

            Console.WriteLine("Please choose the car you wish to use.");
            Console.WriteLine("You may choose between a volvo or a mercedes.");
            string UserInput = Tools.ForceInput();
            switch (UserInput.ToLower())
            {
                case"mercedes":
                    Console.WriteLine($"You chose {UserInput}. Loading race cars...");
                    Thread.Sleep(1700);
                    TheRace2(UserInput);
                    break;
                case"volvo":
                    Console.WriteLine($"You chose {UserInput}. Loading race cars...");
                    Thread.Sleep(1700);
                    TheRace2(UserInput);
                    break;
                default:
                    Console.WriteLine("Not a part of the list of cars available.");
                    Thread.Sleep(990);
                    PrepareRace2();
                    break;
            }
        }

        private static void TheRace1()
        {
            //int CurrentSpeed = CarLogic.GetCurrentSpeed();
            int i = 0;
            int Distance = 0;
            int MinSpeed = 10;
            int CurrentSpeed = MinSpeed;
            CarUI.GetUI("race", CurrentSpeed, i);
            Console.WriteLine($"Distance traveled: {Distance}");

            while (Distance < 500)
            {
                Distance += CurrentSpeed;
                i++;
                /*
                 * 10   -   10m/s
                 * 30   -   20m/s
                 * 60   -   30m/s
                 * 100  -   40m/s
                 * 150  -   50m/s
                 * 210  -   60m/s
                 * 280  -   70m/s
                 * 360  -   80m/s
                 * 450  -   90m/s
                 * 550  -   100m/s
                 */
                CarUI.GetUI("race", CurrentSpeed, i);
                Console.WriteLine($"Distance traveled: {Distance}");
                CurrentSpeed += 10;
                Thread.Sleep(300);
            }

            while (Distance < 1000)
            {
                //Nåværende feil: +100 i begynnelsen
                /*
                 * 550  -  100m/s
                 * 640  -  90m/s
                 * 720  -  80m/s
                 * 790  -  70m/s
                 * 850  -  60m/s
                 * 900  -  50m/s
                 * 940  -  40m/s
                 * 970  -  30m/s
                 * 990  -  20m/s
                 * 1000 -  10m/s
                 */
                CurrentSpeed -= 10;
                i++;
                Distance += CurrentSpeed;
                if (CurrentSpeed < MinSpeed)
                {
                    CurrentSpeed = MinSpeed;
                }
                CarUI.GetUI("race", CurrentSpeed, i);
                Console.WriteLine($"Distance traveled: {Distance}m.");
                Thread.Sleep(300);
            }

            CarUI.GetUI("race", CurrentSpeed, i);
            Console.WriteLine($"Done. You have now gone {Distance}m. You ended up driving {CurrentSpeed}m/s in the end.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            AskForExit();
        }

        private static void TheRace2(string Input)
        {
            int MinSpeed = 10; //Teknisk sett ubrukelig her.
            int CurrentSpeed = MinSpeed; //Teknisk sett ubrukelig her.
            string Opponent = CarLogic.GenerateOpponent(Input);
            Cars a = new(Input, CurrentSpeed);
            Cars b = new(Opponent, CurrentSpeed);
            int Traveled = 0;
            int DisA = 0; //Kunne blitt skrevet inn i constructoren til objektet
            int DisB = 0; //Kunne blitt skrevet inn i constructoren til objektet

            while (Traveled < 10000)
            {
                a.Speed = CarLogic.RandomSpeed();
                b.Speed = CarLogic.RandomSpeed();
                DisA += a.Speed;
                DisB += b.Speed;

                //Her tar den inn bilen som har kjørt raskest og lagt det til i distansen den har reist. Kunne blitt skrevet på en smartere måte
                if (a.Speed < b.Speed) 
                {
                    Traveled += b.Speed;
                }else if (b.Speed < a.Speed)
                {
                    Traveled += a.Speed; 
                }
                if (DisA < DisB)
                {
                    Traveled = DisB;
                }
                else if (DisB < DisA)
                {
                    Traveled = DisA;
                }
                CarUI.GetUI("race");
                Console.WriteLine($"Distance traveled so far: {Traveled}m");
                if (DisA < DisB)
                {
                    Console.WriteLine($"{Opponent} is leading! You're falling behind.");
                }
                else if (DisB < DisA)
                {
                    Console.WriteLine($"{Input} is leading! You're doing great!");
                }
                Console.WriteLine($"You have traveled {DisA}m.");
                Console.WriteLine($"The opponent have traveled {DisB}m.");
                Console.WriteLine("");
                Thread.Sleep (400);
            }
            CarUI.GetUI("race");
            if (DisA < DisB)
            {
                Console.WriteLine($"{Opponent} wins! You lose.");
            }
            else { 
                Console.WriteLine($"{Input} wins! Good job!");
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            AskForExit();
        }

        //Spør bare brukeren om de ønsker å fortsette eller ikke
        private static void AskForExit() 
        {
            CarUI.GetUI("exit");
            string UserInput = Tools.ForceInput();
            switch (UserInput)
            {
                case "yes":
                case "y":
                    InitGame();
                    break;
                case "no": 
                case "n":
                    Console.WriteLine("Shutting down...");
                    Thread.Sleep(800);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input. Try again.");
                    Thread.Sleep(800);
                    AskForExit();
                    break;
            }
        }

        /*
         * Minimum 10m/s
         * Øk med 10m/s per runde frem til 500m
         * Ta det den har økt med frem til 500m, men nå i revers til den har nådd 1000m
         */

        /*
         * Du skal lage en konsollapp med en bil som skal kjøre 1000m. Bilen har en start-hastighet på 10m/s ( en iterasjon i en løkke er et sekund). 
         * Bilen skal øke farten med 10m/s frem til den har kjørt 500m, også skal den senke farten med 10m/s igjen frem til den når minimumshastigheten sin på 10m/s. 
         * Når bilen har kommet seg til slutt-målet printes det ut til skjermen at bilen er fremme og har parkert.
         * 
         * Utvid oppgaven til at du kan lage 2 biler som kjører om kapp i en løkke,
         * der de har en metode som genererer en random hastighet til dem mellom 60-200m/s som varer en runde. 
         * Det er førstemann til å kjøre 10000m
         */
    }
}
