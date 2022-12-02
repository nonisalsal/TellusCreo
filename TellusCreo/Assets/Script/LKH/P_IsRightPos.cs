using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_IsRightPos : MonoBehaviour
{
    private int layer_NS;
    public GameObject correctObj;

    public bool isRight;

    void Start()
    {
        isRight = false;
        this.gameObject.layer = 8;
        layer_NS = SortingLayer.NameToID("NotSelect");
        GetComponent<SpriteRenderer>().sortingLayerID = layer_NS;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("트리거 접촉");
        if (collision.gameObject == correctObj)
        {
            isRight = true;
            Debug.Log("IsRight 활성화");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("트리거 취소");
        if (collision.gameObject == correctObj)
        {
            isRight = false;
            Debug.Log("IsRight 비활성화");
        }
    }
}
