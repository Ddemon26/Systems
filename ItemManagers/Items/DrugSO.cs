using UnityEngine;

namespace InventorySystemSetup
{
    [CreateAssetMenu(fileName = "DrugItem", menuName = "ScriptableObjects/InventoryItem/DrugSO")]
    public class DrugSO : InventoryItem
    {
        public int HealthAmount;
        public float StaminaAmount;

        public override void Use(PlayerStats playerStats, int quantity)
        {
            int totalHealthToRestore = HealthAmount * (int)quantity;
            float totalStaminaToRestore = StaminaAmount * (int)quantity;

            playerStats.AddAmountToAttribute(PlayerStats.PlayerAttribute.Health, totalHealthToRestore);
            playerStats.RestoreStamina(totalStaminaToRestore);
        }
    }
}
