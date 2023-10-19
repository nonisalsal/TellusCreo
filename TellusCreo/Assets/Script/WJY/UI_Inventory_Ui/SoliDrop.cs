using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SoliDrop : MonoBehaviour, IDropHandler
{
    public GameObject itemItemObject; // "ItemItem" 오브젝트를 인스펙터에서 할당

    public void OnDrop(PointerEventData eventData)
    {
        // 드래그한 객체가 있으면
        if (eventData.pointerDrag != null)
        {
            // 드롭 영역에 있는 객체의 이름을 확인하여 "SoliItem"인지 검사
            if (eventData.pointerDrag.CompareTag("Soli"))
            {
                // "ItemItem" 오브젝트의 SetActive를 true로 변경하여 활성화
                itemItemObject.SetActive(true);
            }
        }
    }
}