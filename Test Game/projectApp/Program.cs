class ProjectApp
{
    public static void Main(String[] args)
    {
        string[] options = { "rock", "paper", "scissors" };
        Random random = new Random();
        bool Winner = false;

        while (!Winner)
        {
            int randomNum = random.Next(0, 3);
            Console.WriteLine($"{randomNum} " + options[randomNum]);
            Console.WriteLine("---- Choose Rock, Paper or Scissors ----");
            string? userInput = Console.ReadLine();

            if (userInput?.ToLower() != "rock" && userInput?.ToLower() != "paper" && userInput?.ToLower() != "scissors")
            {
                Console.WriteLine("---- Please select an option from above. ----");
            }
            else
            {
                string? choice = userInput.ToLower();
                if (choice == options[randomNum])
                {
                    Console.WriteLine("---- It's a tie! ----");
                }
                else if (choice == "rock" && randomNum != 1 ||
                 (choice == "paper" && randomNum != 2) ||
                (choice == "scissors" && randomNum != 0))
                {
                    Console.WriteLine("---- You win! ----");
                    Winner = true;
                } else {
                    Console.WriteLine("---- You lose! ----");
                }
            }
        }








    }
}