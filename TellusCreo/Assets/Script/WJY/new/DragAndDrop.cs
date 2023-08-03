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

    private SpriteRenderer puzzleGuitarRenderer;
    private SpriteRenderer puzzleviolinRenderer;
    public GameObject pair;
    public GameObject clear;

    private string currentItem;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        InitializeObjects();
    }

    private void Update()
    {
        
          InitializeObjects();
       
    }

    public void InitializeObjects()
    {
        GameObject itemManagerObject = GameObject.Find("Guitar_manager");
        itemManager = itemManagerObject.GetComponent<Itemmanager>();
        GameObject Violin_managerObject = GameObject.Find("Violin_manager");
        ViolinitemManager = Violin_managerObject.GetComponent<Itemmanager>();
        puzzleGuitarRenderer = GameObject.FindGameObjectWithTag("Item_Guitar")?.GetComponent<SpriteRenderer>();
        puzzleviolinRenderer = GameObject.FindGameObjectWithTag("Item_violin")?.GetComponent<SpriteRenderer>();
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
   

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        canvasGroup.blocksRaycasts = false;

        // 드래그 중인 아이템을 currentItem에 할당
        currentItem = itemManager.item.interactTag;
        Debug.Log(currentItem);
        // currentItem이 유효한지 확인
      
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
        List<Item> itemsInInventory = inventoryManager.GetItems();

        foreach (Collider2D collider in colliders)
        {
            foreach (Item inventoryItem in itemsInInventory)
            {
                if (collider.CompareTag(inventoryItem.interactTag))
                {
                    Debug.Log(collider.gameObject.name);
                    Debug.Log(inventoryItem.itemName);

                    // 각 아이템에 맞게 동작 수행
                    if (collider.gameObject.name == itemManager.item.name)
                    {
                   

                        if (puzzleGuitarRenderer != null)
                        {
                            puzzleGuitarRenderer.enabled = !puzzleGuitarRenderer.enabled;
                            Destroy(gameObject); // 해당 게임 오브젝트를 삭제
                        }


                        else if (collider.gameObject.name == ViolinitemManager.item.name) // 여기에 바이올린 이름의 오브젝트의 이름을 넣어주세요.
                        {
                            Debug.Log(inventoryItem.itemName + "와(과) " + collider.tag + " 상호작용");

                    
                            if (puzzleviolinRenderer != null)
                            {
                                puzzleviolinRenderer.enabled = !puzzleviolinRenderer.enabled;
                                Destroy(gameObject); // 해당 게임 오브젝트를 삭제
                            }
                            
                        }

                    }

                    break;
                }
            }
        }

        transform.SetParent(parentAfterDrag);
    }


    public void OnPointerDown(PointerEventData eventData)
    {
    }
}