using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
{


    [SerializeField]
    KTest test;

    [SerializeField]
    RectTransform lever;
    RectTransform rectTransform;

    Vector2 originLeverPos;
    Vector2 transLeverPos;

    [SerializeField,Range(10,150)]
    float leverRange;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originLeverPos=lever.transform.position;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 inputPos = eventData.position - rectTransform.anchoredPosition;
        Vector2 inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputVector;
      
        
        DragDirection(eventData.position);


    }

    public void OnDrag(PointerEventData eventData)
    {
       
        Vector2 inputPos = eventData.position - rectTransform.anchoredPosition;
        Vector2 inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        lever.anchoredPosition = inputVector;
     
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
    }

    //void DragDirection(Vector2 clickPos)
    //{
      
    //    Debug.Log(clickPos.x-originLeverPos.x);
    //    Debug.Log("x:"+clickPos.x);
    //    if (originLeverPos.x< clickPos.x &&
    //        (Mathf.Abs(clickPos.y -originLeverPos.y)<=4f)) // 오른쪽
    //    {
    //        test.NextBT();
    //    }
    //    else if(originLeverPos.x > clickPos.x) // 왼쪽 
    //    {
           
    //    }
    //    else if(originLeverPos.y < clickPos.y &&
    //        (Mathf.Abs(clickPos.x - originLeverPos.x) <= 5f)) // 위
    //    {
    //        test.UPDOWN(KTest.State.UP);
    //        Debug.Log("Up");
    //    }
    //    else if(originLeverPos.y > clickPos.y) // 아래
    //    {
    //        test.UPDOWN(KTest.State.DOWN);
    //        Debug.Log("Down");

    //    }
    //}

    void DragDirection(Vector2 clickPos)
    {
        float xDiff = clickPos.x - originLeverPos.x;
        float yDiff = clickPos.y - originLeverPos.y;

        if (Mathf.Abs(xDiff) >= Mathf.Abs(yDiff))
        {
            if (xDiff > 0)
            {
                test.NextBT();
            }
            else
            {
                // Left direction
            }
        }
        else
        {
            if (yDiff > 0)
            {
                test.UPDOWN(KTest.State.UP);
            }
            else
            {
                test.UPDOWN(KTest.State.DOWN);
            }
        }
    }
}


