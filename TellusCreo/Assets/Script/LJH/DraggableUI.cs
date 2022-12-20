
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

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
        //드래그 직전에 소속되어 있던 부모 Transform 정보 저장
        previousParent = transform.parent;

        // 현재 드래그중인 UI가 화면의 최상단에 출력되도록 하기 위해
        transform.SetParent(canvas);
        // 부모 오브젝트를 Canvas로 설정
        transform.SetAsLastSibling();        // 가장 앞에 보이도록 마지막 자식으로 설정

        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rect.position = eventData.position;
        //GetComponent<TextFolder>().state=false;
        
    }

    public void OnEndDrag(PointerEventData eventData) {

        // 드래그를 시작하면 부모가 canvas로 설정되기 때문에
        // 드래그를 종료할 때 부모가 canvas이면 아이템 슬롯이 아닌 엉뚱한 곳에
        // 드롭을 했다는 뜻이기 때문에 드래그 직전에 소속되어 있던 아이템 슬롯으로 아이템 이동
        if (transform.parent == canvas)
        {
            transform.SetParent(previousParent);
            rect.position=previousParent.GetComponent<RectTransform>().position;
          
        }

        if (transform.parent.transform.childCount >= 2)     //이미 슬롯에 자식이 1개이상 있을 때 
        {

            transform.SetParent(previousParent);
            rect.position = previousParent.GetComponent<RectTransform>().position;    //이전 부모 슬롯으로 돌아가는 코드  


        }
        canvasGroup.alpha = 1.0f;
        canvasGroup.blocksRaycasts= true;
    }

    public void OnDrop(PointerEventData eventData)
    {


        ///pointerDrag는 현재 드래그하고 있는 대상(= 아이템)
        //if(transform.parent.transform.childCount >= 1)     //이미 슬롯에 자식이 1개이상 있을 때 
        //    {

        //            transform.SetParent(previousParent);
        //            rect.position = previousParent.GetComponent<RectTransform>().position;    //이전 부모 슬롯으로 돌아가는 코드  


        //    }

        //else
        //    {
        //            if (eventData.pointerDrag != null)
        //            {

        //                eventData.pointerDrag.transform.SetParent(transform);
        //                eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;


        //            }
        //    }
        if (eventData.pointerDrag != null)
        {

            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;





            //    // 드래그하고 있는 대상의 부모를 현재 오브젝트로 설정하고, 위치를 현재 오브젝트 위치와 동일하게 설정
            //    //eventData.pointerDrag.transform.SetParent(transform);
            //    //eventData.pointerDrag.GetComponent<RectTransform>().position = rect.position;
            //}
        }


    }
}
