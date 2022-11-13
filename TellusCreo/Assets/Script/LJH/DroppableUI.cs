using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class DroppableUI : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{ 
    private Image image;
    private RectTransform rect;

    private void Awake()
    {
        image = GetComponent<Image>();
        rect = GetComponent<RectTransform>();
    }

public void OnPointerEnter(PointerEventData eventData)
{
    // 아이템 슬롯의 색상을 노란색으로 변경
    //image.color = Color.yellow;
}

public void OnPointerExit(PointerEventData eventData)
{
    // 아이템 슬롯의 색상을 하얀색으로 변경
    //	image.color = Color.white;
}




public void OnDrop(PointerEventData eventData)
    {
         
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
        }
    }
    // Start is called before the first frame update
    
}
