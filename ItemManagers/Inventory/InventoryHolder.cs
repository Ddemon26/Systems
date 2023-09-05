using System.Collections.Generic;
using UnityEngine;

namespace InventorySystemSetup
{
    public class InventoryHolder : MonoBehaviour
    {
        [SerializeField]
        private InventoryManager inventoryManager;

        public InventoryManager InventoryManager => inventoryManager;

        public void Awake()
        {
            if (inventoryManager == null)
            {
                Debug.LogError("Inventory Manager is not assigned to Inventory Holder.");
                // You might want to create a default InventoryManager instance here as a fallback.
            }
        }

        public bool AddItemToInventory(InventoryItem item, int quantity)
        {
            return inventoryManager?.AddItemToInventory(item, quantity) ?? false;
        }

        public void UseItem(int slotIndex, PlayerStats playerStats, int quantity)
        {
            inventoryManager?.UseItem(slotIndex, playerStats, quantity);
        }

        public IReadOnlyList<InventorySlot> GetInventorySlots()
        {
            return inventoryManager?.InventorySlots;
        }
    }
}
