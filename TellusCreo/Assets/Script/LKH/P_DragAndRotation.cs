using System.Collections;
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
        this.tag = "P_stop";
        layer_S = SortingLayer.NameToID("P_Select");
        layer_NS = SortingLayer.NameToID("P_NotSelect");
        ChangeLayer(30);
    }

    private void Update()
    {
        PlayerInput();
    }

    //private void OnMouseDown()
    //{
    //    this.tag = "P_move";
    //    clockHand = transform.position;
    //    ChangeLayer(31);
    //}

    private void OnMouseDrag()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - clockHand.y, mouse.x - clockHand.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
    }

    //private void OnMouseUp()
    //{
    //    this.tag = "P_stop";
    //    ChangeLayer(30);
    //}

    private void PlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 downPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D downRay = new Ray2D(downPos, Vector2.zero);
            RaycastHit2D downHit = Physics2D.Raycast(downRay.origin, downRay.direction, 1 << 30);
            if (downHit)
            {
                this.tag = "P_move";
                clockHand = transform.position;
                ChangeLayer(31);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 upPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D upRay = new Ray2D(upPos, Vector2.zero);
            RaycastHit2D upHit = Physics2D.Raycast(upRay.origin, upRay.direction);
            if (upHit)
            {
                this.tag = "P_stop";
                ChangeLayer(30);
            }
        }
    }

    private void ChangeLayer(int layerNum)
    {
        if (layerNum == 30)
        {
            this.gameObject.layer = 30;
            GetComponent<SpriteRenderer>().sortingLayerID = layer_NS;
        }
        else if (layerNum == 31)
        {
            this.gameObject.layer = 31;
            GetComponent<SpriteRenderer>().sortingLayerID = layer_S;
        }
    }
}
