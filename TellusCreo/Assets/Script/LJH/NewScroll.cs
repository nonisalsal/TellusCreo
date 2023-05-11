using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewScroll : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public RectTransform content;
    public int numSlots;
    public float spacing;
    public float scrollSpeed;

    private Vector2 scrollDirection;
    private Vector2 dragStartPosition;
    void Start()
    {
        // 스크롤 방향 계산
        scrollDirection = new Vector2(0.0f, 1.0f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 드래그한 거리에 따라 이미지 이동
        float distance = eventData.position.y - dragStartPosition.y;
        content.localPosition += Vector3.Scale(scrollDirection, new Vector3(0, distance, 0));
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // 이미지가 슬롯 머신의 범위를 벗어나지 않도록 조정
        float maxPosition = (numSlots - 1) * spacing;
        float minPosition = 0.0f;
        Vector3 clampedPosition = content.localPosition;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -maxPosition, -minPosition);
        content.localPosition = clampedPosition;
    }


    // Update is called once per frame
    void Update()
    {// 이미지를 이동하여 순환 구현
        content.localPosition += (Vector3)(scrollDirection * scrollSpeed * Time.deltaTime);

        // 이미지가 슬롯 머신의 범위를 벗어나면 반대쪽으로 이동하여 순환 구현
        float maxPosition = (numSlots - 1) * spacing;
        float minPosition = 0.0f;
        if (content.localPosition.y < -maxPosition)
        {
            content.localPosition += (Vector3)(scrollDirection * maxPosition);
        }
        else if (content.localPosition.y > -minPosition)
        {
            content.localPosition -= (Vector3)(scrollDirection * maxPosition);
        }
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        // 드래그 시작 위치 저장
        dragStartPosition = eventData.position;
    }
}
