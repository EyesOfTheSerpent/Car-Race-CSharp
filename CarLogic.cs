
namespace Car_Race
{
    internal class CarLogic
    {
        //Vurderte dette først, men tenkte at det ble unødvendig.
        /*
        private static readonly int _minSpeed = 10;
        private static int _CurrentSpeed = _minSpeed;
        private int _Laps = 0;

        public static int GetCurrentSpeed()
        {
            return _CurrentSpeed;
        }

        public static void AdjustSpeed(int amount, bool AddOrSub)
        {
            if (!AddOrSub)
            {
                _CurrentSpeed -= amount;
            }
            else
            {
                _CurrentSpeed += amount;
            }
        }
        */
        
        //Genererer et nummber mellom 60 til 200.
        public static int RandomSpeed()
        {
            Random rng = new();
            int speed = rng.Next(60, 201);
            return speed;
        }

        //Kunne kanskje ha laget en liste av biler eller ha tillatt brukeren å lage sin egen bil istedenfor dette.
        public static string GenerateOpponent(string YourChoice) 
        {
            string Opponent = "";
            switch (YourChoice.ToLower())
            {
                case "mercedes":
                    Opponent = "Volvo";
                    break;
                case "volvo":
                    Opponent = "Mercedes";
                    break;
            }
            return Opponent;
        }

        //Unødvendig
        /*
        private static void GenerateCars()
        {
            Cars a = new("Mercedes", 10);
            Cars b = new("Volvo", 10);
        }
        */
    }
}
