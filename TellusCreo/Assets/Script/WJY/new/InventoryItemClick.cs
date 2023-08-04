using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItemClick : MonoBehaviour, IPointerClickHandler
{
    public Item item; // 해당 슬롯의 아이템을 Inspector 창에서 설정해줍니다.
    public DragAndDrop dragAndDropScript; // DragAndDrop 스크립트를 Inspector 창에서 설정해줍니다.

    public void OnPointerClick(PointerEventData eventData)
    {
        // 아이템이 클릭되었을 때 호출됩니다.
        // DragAndDrop 스크립트의 item 변수에 해당 아이템 객체를 할당합니다.
        dragAndDropScript.item = item;
    }
}