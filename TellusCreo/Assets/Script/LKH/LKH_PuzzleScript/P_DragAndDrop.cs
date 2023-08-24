using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_DragAndDrop : MonoBehaviour
{
    private SpriteRenderer objectRenderer;
    private int layer_S;
    private int layer_NS;

    protected virtual void Awake()
    {
        objectRenderer = GetComponent<SpriteRenderer>();
        layer_S = SortingLayer.NameToID("P_Select");
        layer_NS = SortingLayer.NameToID("P_NotSelect");
    }

    private void ChangeLayer(int layerNum)
    {
        switch (layerNum)
        {
            case 30:
                gameObject.layer = 30;
                objectRenderer.sortingLayerID = layer_NS;
                break;
            case 31:
                gameObject.layer = 31;
                objectRenderer.sortingLayerID = layer_S;
                break;
        }
    }

    private void Start()
    {
        tag = "P_stop";
        ChangeLayer(30);
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
        if (P_GameManager.instance.isDown)
        {
            GameObject downHit = P_GameManager.instance.downHit.collider.gameObject;
            if (System.Object.ReferenceEquals(gameObject, downHit))
            {
                tag = "P_move";
                ChangeLayer(31);
            }
        }
        if (P_GameManager.instance.isUp)
        {
            tag = "P_stop";
            ChangeLayer(30);
        }
    }
}
