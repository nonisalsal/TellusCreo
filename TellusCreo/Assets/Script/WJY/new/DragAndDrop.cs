using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.WSA;
using static Data.Util.ActiveFields;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
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

            else if (collider.CompareTag("Item_violin"))
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
            else if (collider.CompareTag("Interactable"))
            {
                if (collider.transform.childCount != 0) continue; // 자식이 0개일때만
                string itemNameToRemove = transform.GetChild(0).GetChild(0).GetComponent<UnityEngine.UI.Image>().sprite.name;
                InventoryManager.Instance.RemoveItemFromInventory(itemNameToRemove);
                GameObject wire = Resources.Load<GameObject>($"Prefabs/KJW/{itemNameToRemove}");

                if (wire != null)
                {
                    GameObject gm = Instantiate<GameObject>(wire, transform.position, Quaternion.identity);
                    gm.transform.SetParent(collider.transform);
                    gm.name = gm.name.Substring(0, 5);
                    gm.transform.localPosition = Vector2.zero;
                }
                GameManager.Instance.Puzzles[(int)GameManager.Puzzle.Wire - GameManager.Instance.NUMBER_OF_PUZZLES].GetComponent<WirePuzzle>().cnt++;
                Destroy(this.gameObject);
            }
            else if (collider.CompareTag("Curtain"))
            {
                string itemNameToRemove = "Ball";
                ShadowPuzzle shadowPuzzle = GameManager.Instance.Puzzles
                    [(int)GameManager.Puzzle.ShadowLight - GameManager.Instance.NUMBER_OF_PUZZLES].GetComponent<ShadowPuzzle>();
                Item ball = InventoryManager.Instance.Items.FirstOrDefault(item => item.name == "Ball");
                if (ball != null && shadowPuzzle.CurrentShadow == ShadowPuzzle.Shadow.Dog) // 테스트 용 코드
                {
                    StartCoroutine(shadowPuzzle.DogShadowCatchBall()); // 공 물어오기
                    InventoryManager.Instance.RemoveItemFromInventory(itemNameToRemove);
                }
            }
            else if (collider.CompareTag("Mars"))
            {
                if (InventoryManager.Instance == null || !InventoryManager.Instance.HasItem("Mars") || !InventoryManager.Instance.HasItem("Launcher"))
                {
                    transform.SetParent(parentAfterDrag);
                    return;
                }
                collider.transform.GetChild(0)?.gameObject.SetActive(true);
                string itemNameToRemove = "Mars"; // 제거할 아이템의 이름
                InventoryManager.Instance.RemoveItemFromInventory(itemNameToRemove);
                Destroy(gameObject);
            }
            else if (collider.CompareTag("Jupiter"))
            {
                if (InventoryManager.Instance == null || !InventoryManager.Instance.HasItem("Jupiter") || !InventoryManager.Instance.HasItem("Launcher"))
                {
                    transform.SetParent(parentAfterDrag);
                    return;
                }
                collider.transform.GetChild(0)?.gameObject.SetActive(true);
                string itemNameToRemove = "Jupiter"; // 제거할 아이템의 이름
                InventoryManager.Instance.RemoveItemFromInventory(itemNameToRemove);
                Destroy(gameObject);
            }
            else if (collider.CompareTag("Uranus"))
            {
                if (InventoryManager.Instance == null || !InventoryManager.Instance.HasItem("Uranus") || !InventoryManager.Instance.HasItem("Launcher"))
                {
                    transform.SetParent(parentAfterDrag);
                    return;
                }
                string itemNameToRemove = "Uranus"; // 제거할 아이템의 이름
                collider.transform.GetChild(0)?.gameObject.SetActive(true);
                InventoryManager.Instance.RemoveItemFromInventory(itemNameToRemove);
                Destroy(gameObject);
            }
            else if (collider.CompareTag("Item_Concent"))
            {
                on.Instance.SpriteOn8();
                string itemNameToRemove = "Concent";
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
        if (this.gameObject != null)
            transform.SetParent(parentAfterDrag);
    }
}