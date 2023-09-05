using UnityEngine;

public enum Ammo
{
    Pistol,
    Shotgun,
    Rifle,
    Sniper
}

namespace InventorySystemSetup
{
    [CreateAssetMenu(fileName = "AmmoItem", menuName = "ScriptableObjects/InventoryItem/AmmoSO")]
    public class AmmoSO : InventoryItem
    {
        public Ammo Ammo;

        public override void Use(PlayerStats playerStats, int quantity)
        {
            switch (Ammo)
            {
                case Ammo.Pistol:
                    playerStats.AddAmmo(PlayerStats.AmmoType.Pistol, quantity);
                    break;
                case Ammo.Shotgun:
                    playerStats.AddAmmo(PlayerStats.AmmoType.Shotgun, quantity);
                    break;
                case Ammo.Rifle:
                    playerStats.AddAmmo(PlayerStats.AmmoType.Rifle, quantity);
                    break;
                case Ammo.Sniper:
                    playerStats.AddAmmo(PlayerStats.AmmoType.Sniper, quantity);
                    break;
                default:
                    Debug.LogWarning($"Unknown ammo type: {Ammo}");
                    break;
            }
        }

    }
}
