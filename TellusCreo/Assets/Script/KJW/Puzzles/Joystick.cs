using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Direction { UP, DOWN, LEFT, RIGHT };

public class Joystick : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{


    [SerializeField]
    RectTransform lever;
    RectTransform rectTransform;

    [SerializeField, Range(10f, 150f)]
    float leverRange;

    public ArcadeConsole arcadeConsole;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        arcadeConsole = FindObjectOfType<ArcadeConsole>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        MoveLeverPosition(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        MoveLeverPosition(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        Direction direction = GetDirection(eventData.position - rectTransform.anchoredPosition);
        arcadeConsole.SelectAlphabet(direction); // 드래그 끝날때만
    }

    void MoveLeverPosition(Vector2 position)
    {
        Vector2 direction = position - rectTransform.anchoredPosition;
        Vector2 leverDir = direction.normalized * leverRange;
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)) // 절대값이 x가 더 크면 좌우
        {
            leverDir.y = 0;
        }
        else
        {
            leverDir.x = 0;
        }

        lever.anchoredPosition = leverDir;
    }

    Direction GetDirection(Vector2 inputDirection)
    {
        bool isHorizontal = Mathf.Abs(inputDirection.x) > Mathf.Abs(inputDirection.y); // 좌우 이동인지
        bool isPositive = isHorizontal ? inputDirection.x > 0 : inputDirection.y > 0; // 양의 방향인지
        if (isHorizontal) // 수평
        {
            return isPositive ? Direction.RIGHT : Direction.LEFT;
        }
        else
        {
            return isPositive ? Direction.UP : Direction.DOWN;
        }
    }
}



