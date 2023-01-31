using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_IsRightPos : MonoBehaviour
{
    //private int layer_NS;
    public GameObject correctObj;

    public bool isTrigger;
    public bool isRight;

    void Start()
    {
        isRight = false;
        this.gameObject.layer = 30;
        //layer_NS = SortingLayer.NameToID("P_NotSelect");
        //GetComponent<SpriteRenderer>().sortingLayerID = layer_NS;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("트리거 접촉");
        if (System.Object.ReferenceEquals(collision.gameObject, correctObj))
        {
            isTrigger = true;
            //Debug.Log("IsRight 활성화");
        }
        else { isTrigger = false; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isTrigger = false;
    }

    private void LateUpdate()
    {
        if (isTrigger)
        {
            isRight = true;
        }
    }
}
