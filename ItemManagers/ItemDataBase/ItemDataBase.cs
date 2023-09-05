using UnityEngine;
using System.Collections.Generic;

namespace InventorySystemSetup
{
    public class ItemDatabase : MonoBehaviour
    {
        public static ItemDatabase Instance { get; private set; }
        public List<InventoryItem> ItemList;
        private readonly Dictionary<string, InventoryItem> itemCache = new();
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
                return;
            }
            BuildItemCache();
        }
        private void BuildItemCache()
        {
            foreach (InventoryItem item in ItemList)
            {
                if (string.IsNullOrEmpty(item.itemId))
                {
                    Debug.LogError("An item in the list does not have an item ID");
                    continue;
                }
                if (!itemCache.ContainsKey(item.itemId))
                {
                    itemCache.Add(item.itemId, item);
                }
                else
                {
                    Debug.LogWarning("Duplicate Item ID: " + item.itemId);
                }
            }
        }
        public InventoryItem GetItemById(string itemId)
        {
            if (itemCache.TryGetValue(itemId, out InventoryItem item))
            {
                return item;
            }
            Debug.LogWarning("Item not found: " + itemId);
            return null;
        }
    }
}