using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LightTest : MonoBehaviour
{
    //public void OnDrag(PointerEventData eventData)
    //{
    //    transform.position = eventData.position;
    //}

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
            transform.position = mousPos;
    }
    private void OnMouseDrag()
    {
       
    }
}
