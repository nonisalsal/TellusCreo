using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> Items = new List<Item>();

    public Transform ItemContent;
    public GameObject InventoryItem;
    private Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();

    public DragAndDrop dragAndDropScript;

    private void Awake()
    {
        Instance = this;

        foreach (Item item in Items)
        {
            itemDictionary[item.itemName] = item;
        }
    }

    public void InstantiateItemAndSetToDragAndDrop(Item itemPrefab)
    {
        Item newItem = Instantiate(itemPrefab);
        newItem.itemName = itemPrefab.itemName; // 아이템 이름을 할당
        newItem.interactTag = itemPrefab.interactTag; // 아이템 태그를 할당
        // dragAndDropScript.item = newItem; // 제거
    }

    public void Add(Item item)
    {
        if (!Items.Contains(item))
        {
            Items.Add(item);
            itemDictionary[item.itemName] = item;
            UpdateInventoryUI(); // 아이템이 추가되었으므로 인벤토리를 갱신
        }
    }

    public void AddItemByName(string itemName)
    {
        if (itemDictionary.TryGetValue(itemName, out Item itemToAdd))
        {
            if (!Items.Contains(itemToAdd))
            {
                Items.Add(itemToAdd);
                UpdateInventoryUI(); // 아이템이 추가되었으므로 인벤토리를 갱신
            }
        }
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
       
        UpdateInventoryUI(); // 아이템이 삭제되었으므로 인벤토리를 갱신
    }
    public void RemoveItemFromInventory(string itemName)
    {
        if (HasItem(itemName))
        {
            Item itemToRemove = itemDictionary[itemName];
            Remove(itemToRemove); // Items 리스트에서 아이템 삭제
            UpdateInventoryUI(); // 인벤토리 UI 갱신
        }
    }
    public void UpdateInventoryUI()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemIcon = obj.transform.Find("Border/ItemIcon").GetComponent<Image>();
            itemIcon.sprite = item.icon;
            
        }
    }

    public bool HasItem(string itemName)
    {
        return itemDictionary.ContainsKey(itemName);
    }

    public void RemoveItem(string itemName)
    {
        if (HasItem(itemName))
        {
            Item itemToRemove = itemDictionary[itemName];
            Items.Remove(itemToRemove);
        }
    }
    public List<Item> GetItems()
    {
        return Items;
    }

    // ListItems 함수는 삭제해도 됩니다.
}