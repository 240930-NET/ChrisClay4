public class Chest
{
    public string? Color { get; set; }
    public int? Weight { get; set; }
    public string? Name { get; set; }

    public void ChestCreate(string Name, string Color, int Weight)
    {
        this.Name = Name;
        this.Weight = Weight;
        this.Color = Color;
    }

    // Method to handle chest selection logic
    public Chest ChestLoop(Chest[] chestArray)
    {
        bool looping = true;
        int selectedChestIndex = -1;

        while (looping == true)
        {
            // Display the menu
            Console.WriteLine($"Please Select a Chest piece.\n" +
                              $"1.) {chestArray[0].Name}\n" +
                              $"2.) {chestArray[1].Name}\n" +
                              $"3.) {chestArray[2].Name}\n");

            // Read user input
            string? userInput = Console.ReadLine();
            int intValue = 0;

            // Try to convert the input to an integer
            try
            {
                intValue = Convert.ToInt32(userInput);

                // Adjust for zero-based index (decrement after input)
                int adjustedVal = intValue - 1;

                // Check if the value is within the valid range of chestArray
                if (adjustedVal < 0 || adjustedVal >= chestArray.Length)
                {
                    Console.WriteLine("Invalid selection. Please choose a valid option.");
                    continue;  // Restart the loop if invalid selection
                }

                // Confirm the selection
                Console.WriteLine($"\nYou selected: {chestArray[adjustedVal].Name}.\nIs that correct? (Please enter 1 for Yes or 2 for No)\n 1.) Yes\n 2.) No");

                // Read confirmation
                string? confirmationInput = Console.ReadLine();
                int chestAnswer = 0;
                try
                {
                    chestAnswer = Convert.ToInt32(confirmationInput);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter 1 for Yes or 2 for No.");
                    continue;  // Restart the loop for invalid confirmation input
                }

                // Handle the user's confirmation
                if (chestAnswer == 1)
                {
                    selectedChestIndex = adjustedVal;
                    looping = false;  // Exit the loop if confirmed
                }
                else if (chestAnswer == 2)
                {
                    Console.WriteLine("\nLet's try again.");
                    // Continue looping, restarting the selection process
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 1 for Yes or 2 for No.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid selection. Please enter a valid number.");
            }
        }
        
        return chestArray[selectedChestIndex];
    }
}
