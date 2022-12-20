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
        ChangeLayer(8);
    }

    private void OnMouseDown()
    {
        //Debug.Log("태그변경: P_move");
        this.tag = "P_move";
        clockHand = transform.position;
        ChangeLayer(9);
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
        ChangeLayer(8);
    }

    private void ChangeLayer(int layerNum)
    {
        if (layerNum == 8)
        {
            this.gameObject.layer = 8;
            GetComponent<SpriteRenderer>().sortingLayerID = layer_NS;
            //if (this.gameObject.layer == 8) { Debug.Log("레이어변경: 8"); }
        }
        else if (layerNum == 9)
        {
            this.gameObject.layer = 9;
            GetComponent<SpriteRenderer>().sortingLayerID = layer_S;
            //if (this.gameObject.layer == 9) { Debug.Log("레이어변경: 9"); }
        }
    }
}
