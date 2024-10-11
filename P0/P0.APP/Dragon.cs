using System.Text.Json;
using System.Collections.Generic;
using System.IO;

public class Dragon
{
    // Properties
    public string? Name { get; set; }
    public string? Weakness { get; set; }

    // Constructor
    public Dragon(string name, string weakness)
    {
        Name = name;
        Weakness = weakness;
    }

    // Defeat method
    public bool Fight(Hero hero)
    {
        // Check if the hero has the dragon's weakness
        bool heroWins = hero.Helm2.Name == this.Weakness || hero.Greave.Name == this.Weakness || hero.Chest.Name == this.Weakness;

         string filePath = "heroes.json";
        List<Hero> heroes = new List<Hero>();

        // Deserialize existing heroes from JSON file if it exists
        if (File.Exists(filePath))
        {
            string existingJsonString = File.ReadAllText(filePath);
            heroes = JsonSerializer.Deserialize<List<Hero>>(existingJsonString) ?? new List<Hero>();
        }

        // Check if the hero with the entered name exists
        Hero? existingHero = heroes.Find(h => h.Name == hero.Name);
        if (existingHero != null)
        {
            // Update the existing hero's data
            if (heroWins)
            {
                existingHero.Wins++;
            }
            else
            {
                existingHero.Losses++;
            }
        }
        else
        {
            // Add the new hero to the list
            if (heroWins)
            {
                Console.WriteLine("Congratulations! You defeated the dragon!");
                hero.Wins++;
            }
            else
            {
                Console.WriteLine("You were defeated by the dragon....");
                hero.Losses++;
            }
            heroes.Add(hero);
        }

        // Serialize the updated list of heroes back to the JSON file
        string updatedJsonString = JsonSerializer.Serialize(heroes);
        File.WriteAllText(filePath, updatedJsonString);
        Console.WriteLine($"Hero data saved to {filePath}");

        // Return true or false based on the outcome of the fight
        return heroWins;

    }

    public void selectDragon(Dragon[] dragonArray, Hero hero)
    {
        Console.WriteLine("Which Dragon would you like to challenge? (Please enter 1, 2, or 3)\n1. Fire Dragon\n2. Odd Dragon\n3. Earth Dragon\n");

        string? dragonInput = Console.ReadLine();
        int dragonAnswer;
        try
        {
            dragonAnswer = Convert.ToInt32(dragonInput);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
            return; // Exit the method if input is invalid
        }

        // Check if the user input is valid
        if (dragonAnswer < 1 || dragonAnswer > 3)
        {
            Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
        }
        else
        {
            // Call the Fight method from the Dragon class
            dragonArray[dragonAnswer - 1].Fight(hero); // Adjusting for 0-based index
        }
    }
}