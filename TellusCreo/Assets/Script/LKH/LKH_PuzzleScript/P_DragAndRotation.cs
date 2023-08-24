using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_DragAndRotation : MonoBehaviour
{
    private float angle;
    private Vector2 clockHand, mouse;

    private Quaternion originAngle;

    private SpriteRenderer objectRenderer;
    private int layer_S;
    private int layer_NS;

    private void Awake()
    {
        originAngle = transform.rotation;

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

    private void OnEnable()
    {
        if (P_Camera.instance.nowPuzzle.Get_isClear())
            return;

        if (!P_GameManager.instance.Get_dollClear())
            return;

        Collider2D[] colliders = transform.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
            collider.enabled = true;

        transform.rotation = originAngle;
    }

    private void Start()
    {
        tag = "P_stop";
        ChangeLayer(30);
    }

    private void OnMouseDrag()
    {
        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        angle = Mathf.Atan2(mouse.y - clockHand.y, mouse.x - clockHand.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }

    private void PlayerInput()
    {
        if (P_GameManager.instance.isDown)
        {
            GameObject downHit = P_GameManager.instance.downHit.collider.gameObject;
            if (System.Object.ReferenceEquals(gameObject, downHit))
            {
                tag = "P_move";
                clockHand = transform.position;
                ChangeLayer(31);
            }
        }        
        
        if (P_GameManager.instance.isUp)
        {
            GameObject upHit = P_GameManager.instance.upHit.collider.gameObject;
            if (System.Object.ReferenceEquals(gameObject, upHit))
            {
                tag = "P_stop";
                ChangeLayer(30);
            }
        }
    }

    private void Update()
    {
        PlayerInput();
    }
}
