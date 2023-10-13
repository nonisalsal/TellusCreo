using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragAndDropAttic : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public Transform parentAfterDrag;
    private string draggedItemName;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    public string itemname;
    public Item item;
    string textContent;

    public List<ItemData> inventoryItems = new List<ItemData>();

    public static DragAndDropAttic instance;


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
        //rectTransform.anchoredPosition += eventData.delta*0.1f;// / transform.root.localScale.x;
        Canvas canvas = GetComponentInParent<Canvas>();

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
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
            const string pos = "Pos";
            if (collider.name.StartsWith(pos))
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
            else
            {
                switch (textContent)
                {
                    case "Mars":
                        if (collider.CompareTag(textContent))
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
                        break;
                    case "Jupiter":
                        if (collider.CompareTag(textContent))
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
                        break;
                    case "Uranus":
                        if (collider.CompareTag(textContent))
                        {
                            if (InventoryManager.Instance == null || !InventoryManager.Instance.HasItem("Uranus") || !InventoryManager.Instance.HasItem("Launcher"))
                            {
                                transform.SetParent(parentAfterDrag);
                                return;
                            }
                            string itemNameToRemove = textContent; // 제거할 아이템의 이름
                            collider.transform.GetChild(0)?.gameObject.SetActive(true);
                            InventoryManager.Instance.RemoveItemFromInventory(itemNameToRemove);
                            Destroy(gameObject);
                        }
                        break;
                    default: //Ball
                        if (collider.CompareTag(textContent))
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
                        break;
                }
            }
        }
        if (this.gameObject != null)
            transform.SetParent(parentAfterDrag);
    }
}