public class Player
{
    public int Row { get; set; }
    public int Column { get; set; }
    public int Health { get; set; }
    public int Defense { get; set; }
    public Item Weapon { get; set; }

    public Player(int row, int column)
    {
        Row = row;
        Column = column;
        Health = 100;
        Defense = 10; 
        Weapon = new Item("Fist", 1); 
    }

    public void Attack(IMonster monster)
    {
        if (Weapon != null)
        {
            int roll = new Random().Next(1, 21);
            if (roll >= monster.Defense)
            {
                int damage = new Random().Next(Weapon.Damage, Weapon.Damage + 4); 
                monster.TakeDamage(damage);
                Console.WriteLine($"You attack the {monster.Name} for {damage} damage.");
                if (monster.Health <= 0)
                {
                    Console.WriteLine($"You defeated the {monster.Name}!");
                    if (monster.Weapon != null && monster.Weapon.Damage > Weapon.Damage)
                    {
                        Weapon = monster.Weapon; 
                        Console.WriteLine($"You acquired a better weapon: {Weapon.Name}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Your attack missed!");
            }
        }
        else
        {
            Console.WriteLine("You have no weapon to attack with.");
        }
    }
}
