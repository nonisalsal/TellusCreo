using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_IsRight : MonoBehaviour
{
    private int layer_NS;
    public GameObject correctObj;

    public bool isRight;

    void Start()
    {
        isRight = false;
        layer_NS = SortingLayer.NameToID("NotSelect");
        GetComponent<SpriteRenderer>().sortingLayerID = layer_NS;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("OnTriggerStay");
        if (collision.gameObject == correctObj)
        {
            isRight = true;
            Debug.Log("IsRight True");
        }
    }
}
