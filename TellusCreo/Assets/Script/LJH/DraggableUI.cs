
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableUI : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform canvas;
    private RectTransform rect;
    private Transform previousParent;
    private CanvasGroup canvasGroup;
    // Start is called before the first frame update
    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>().transform;
        rect =GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        previousParent = transform.parent;

        transform.SetParent(canvas);
        transform.SetAsLastSibling();

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
    
        if(transform.parent == canvas)
        {
            transform.SetParent(previousParent);
            rect.position=previousParent.GetComponent<RectTransform>().position;
        }
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts= true;
    }
    
    
    
}
