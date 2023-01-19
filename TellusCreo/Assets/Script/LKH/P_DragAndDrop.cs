using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_DragAndDrop : MonoBehaviour
{
    private int layer_S;
    private int layer_NS;

    public GameObject rayControl;

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

    private void Start()
    {
        this.tag = "P_stop";
        layer_S = SortingLayer.NameToID("P_Select");
        layer_NS = SortingLayer.NameToID("P_NotSelect");
        ChangeLayer(30);
    }

    private void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        this.transform.position = objectPosition;
    }

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if(rayControl.GetComponent<P_Camera>().isDown == true)
        {
            RaycastHit2D downHit = rayControl.GetComponent<P_Camera>().downHit;
            if (downHit)
            {
                if (System.Object.ReferenceEquals(this.gameObject, downHit.collider.gameObject))
                {
                    Debug.Log("dragAndDrop Down start");
                    this.tag = "P_move";
                    ChangeLayer(31);
                }
            }
        }

        if(rayControl.GetComponent<P_Camera>().isUp == true)
        {
            RaycastHit2D upHit = rayControl.GetComponent<P_Camera>().upHit;
            if (upHit)
            {
                if (System.Object.ReferenceEquals(this.gameObject, upHit.collider.gameObject))
                {
                    Debug.Log("dragAndDrop Up start");
                    this.tag = "P_stop";
                    ChangeLayer(30);
                }
            }
        }
    }
}
