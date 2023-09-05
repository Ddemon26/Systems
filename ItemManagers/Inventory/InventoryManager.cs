using UnityEngine;
using System.Collections.Generic;

namespace InventorySystemSetup
{
    [CreateAssetMenu(fileName = "InventoryManager", menuName = "InventorySystem/InventoryManager", order = 1)]
    public class InventoryManager : ScriptableObject
    {
        [SerializeField]
        private int maxInventorySlots = 20; // Adjust as needed
        [SerializeField] List<InventorySlot> inventorySlots = new List<InventorySlot>();

        public IReadOnlyList<InventorySlot> InventorySlots => inventorySlots.AsReadOnly();

        private void OnEnable()
        {
            inventorySlots = new List<InventorySlot>(maxInventorySlots);
            for (int i = 0; i < maxInventorySlots; i++)
            {
                inventorySlots.Add(null);
            }
        }

        public bool AddItemToInventory(InventoryItem item, int quantity)
        {
            for (int i = 0; i < inventorySlots.Count; i++)
            {
                if (inventorySlots[i] == null)
                {
                    inventorySlots[i] = new InventorySlot(item, quantity);
                    return true;
                }

                if (inventorySlots[i].CanAddItem(item))
                {
                    int spaceLeft = item.maxStackSize - inventorySlots[i].Quantity;
                    if (spaceLeft >= quantity)
                    {
                        inventorySlots[i].AddItem(quantity);
                        return true;
                    }
                    else
                    {
                        inventorySlots[i].AddItem(spaceLeft);
                        quantity -= spaceLeft;
                    }
                }
            }

            // Inventory is full, and couldn't add the item
            return false;
        }

        public void UseItem(int slotIndex, PlayerStats playerStats, int quantity)
        {
            if (slotIndex >= 0 && slotIndex < inventorySlots.Count && inventorySlots[slotIndex] != null)
            {
                inventorySlots[slotIndex].Item.Use(playerStats, quantity);
                inventorySlots[slotIndex].RemoveItem(quantity);

                if (inventorySlots[slotIndex].Quantity == 0)
                {
                    inventorySlots[slotIndex] = null; // Remove the item slot if the quantity is zero
                }
            }
        }
    }
}
