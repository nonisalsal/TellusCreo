using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PicturePuzzle : P_DragAndDrop
{
    private Vector3 originPos;

    public float pos_x;

    protected override void Awake()
    {
        base.Awake();

        originPos = transform.position;
    }

    private void OnEnable()
    {
        if (P_Camera.instance.nowPuzzle.Get_isClear())
            return;

        // transform.position = originPos;
        transform.SetPositionAndRotation(originPos, Quaternion.identity);
        pos_x = transform.position.x;
    }

    protected override void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //transform.position = new Vector2(pos_x, objectPosition.y);
        transform.SetPositionAndRotation(new Vector3(pos_x, objectPosition.y, 0f), Quaternion.identity);
    }
}
