//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;


//public class InventoryManager : MonoBehaviour
//{
//    public static InventoryManager Instance;
//    public List<Item> Items = new List<Item>();

//    public Transform ItemContent;
//    public GameObject InventoryItem;
//    private Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>(); // 아이템 이름과 아이템을 연결하는 Dictionary

//    private void Awake()
//    {
//        Instance = this;
//        // Dictionary에 아이템 이름과 아이템을 연결합니다.
//        foreach (Item item in Items)
//        {
//            if (item != null)
//            {
//                itemDictionary[item.itemName] = item;
//            }
//        }
//    }


//    public void Add(Item item)
//    {
//        Items.Add(item);
//    }

//    public void Remove(Item item)
//    {
//        Items.Remove(item);
//    }

//    public void ListItems()
//    {
//        foreach(Transform item in ItemContent)
//        {
//            Destroy(item.gameObject);
//        }

//        foreach (var item in Items)
//        {
//            GameObject obj = Instantiate(InventoryItem, ItemContent);
//            var itemIcon =  obj.transform.Find("ItemIcon").GetComponent<Image>();
//            itemIcon.sprite = item.icon;

//        }
//    }
//}

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
    private Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>(); // 아이템 이름과 아이템을 연결하는 Dictionary

    public DragAndDrop dragAndDropScript;

    private void Awake()
    {
        Instance = this;
        // Dictionary에 아이템 이름과 아이템을 연결합니다.
        foreach (Item item in Items)
        {
            if (item != null)
            {
                itemDictionary[item.itemName] = item;
            }
        }
    }
    public void InstantiateItemAndSetToDragAndDrop(Item itemPrefab)
    {
        // 인스턴스화된 아이템을 생성하고, DragAndDrop 스크립트에 할당합니다.
        Item newItem = Instantiate(itemPrefab);
        dragAndDropScript.item = newItem;
    }

    public void Add(Item item)
    {
        if (!Items.Contains(item))
        {
            Items.Add(item);
            itemDictionary[item.itemName] = item; // itemDictionary에도 추가
        }
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
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

    public void ListItems()
    {
        foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            itemIcon.sprite = item.icon;
        }
    }
}
