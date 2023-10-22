using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_DollPuzzle : P_ChangePos
{
    private GameObject parentObj;

    private Vector3 originPos;

    private void Awake()
    {
        originPos = transform.position;
        parentObj = transform.parent.gameObject;
    }

    private void OnEnable()
    {
        if (P_Camera.instance.nowPuzzle.Get_isClear())
            return;

        transform.SetPositionAndRotation(originPos, Quaternion.identity);
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (System.Object.ReferenceEquals(parentObj, collision.transform.parent.gameObject))
            ChangePosition(collision);
    }
}
