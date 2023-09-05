using UnityEngine;

namespace InventorySystemSetup
{
    [CreateAssetMenu(fileName = "MiscItem", menuName = "ScriptableObjects/InventoryItem/MiscSO")]
    public class MiscSO : InventoryItem
    {
        public override void Use(PlayerStats playerStats, int quantity)
        {
            // For now, do nothing or add a relevant effect for miscellaneous items.
            Debug.Log($"Used {name} x{quantity}. But it had no specific effect.");
        }
    }
}
