using UnityEngine;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public GameObject Image;
    public Transform ItemDropZone;
    public GameObject itemItem;
    public GameObject beforeItem;

    private bool isDragging = false;
    private bool isDropped = false;


    public void OnDrag(PointerEventData eventData)
    {
        if (isDropped)
            return;

        isDragging = true;
        Vector3 position = Camera.main.ScreenToWorldPoint(eventData.position);
        position.z = 0;
        Image.transform.position = position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;

        Vector2 rayPos = Camera.main.ScreenToWorldPoint(eventData.position);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero);

        if (hit.collider != null && hit.collider.transform == ItemDropZone)
        {
            Image.transform.SetParent(ItemDropZone);
            Image.transform.position = ItemDropZone.position;

            itemItem.SetActive(true);
            Image.SetActive(false);
            beforeItem.SetActive(false);
            isDropped = true;
        }
        else
        {
            Image.transform.SetParent(transform);
            Image.transform.localPosition = Vector3.zero;
        }
    }
}
