public interface ICharacter
{
    int Health { get; set; }
    int ArmorClass { get; set; }
    int Attack(ICharacter target);
    void ReceiveDamage(int damage);
    bool IsAlive();
    void AddToInventory(Item item);
    Item GetBestWeapon();
}
