using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_DragAndDrop : MonoBehaviour
{
    private SpriteRenderer objectRenderer;
    private int layer_S;
    private int layer_NS;

    protected virtual void Awake()
    {
        objectRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        this.tag = "P_stop";
        layer_S = SortingLayer.NameToID("P_Select");
        layer_NS = SortingLayer.NameToID("P_NotSelect");
        ChangeLayer(30);
    }

    private void ChangeLayer(int layerNum)
    {
        if (layerNum == 30)
        {
            gameObject.layer = 30;
            objectRenderer.sortingLayerID = layer_NS;
        }
        else if (layerNum == 31)
        {
            gameObject.layer = 31;
            objectRenderer.sortingLayerID = layer_S;
        }
    }

    protected virtual void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = objectPosition;
    }

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (L_GameManager.instance.isDown == true)
        {
            RaycastHit2D downHit = L_GameManager.instance.downHit;
            if (System.Object.ReferenceEquals(gameObject, downHit.collider.gameObject))
            {
                // Debug.Log("dragAndDrop Down start");
                this.tag = "P_move";
                ChangeLayer(31);
            }
        }

        if (L_GameManager.instance.isUp == true)
        {
            //Debug.Log("dragAndDrop Up start");
            this.tag = "P_stop";
            ChangeLayer(30);
        }
    }
}
