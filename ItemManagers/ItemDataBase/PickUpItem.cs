using UnityEngine;

namespace InventorySystemSetup
{
    public class PickUpItem : MonoBehaviour, ICollectable
    {
        public InventoryItem item;
        public int quantity = 1;

        public void Collect(PlayerStats playerStats, InventorySystem inventorySystem)
        {
            if (item is CashSO cashItem)
            {
                cashItem.Use(playerStats, quantity);
                gameObject.SetActive(false);
            }
            else if (item is AmmoSO ammoItem)
            {
                ammoItem.Use(playerStats, quantity);
                gameObject.SetActive(false);
            }
            else
            {
                bool wasAdded = inventorySystem.AddItemToInventory(item, quantity);

                if (wasAdded)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    // You might want to add some feedback here to indicate the inventory is full
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerStats playerStats = collision.GetComponent<PlayerStats>();
            InventorySystem inventorySystem = collision.GetComponent<InventorySystem>();

            if (playerStats != null && inventorySystem != null)
            {
                Collect(playerStats, inventorySystem);
            }
        }
    }
}
