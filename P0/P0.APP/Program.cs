using System.Text.Json;

class Program
{
    public static void Main(string[] args)
    {   // Main menu ASCII art
        Console.WriteLine("(     (                      )     )  (      (            )  \n" +
                         ")\\ )  )\\ )   (     (      ( /(  ( /(( )\\ )   )\\ )      ( /(  \n" +
                         "(()/( (()/(   )\\    )\\ )   )\\()) )\\())(()/(  (()/(  (   )\\()) \n" +
                         " /(_)) /(_)|(((_)( (()/(  ((_\\ ((_)((_)(_))  /(_)) )\\ ((_\\  \n" +
                         "(_))_ (_))  )\\ _ )\\ /(_))_  ((_) _((_)(_))   (_))_ ((_) _((_) \n" +
                         " |   \\| _ \\ (_)_\\(_|_)) __|/ _ \\| \\| |/ __|   |   \\| __| \\| | \n" +
                         " | |) |   /  / _ \\   | (_ | (_) | .` |\\__ \\   | |) | _|| .` | \n" +
                         " |___/|_|_\\ /_/ \\_\\   \\___|\\___/|_|\\_||___/   |___/|___|_|\\_| \n");

        // Main menu loop, while false the loop will continue to run.
        bool validInput = false;
        while (!validInput)
        {
            Console.WriteLine("--- Main Menu ---\n1. New Game\n2. Player Scores\n3. Exit");

            string? userInput = null;
            try
            {
                userInput = Console.ReadLine();
                int newAnswer = Convert.ToInt32(userInput);
                // Switch statement to handle user input
                switch (newAnswer)
                {
                    case 1:
                        Console.WriteLine("--- New Game Selected ---\n");
                        validInput = true;
                        GameLoop gameloop = new GameLoop();
                        Console.Clear();
                        gameloop.Run();
                        break;
                    case 2:
                        Console.WriteLine("--- Player Scores Selected ---\n");
                        validInput = true;
                        GameLoop showloop = new GameLoop();
                        Console.Clear();
                        showloop.ShowHeroes();
                        break;
                    case 3:
                        Console.WriteLine("--- Exiting Program ---\n");
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Invalid input.\nPlease enter 1.) for New Game, 2.) for Load Game, or 3.) to Exit.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input.\nPlease enter 1.) for New Game, 2.) for Load Game, or 3.) to Exit.");
            }
        }
    }
}
