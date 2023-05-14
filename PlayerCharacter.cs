public class PlayerCharacter : Character
{
    // Available spots for the player character
    public enum Spot
    {
        Front,
        Middle,
        Back
    }

    // Current spot of the player character
    public Spot currentSpot;

    // The currently equipped weapon
    public Weapon equippedWeapon;

    // Maximum action points the player character can spend in a turn
    public int maxActionPoints;

    // Remaining action points for the current turn
    private int remainingActionPoints;

    // Player statistics
    public int attackDamage;
    public int defense;
    public int rangedAttackDamage;
    public int rangedDefense;
    public float rangedDamageModifier;
    public float meleeDamageModifier;
    public int dodge;
    public float lifesteal;
    public float recycle;
    public int inventorySize;

    // Player inventory
    public List<Item> inventory = new List<Item>();

    // ... other player statistics ...

    private void Update()
    {
        // Player character-specific logic and behavior
    }

    public void MoveForward()
    {
        // Move the player character forward to the next available spot
        switch (currentSpot)
        {
            case Spot.Front:
                // Unable to move forward from the front spot
                break;
            case Spot.Middle:
                currentSpot = Spot.Front;
                UseActionPoint();
                break;
            case Spot.Back:
                currentSpot = Spot.Middle;
                UseActionPoint();
                break;
        }
    }

    public void MoveBackward()
    {
        // Move the player character backward to the previous available spot
        switch (currentSpot)
        {
            case Spot.Front:
                currentSpot = Spot.Middle;
                UseActionPoint();
                break;
            case Spot.Middle:
                currentSpot = Spot.Back;
                UseActionPoint();
                break;
            case Spot.Back:
                // Unable to move backward from the back spot
                break;
        }
    }

    public void ChangeWeapon(Weapon newWeapon)
    {
        equippedWeapon = newWeapon;
    }

    public void UseAbility(int abilityIndex)
    {
        // Check if the current spot allows the use of the selected ability
        if (abilityIndex >= 0 && abilityIndex < equippedWeapon.abilities.Count)
        {
            var selectedAbility = equippedWeapon.abilities[abilityIndex];
            if (currentSpot == selectedAbility.requiredSpot)
            {
                // Perform the selected ability
                selectedAbility.Use();
                UseActionPoint();
            }
        }
    }

    public void UseActionPoint()
    {
        remainingActionPoints--;

        if (remainingActionPoints <= 0)
        {
            // End the player's turn or perform any necessary actions
            // Reset remainingActionPoints for the next turn
            remainingActionPoints = maxActionPoints;
            GameManager.Instance.EndPlayerTurn();
        }
    }

    public void AddToInventory(Item item)
    {
        if (item is Gold)
        {
            // Handle gold separately, it doesn't consume inventory slots
            // Handle gold logic here...
        }
        else if (inventory.Count < inventorySize)
        {
            inventory.Add(item);
            // Handle regular items added to the inventory here...
        }
        else
        {
            // Inventory is full, handle full inventory logic here...
        }
    }

    public void RemoveFromInventory(Item item)
    {
        inventory.Remove(item);
    }


    public override void TakeTurn()
    {
        // Called when it's the player's turn to act
        // Implement your turn-based logic here

        // Example: Player selects an ability to use
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseAbility(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseAbility(1);
        }

        // Example: Player moves forward or backward
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveForward();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            MoveBackward();
        }
    }
}

public class Weapon : MonoBehaviour
{
    // Abilities associated with the weapon
    public List<Ability> abilities = new List<Ability>();
}

public class Ability
{
    // Required spot to use the ability
    public PlayerCharacter.Spot requiredSpot;

    public void Use()
    {
        // Perform the ability's action
    }
}
