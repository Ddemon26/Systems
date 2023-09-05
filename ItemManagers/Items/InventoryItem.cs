using UnityEngine;

namespace InventorySystemSetup
{
    public abstract class InventoryItem : ScriptableObject
    {
        public string itemId;
        public string itemName;
        public int itemPrice;
        public Sprite itemIcon;
        public GameObject itemObject;
        public int maxStackSize = 50;
        [TextArea]
        public string Description;

        private int _quantity;

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = Mathf.Clamp(value, 0, maxStackSize);
            }
        }

        public abstract void Use(PlayerStats playerStats, int quantity);
    }
}
