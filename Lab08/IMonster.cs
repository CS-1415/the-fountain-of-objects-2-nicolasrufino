public interface IMonster
{
    string Name { get; }
    int Health { get; set; }
    int Defense { get; set; }
    Item Weapon { get; set; }
    void Attack(Player player);
    void TakeDamage(int damage);
}
