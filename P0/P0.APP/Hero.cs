public class Hero
{
    public string Name { get; set; } = " ";
    public Helm2 Helm2 { get; set; }
    public Greave Greave { get; set; }
    public Chest Chest { get; set; }
    public int Wins { get; set; }
    public int Losses { get; set; }
    // Constructor
    public Hero(string name, Helm2 helm2, Greave greave, Chest chest)
    {
        Name = name;
        Helm2 = helm2;
        Greave = greave;
        Chest = chest;
        Wins = 0;
        Losses = 0;
    }

    public void AddWin()
    {
        Wins++;
    }

    public void AddLoss()
    {
        Losses++;
    }
}