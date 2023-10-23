using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Transform parentAfterDrag;
    private string draggedItemName;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public string itemname;
    public Item item;
    string textContent;

    public List<ItemData> inventoryItems = new List<ItemData>();

    public static DragAndDrop instance;


    private SpriteRenderer puzzleviolinRenderer;
    public GameObject pair;
    public GameObject clear;

    private string currentItem;

    private void Awake()
    {
        instance = this;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        ItemDataBase itemDatabase = GameObject.Find("ItemDataBase").GetComponent<ItemDataBase>();


        foreach (ItemData itemData in itemDatabase.itemDB)
        {
            inventoryItems.Add(itemData);
        }


        GameObject draggedObject = eventData.pointerDrag;
        if (draggedObject != null)
        {

            Text textComponent = draggedObject.GetComponentInChildren<Text>();

            if (textComponent != null)
            {

                textContent = textComponent.text;
                Debug.Log(textContent);

            }
        }
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        canvasGroup.blocksRaycasts = false;

    }

    public void OnDrag(PointerEventData eventData)
    { 
        Vector3 position = Camera.main.ScreenToWorldPoint(eventData.position);
        position.z = 0;
        this.transform.position = position;
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
            if (collider.CompareTag(textContent))
            {
                string itemName = textContent;
                switch (textContent)
                {
                    case "Guitar":
                        on.Instance.SpriteOn();
                        break;
                    case "puzzle_violin":
                        on.Instance.SpriteOn1();
                        break;
                    case "Drum":
                        on.Instance.SpriteOn2();
                        break;
                    case "KeyA":
                        on.Instance.SpriteOn3();
                        break;
                    case "KeyB":
                        on.Instance.SpriteOn4();
                        break;
                    case "SpinA":
                        on.Instance.SpriteOn5();
                        break;
                    case "SpinB":
                        on.Instance.SpriteOn6();
                        break;
                    case "SpinC":
                        on.Instance.SpriteOn7();
                        break;
                    case "Concent":
                        on.Instance.SpriteOn8();
                        break;
                }
                InventoryManager.Instance.RemoveItemFromInventory(itemName);
                Destroy(gameObject);
            }
        }

        if (this.gameObject != null)
            transform.SetParent(parentAfterDrag);

        P_GameManager.instance.isUp = false;
    }
}