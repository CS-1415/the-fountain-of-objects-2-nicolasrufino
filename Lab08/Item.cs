public class Item
{
    public string Name { get; set; }
    public int Damage { get; set; } 

    public Item(string name, int damage)
    {
        Name = name;
        Damage = damage;
    }
}
