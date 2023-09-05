using System.Collections.Generic;
using UnityEngine;

namespace InventorySystemSetup
{
    public class InventorySystem : MonoBehaviour
    {
        public InventoryHolder InventoryHolder { get; private set; }

        private void Awake()
        {
            InventoryHolder = GetComponent<InventoryHolder>();

            if (InventoryHolder == null)
            {
                Debug.LogError("No InventoryHolder component found on the GameObject.");
                // You might also want to add some logic to create an InventoryHolder instance if not found.
            }
        }

        public bool AddItemToInventory(InventoryItem item, int quantity)
        {
            return InventoryHolder?.AddItemToInventory(item, quantity) ?? false;
        }

        public void UseItem(int slotIndex, PlayerStats playerStats, int quantity)
        {
            InventoryHolder?.UseItem(slotIndex, playerStats, quantity);
        }

        public IReadOnlyList<InventorySlot> GetInventorySlots()
        {
            return InventoryHolder?.GetInventorySlots();
        }
    }
}
