using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Transform parentAfterDrag;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public Item item;

    public Itemmanager itemManager;
    public Itemmanager ViolinitemManager;

    
    private SpriteRenderer puzzleviolinRenderer;
    public GameObject pair;
    public GameObject clear;

    private string currentItem;

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
        List<Item> Items = InventoryManager.Instance.GetItems();
        Collider2D[] colliders = Physics2D.OverlapPointAll(dropPosition);

        foreach (Collider2D collider in colliders)
        {
            // 다른 오브젝트와의 충돌 판정을 수행하고 원하는 동작을 수행합니다.
            if (collider.CompareTag("Item_Guitar"))
            {
                on.Instance.SpriteOn();
                string itemNameToRemove = "Guitar"; // 제거할 아이템의 이름
                InventoryManager.Instance.RemoveItemFromInventory(itemNameToRemove);
                Destroy(gameObject);
            }

            else if(collider.CompareTag("Item_violin"))
            {
                on.Instance.SpriteOn1();
                string itemNameToRemove = "puzzle_violin"; // 제거할 아이템의 이름
                InventoryManager.Instance.RemoveItemFromInventory(itemNameToRemove);
                Destroy(gameObject);
            }

            else if (collider.CompareTag("Item_drum"))
            {
                on.Instance.SpriteOn2();
                string itemNameToRemove = "Drum"; // 제거할 아이템의 이름
                InventoryManager.Instance.RemoveItemFromInventory(itemNameToRemove);
                Destroy(gameObject);
            }

            else if (collider.CompareTag("Item_KeyA"))
            {
                on.Instance.SpriteOn3();
                string itemNameToRemove = "KeyA"; // 제거할 아이템의 이름
                InventoryManager.Instance.RemoveItemFromInventory(itemNameToRemove);
                Destroy(gameObject);
            }

            else if (collider.CompareTag("Item_KeyB"))
            {
                on.Instance.SpriteOn4();
                string itemNameToRemove = "KeyB"; // 제거할 아이템의 이름
                InventoryManager.Instance.RemoveItemFromInventory(itemNameToRemove);
                Destroy(gameObject);
            }

            else if (collider.CompareTag("Item_TopSpinA"))
            {
                on.Instance.SpriteOn5();
                string itemNameToRemove = "SpinA"; // 제거할 아이템의 이름
                InventoryManager.Instance.RemoveItemFromInventory(itemNameToRemove);
                Destroy(gameObject);
            }
            else if (collider.CompareTag("Item_TopSpinB"))
            {
                on.Instance.SpriteOn6();
                string itemNameToRemove = "SpinB"; // 제거할 아이템의 이름
                InventoryManager.Instance.RemoveItemFromInventory(itemNameToRemove);
                Destroy(gameObject);
            }
            else if (collider.CompareTag("Item_TopSpinC"))
            {
                on.Instance.SpriteOn7();
                string itemNameToRemove = "SpinC"; // 제거할 아이템의 이름
                InventoryManager.Instance.RemoveItemFromInventory(itemNameToRemove);
                Destroy(gameObject);
            }



        }


        transform.SetParent(parentAfterDrag);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
    }
}