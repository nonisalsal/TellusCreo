using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string itemName;
    public Sprite itemImage;

    public ItemData(Item item)
    {
        itemName = item.itemName;
        itemImage = item.icon;
    }
}