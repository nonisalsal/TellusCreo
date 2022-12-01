﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_DragAndRotation : MonoBehaviour
{
    private float angle;
    private Vector2 clockHand, mouse;

    private int layer_S;
    private int layer_NS;

    private void Start()
    {
        layer_S = SortingLayer.NameToID("Select");
        layer_NS = SortingLayer.NameToID("NotSelect");
        GetComponent<SpriteRenderer>().sortingLayerID = layer_NS;
    }

    private void OnMouseDown()
    {
        //Debug.Log("태그변경: P_move");
        this.tag = "P_move";
        clockHand = transform.position;
        GetComponent<SpriteRenderer>().sortingLayerID = layer_S;
    }

    private void OnMouseDrag()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - clockHand.y, mouse.x - clockHand.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
    }

    private void OnMouseUp()
    {
        //Debug.Log("태그변경: P_stop");
        this.tag = "P_stop";
        GetComponent<SpriteRenderer>().sortingLayerID = layer_NS;
    }
}
