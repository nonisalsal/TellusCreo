using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item Item;


    void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        Destroy(gameObject);
    }
    public void OnItemClick()
    {
        // 클릭한 아이템 정보를 DragAndDrop 스크립트의 item 변수에 할당합니다.
        DragAndDrop dragAndDropScript = FindObjectOfType<DragAndDrop>();
        //if (dragAndDropScript != null)
        //{
        //    dragAndDropScript.SetCurrentItem(Item);
        //}
    }

    private void OnMouseDown()
    {
        Pickup();
    }
}
