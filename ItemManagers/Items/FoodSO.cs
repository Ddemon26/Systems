using UnityEngine;

namespace InventorySystemSetup
{
    [CreateAssetMenu(fileName = "FoodItem", menuName = "ScriptableObjects/InventoryItem/FoodSO")]
    public class FoodSO : InventoryItem
    {
        public int HealthAmount;
        public int StaminaAmount;

        public override void Use(PlayerStats playerStats, int quantity)
        {
            // Heal the player by HealthAmount
            if (HealthAmount > 0)
            {
                playerStats.AddAmountToAttribute(PlayerStats.PlayerAttribute.Health, HealthAmount * (int)quantity);
            }
            if (StaminaAmount > 0)
            {
                playerStats.RestoreStamina(StaminaAmount * (int)quantity);
            }

            // Print info for demonstration
            Debug.Log($"Used food item: {itemName}. Increased health by: {HealthAmount * quantity}, Increased stamina by: {StaminaAmount * quantity}");
        }
    }
}
