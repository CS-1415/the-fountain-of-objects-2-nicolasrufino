public class Weapon
{
    public string Name { get; set; }
    public int MinDamage { get; set; }
    public int MaxDamage { get; set; }

    public Weapon(string name, int minDamage, int maxDamage)
    {
        Name = name;
        MinDamage = minDamage;
        MaxDamage = maxDamage;
    }

    public int GetDamage()
    {
        Random rand = new Random();
        return rand.Next(MinDamage, MaxDamage + 1);
    }
}
