using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Transform parentAfterDrag;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / transform.root.localScale.x;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;


        Vector3 dropPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dropPosition.z = 0f;


        Collider2D[] colliders = Physics2D.OverlapPointAll(dropPosition);

        foreach (Collider2D collider in colliders)
        {
         
            if (collider.CompareTag("Keybox"))
            {

                Debug.Log("알맞는 사물을 찾았습니다!");
       
                break;
            }
        }

        
        transform.SetParent(parentAfterDrag);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
    }
}