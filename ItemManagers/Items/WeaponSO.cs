using UnityEngine;

public enum AmmoType
{
    Pistol,
    Shotgun,
    Rifle,
    Sniper
}

namespace InventorySystemSetup
{
    [CreateAssetMenu(fileName = "WeaponItem", menuName = "ScriptableObjects/InventoryItem/WeaponSO")]
    public class WeaponSO : InventoryItem
    {
        public int Condition;
        public bool HasAmmo;
        public AmmoType AmmoType;
        public int AmmoAmount;

        // Implement the Use method here
        public override void Use(PlayerStats playerStats, int quantity)
        {

            Debug.Log($"Using weapon {itemName} with condition: {Condition}");
        }
    }
}
