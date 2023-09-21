using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_BookPuzzle : L_DragAndDrop
{
    private Vector3 originPos;

    public float pos_y;

    protected override void Awake()
    {
        base.Awake();

        originPos = transform.position;
    }

    private void OnEnable()
    {
        if (P_Camera.instance.nowPuzzle.Get_isClear())
            return;

        transform.position = originPos;
        pos_y = transform.position.y;
    }

    protected override void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector2(objectPosition.x, pos_y);
    }
}
