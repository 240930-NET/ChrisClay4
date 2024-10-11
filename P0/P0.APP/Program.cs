using System.Text.Json;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("(     (                      )     )  (      (            )  \n" +
                         ")\\ )  )\\ )   (     (      ( /(  ( /(( )\\ )   )\\ )      ( /(  \n" +
                         "(()/( (()/(   )\\    )\\ )   )\\()) )\\())(()/(  (()/(  (   )\\()) \n" +
                         " /(_)) /(_)|(((_)( (()/(  ((_\\ ((_)((_)(_))  /(_)) )\\ ((_\\  \n" +
                         "(_))_ (_))  )\\ _ )\\ /(_))_  ((_) _((_)(_))   (_))_ ((_) _((_) \n" +
                         " |   \\| _ \\ (_)_\\(_|_)) __|/ _ \\| \\| |/ __|   |   \\| __| \\| | \n" +
                         " | |) |   /  / _ \\   | (_ | (_) | .` |\\__ \\   | |) | _|| .` | \n" +
                         " |___/|_|_\\ /_/ \\_\\   \\___|\\___/|_|\\_||___/   |___/|___|_|\\_| \n");

        bool validInput = false;
        while (!validInput)
        {
            Console.WriteLine("--- Main Menu ---\n1. New Game\n2. Player Scores\n3. Exit");

            string? userInput = null;
            try
            {
                userInput = Console.ReadLine();
                int newAnswer = Convert.ToInt32(userInput);
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
                        Console.WriteLine("Invalid input. Please enter 1 for New Game, 2 for Load Game, or 3 to Exit.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input.\nPlease enter 1.) for New Game, 2.) for Load Game, or 3.) to Exit.");
            }

            //Create helmLoop object so we can call the loop function passing in the "helmArray".












            // //Outfit storage array
            // object[] outfitArray = new object[3];
            // outfitArray[0] = finalHelmSelection.Name;
            // outfitArray[1] = finalGreaveSelection.Name;
            // outfitArray[2] = finalChestSelection.Name;

            // foreach(object i in outfitArray){
            //     Console.WriteLine(i);
            // }
            // //Call loop method from Chestplate class to interact with user & pass in the Array into the method
            // Chest chestLoop = new Chest();
            // chestLoop.ChestLoop(chestArray);
            // //Call loop method from Chestplate class to interact with user & pass in the Array into the method
            // Greave greaveLoop = new Greave();
            // greaveLoop.GreaveLoop(greaveArray);





            // // Loop through the array and print each Helm
            // foreach (Helm2 helm in helmArray)
            // {
            //     Console.WriteLine(helm.Name, helm.Color, helm.Weight);
            // }
        
        }
    }
}
