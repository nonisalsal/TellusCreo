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

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (System.Object.ReferenceEquals(parentObj, collision.transform.parent.gameObject))
            ChangePosition(collision);
    }
}
