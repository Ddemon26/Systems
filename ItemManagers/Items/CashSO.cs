using UnityEngine;

namespace InventorySystemSetup
{
    [CreateAssetMenu(fileName = "CashItem", menuName = "ScriptableObjects/InventoryItem/CashSO")]
    public class CashSO : InventoryItem
    {
        public int cashAmount;

        public override void Use(PlayerStats playerStats, int quantity)
        {
            int totalCashToAdd = cashAmount * (int)quantity;
            playerStats.AddAmountToAttribute(PlayerStats.PlayerAttribute.Cash, totalCashToAdd);
        }

    }
}
