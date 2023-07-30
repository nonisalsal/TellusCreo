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
    private Item currentItem;

    private SpriteRenderer puzzleGuitarRenderer;
    private SpriteRenderer puzzleviolinRenderer;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        puzzleGuitarRenderer = GameObject.FindGameObjectWithTag("Item_Guitar")?.GetComponent<SpriteRenderer>();

        if (puzzleGuitarRenderer == null)
        {
            Debug.LogWarning("puzzle_guitar 오브젝트를 찾지 못하거나 SpriteRenderer 컴포넌트를 찾지 못했습니다.");
        }

        puzzleviolinRenderer = GameObject.FindGameObjectWithTag("Item_violin")?.GetComponent<SpriteRenderer>();

        if (puzzleviolinRenderer == null)
        {
            Debug.LogWarning("puzzle_violin 오브젝트를 찾지 못하거나 SpriteRenderer 컴포넌트를 찾지 못했습니다.");
        }
    }
    public void SetCurrentItem(Item item)
    {
        currentItem = item;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        canvasGroup.blocksRaycasts = false;
        currentItem = item;
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
        InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();

        List<Item> itemsInInventory = inventoryManager.GetItems(); // 인벤토리에 있는 아이템들을 가져옴

        foreach (Collider2D collider in colliders)
        {
            // 인벤토리에 있는 아이템들과 비교하여 상호작용
            foreach (Item inventoryItem in itemsInInventory)
            {
                if (inventoryItem != null && collider.CompareTag(inventoryItem.interactTag))
                {
                    Debug.Log(inventoryItem.itemName + "와(과) " + collider.tag + " 상호작용");

                    if (collider.CompareTag("Item_Guitar"))
                    {
                        if (puzzleGuitarRenderer != null)
                        {
                            puzzleGuitarRenderer.enabled = !puzzleGuitarRenderer.enabled;
                        }
                    }
                    else if (collider.CompareTag("Item_violin"))
                    {
                        if (puzzleviolinRenderer != null)
                        {
                            puzzleviolinRenderer.enabled = !puzzleviolinRenderer.enabled;
                        }
                    }

                    break;
                }
            }
        }

        transform.SetParent(parentAfterDrag);
    }


    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    canvasGroup.blocksRaycasts = true;


    //    Vector3 dropPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    dropPosition.z = 0f;


    //    Collider2D[] colliders = Physics2D.OverlapPointAll(dropPosition);
    //    InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();

    //    foreach (Collider2D collider in colliders)
    //    {
    //        if (item != null && collider.CompareTag(item.interactTag))
    //        {
    //            // 아이템과 오브젝트의 태그를 비교하여 상호작용
    //            Debug.Log(item.itemName + "와(과) " + collider.tag + " 상호작용");
    //            puzzleGuitarRenderer.enabled = !puzzleGuitarRenderer.enabled;
    //            break;
    //        }
    //        //if (collider.CompareTag("Keybox"))
    //        //{

    //        //    Debug.Log("알맞는 사물을 찾았습니다");

    //        //    break;
    //        //}

    //        //if (collider.CompareTag("Item_Guitar"))
    //        //{
    //        //    Debug.Log("기타 찾았습니다");


    //        //    if (puzzleGuitarRenderer != null && inventoryManager.HasItem("Guitar"))
    //        //    {

    //        //        puzzleGuitarRenderer.enabled = !puzzleGuitarRenderer.enabled;
    //        //    }

    //        //    break;
    //        //}

    //        //if (collider.CompareTag("Item_violin"))
    //        //{
    //        //    Debug.Log("바이올린 찾았습니다");


    //        //    if (puzzleviolinRenderer != null)
    //        //    {

    //        //        puzzleviolinRenderer.enabled = !puzzleviolinRenderer.enabled;
    //        //    }

    //        //    break;
    //        //}
    //    }


    //    transform.SetParent(parentAfterDrag);
    //}

    //public void OnEndDrag(PointerEventData eventData)
    //{
    //    canvasGroup.blocksRaycasts = true;

    //    Vector3 dropPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    dropPosition.z = 0f;

    //    Collider2D[] colliders = Physics2D.OverlapPointAll(dropPosition);
    //    InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();

    //    foreach (Collider2D collider in colliders)
    //    {
    //        if (collider.CompareTag("Keybox"))
    //        {
    //            Debug.Log("알맞는 사물을 찾았습니다");
    //            break;
    //        }

    //        if (collider.CompareTag("Item_Guitar"))
    //        {
    //            Debug.Log("기타 찾았습니다");

    //            // 아이템 이름을 비교하여 원하는 동작을 수행
    //            if (currentItem != null && currentItem.itemName == "Guitar")
    //            {
    //                Debug.Log("기타 찾았습니다");
    //                // 기타를 찾은 경우 추가적인 동작을 수행합니다
    //                // 예를 들어, 렌더러를 켜거나 끄는 등의 작업:
    //                if (puzzleGuitarRenderer != null)
    //                {
    //                    puzzleGuitarRenderer.enabled = !puzzleGuitarRenderer.enabled;
    //                }
    //            }
    //            break;
    //        }

    //        if (collider.CompareTag("Item_violin"))
    //        {
    //            // Get the Item component attached to the collider's GameObject
    //            Item item = collider.GetComponent<Item>();

    //            // Check if the item's itemName matches the desired item name
    //            if (item != null && item.itemName == "Violin")
    //            {
    //                Debug.Log("바이올린 찾았습니다");

    //                // Your additional actions related to finding the Violin item
    //                // For example, enable/disable renderer:
    //                if (puzzleviolinRenderer != null)
    //                {
    //                    puzzleviolinRenderer.enabled = !puzzleviolinRenderer.enabled;
    //                }
    //            }

    //            break;
    //        }
    //    }

    //    transform.SetParent(parentAfterDrag);
    //}

    public void OnPointerDown(PointerEventData eventData)
    {
    }
}