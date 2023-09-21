using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public InventoryManager itemData;// ScriptableObject 인스턴스

    private void Awake()
    {
        Instance = this;
    }

    // ScriptableObject 인스턴스를 가져오는 메서드
    public InventoryManager GetItemData()
    {
        return itemData;
    }
}