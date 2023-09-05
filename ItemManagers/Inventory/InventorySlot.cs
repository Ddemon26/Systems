using UnityEngine;

namespace InventorySystemSetup
{
    public class InventorySlot
    {
        public InventoryItem Item { get; private set; }
        public int Quantity { get; private set; }

        public InventorySlot(InventoryItem item, int quantity)
        {
            Item = item;
            Quantity = Mathf.Clamp(quantity, 0, item.maxStackSize);
        }

        public bool CanAddItem(InventoryItem itemToAdd)
        {
            return Item == itemToAdd && Quantity < itemToAdd.maxStackSize;
        }

        public void AddItem(int quantityToAdd)
        {
            Quantity = Mathf.Clamp(Quantity + quantityToAdd, 0, Item.maxStackSize);
        }

        public void RemoveItem(int quantityToRemove)
        {
            Quantity = Mathf.Clamp(Quantity - quantityToRemove, 0, Item.maxStackSize);
        }
    }
}
