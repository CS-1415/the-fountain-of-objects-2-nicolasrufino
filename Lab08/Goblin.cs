public class Goblin : IMonster
{
    public string Name => "Goblin";
    public int Health { get; set; }
    public int Defense { get; set; }
    public Item Weapon { get; set; }

    public Goblin()
    {
        Health = 30;
        Defense = 12;
        Weapon = new Item("Goblin Sword", 3);
    }

    public void Attack(Player player)
    {
        int roll = new Random().Next(1, 21); 
        if (roll >= player.Defense)
        {
            int damage = new Random().Next(Weapon.Damage, Weapon.Damage + 4); 
            player.Health -= damage;
            Console.WriteLine($"The Goblin attacks you for {damage} damage.");
        }
        else
        {
            Console.WriteLine("The Goblin's attack missed!");
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}
