public abstract class Character : MonoBehaviour
{
    // Common properties for both player and enemy characters
    public int health;
    public int attack;
    public int defense;

    // Current weapon equipped by the character
    public Weapon equippedWeapon;

    public abstract void TakeTurn();
}