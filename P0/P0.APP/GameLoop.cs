using System.Text.Json;
public class GameLoop
{
    private Helm2[] helmArray;
    private Greave[] greaveArray;
    private Chest[] chestArray;
    private Dragon[] dragonArray;

    public GameLoop()
    {
        // Create helm objects
        Helm2 goldHelm = new Helm2 { Color = "Gold", Name = "Golden Helm", Weight = 1 };
        Helm2 wornHelm = new Helm2 { Color = "Brown", Name = "Worn Helm", Weight = 2 };
        Helm2 leadHelm = new Helm2 { Color = "Black", Name = "Lead Helm", Weight = 3 };

        // Create chest objects
        Chest goldChest = new Chest { Color = "Gold", Name = "Golden Chestplate", Weight = 1 };
        Chest wornChest = new Chest { Color = "Brown", Name = "Worn Chestplate", Weight = 2 };
        Chest leadChest = new Chest { Color = "Black", Name = "Lead Chestplate", Weight = 3 };

        // Create greave objects
        Greave goldGreave = new Greave { Color = "Gold", Name = "Golden Greaves", Weight = 1 };
        Greave wornGreave = new Greave { Color = "Brown", Name = "Worn Greaves", Weight = 2 };
        Greave leadGreave = new Greave { Color = "Black", Name = "Lead Greaves", Weight = 3 };

        // Create dragon objects
        Dragon fireDragon = new Dragon("Fire Dragon", "Golden Helm");
        Dragon oddDragon = new Dragon("Odd Dragon", "Worn Chestplate");
        Dragon earthDragon = new Dragon("Earth Dragon", "Lead Greaves");

        // Create arrays of equipment and dragons
        helmArray = new Helm2[] { goldHelm, wornHelm, leadHelm };
        greaveArray = new Greave[] { goldGreave, wornGreave, leadGreave };
        chestArray = new Chest[] { goldChest, wornChest, leadChest };
        dragonArray = new Dragon[] { fireDragon, oddDragon, earthDragon };
    }

    //Runs the core game loop
    public void Run()
    {
        // Ask user for their name
        string? userName = null;
        while (string.IsNullOrEmpty(userName))
        {
            Console.WriteLine("What is your name?\n");
            userName = Console.ReadLine();
            if (string.IsNullOrEmpty(userName))
            {
                Console.WriteLine("Please enter a valid name.");
            }
        }

        bool looping = true;
        while (looping)
        {
            // Create objects so we can call the loop functions
            Helm2 helmLoop = new Helm2();
            Greave greaveLoop = new Greave();
            Chest chestloop = new Chest();

            // Call loop method from classes to interact with user & pass in the Array into the method
            Helm2 finalHelmSelection = helmLoop.HelmLoop(helmArray);
            Greave finalGreaveSelection = greaveLoop.GreaveLoop(greaveArray);
            Chest finalChestSelection = chestloop.ChestLoop(chestArray);

            Hero newHero = new Hero(userName, finalHelmSelection, finalGreaveSelection, finalChestSelection);

            //UI text
            Console.WriteLine($"--- Hero Created! ---\nName: {userName}\nEquipment chosen:\n" + $"1.){newHero.Helm2.Name}\n2.){newHero.Greave.Name}\n3.){newHero.Chest.Name}\n");
            Console.WriteLine("---------------------------------------------------------------------------\n" +
            "Before you embark on your journey, heed these ancient whispers:\n" +
            "- In the face of scorching heat, only that which shines brighter may endure. - Helmeticus\n" +
            "- An odd soul fears not strength, but rather the familiar touch of time's passage. - Chestonclius\n" +
            "- The weight of the world is best met by one who knows a similar burden. - Greaviticus\n" +
            "---------------------------------------------------------------------------\n");

            int dragonChoice = -1;
            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("Which Dragon would you like to challenge? (Please enter 1, 2, or 3)\n1.) Fire Dragon\n2.) Odd Dragon\n3.) Earth Dragon\n");
                string? input = Console.ReadLine();

                //Parses the input to an int and checks validity
                if (int.TryParse(input, out dragonChoice) && (dragonChoice == 1 || dragonChoice == 2 || dragonChoice == 3))
                {
                    validInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
                }
            }

            // Proceed with the selected dragon
            switch (dragonChoice)
            {
                case 1:
                    Console.WriteLine("You have chosen to challenge the Fire Dragon!");
                    dragonArray[dragonChoice - 1].Fight(newHero);
                    break;
                case 2:
                    Console.WriteLine("You have chosen to challenge the Odd Dragon!");
                    dragonArray[dragonChoice - 1].Fight(newHero);
                    break;
                case 3:
                    Console.WriteLine("You have chosen to challenge the Earth Dragon!");
                    dragonArray[dragonChoice - 1].Fight(newHero);
                    break;
            }

            // Ask user if they would like to play again
            Console.WriteLine("Would you like to play again? (Y/N)");
            string? playAgain = Console.ReadLine();
            if (playAgain?.ToUpper() == "N")
            {
                looping = false;
            }
        }
    }

    // Show the heroes and their scores
    public void ShowHeroes()
    {
        // Deserialize the JSON file and place it in a list of heroes
        List<Hero> heroes = new List<Hero>();
        string filePath = "heroes.json";
        if (File.Exists(filePath))
        {
            string existingJsonString = File.ReadAllText(filePath);
            heroes = JsonSerializer.Deserialize<List<Hero>>(existingJsonString) ?? new List<Hero>();
            foreach (Hero hero in heroes)
            {
                Console.WriteLine($"{hero.Name}: Wins {hero.Wins} Losses {hero.Losses}" + "\n");
            }
            Console.WriteLine("JSON DATA: " + existingJsonString + "\n");
        }

        //ShowHeroes submenu
        Console.WriteLine("--- Menu ---\n1. New Game\n2. Exit");

        bool validInput = false;
        while (!validInput)
        {
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
                        gameloop.Run();
                        break;
                    case 2:
                        Console.WriteLine("--- Exiting Program ---\n");
                        validInput = true;
                        return;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input.\nPlease enter 1.) for New Game, or 2.) to Exit.");
            }
        }
    }
}