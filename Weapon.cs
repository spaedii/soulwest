public enum WeaponRarity
{
    Common,
    Uncommon,
    Rare,
    Historic
}

public enum WeaponClass
{
    Ranged,
    Melee
}

public enum RangedWeaponType
{
    Shotgun,
    Repeater,
    BoltAction,
    Revolver,
    Pistol,
    Bow
}

public enum MeleeWeaponType
{
    Sword,
    Rapier,
    Dagger,
    Pickaxe
}

public class Weapon
{
    public string name;
    public WeaponRarity rarity;
    public WeaponClass weaponClass;
    public RangedWeaponType rangedWeaponType;
    public MeleeWeaponType meleeWeaponType;
    public int ammunitionCapacity;
    public List<string> bonusStats;

    public string GetColoredName()
    {
        string color = GetRarityColor(rarity);
        return $"<color={color}>{name}</color>";
    }

    private string GetRarityColor(WeaponRarity weaponRarity)
    {
        switch (weaponRarity)
        {
            case WeaponRarity.Common:
                return "white";
            case WeaponRarity.Uncommon:
                return "green";
            case WeaponRarity.Rare:
                return "blue";
            case WeaponRarity.Historic:
                return "gold";
            default:
                return "white";
        }
    }
}
