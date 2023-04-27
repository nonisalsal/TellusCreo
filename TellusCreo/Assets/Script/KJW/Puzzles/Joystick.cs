using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler
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
        UpdateLeverPosition(eventData.position);
    }

    public void OnDrag(PointerEventData eventData)
    {
        UpdateLeverPosition(eventData.position);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        lever.anchoredPosition = Vector2.zero;
        Vector2 inputDirection = eventData.position - rectTransform.anchoredPosition;
        arcadeConsole.SelectAlphabet(inputDirection); // 드래그 끝날때만
    }

    void UpdateLeverPosition(Vector2 position)
    {
        Vector2 inputDir = position - rectTransform.anchoredPosition;
        Vector2 clampedDir = Vector2.zero;
        if (Mathf.Abs(inputDir.x) > Mathf.Abs(inputDir.y)) // 절대값이 x가 더 크면 좌우
        {
            clampedDir = inputDir.normalized * leverRange;
            clampedDir.y = 0;
        }
        else
        {
            clampedDir = inputDir.normalized * leverRange;
            clampedDir.x = 0;
        }

        lever.anchoredPosition = clampedDir;
    }
}


