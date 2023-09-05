using UnityEngine;

namespace InventorySystemSetup
{
    [CreateAssetMenu(fileName = "HealhItem", menuName = "ScriptableObjects/InventoryItem/HealthSO")]
    public class HealthSO : InventoryItem
    {
        public int healthAmount;

        public override void Use(PlayerStats playerStats, int quantity)
        {
            int totalHealthToAdd = healthAmount * quantity;
            playerStats.AddAmountToAttribute(PlayerStats.PlayerAttribute.Health, totalHealthToAdd);

            Debug.Log($"Used health item: {itemName}. Increased health by: {totalHealthToAdd}");
        }

    }
}
