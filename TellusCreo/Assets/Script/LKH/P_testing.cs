﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_testing : MonoBehaviour
{
    public float angle;
    private float speed = 5.0f;

    public bool isDrag = false;

    public Vector2 beforePos, afterPos;

    private Rigidbody2D rig;

    private void OnMouseDown()
    {
        //Debug.Log("태그변경: P_move");
        this.tag = "P_move";
        beforePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        //Debug.Log("태그변경: P_stop");
        this.tag = "P_stop";
        afterPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void Update()
    {
        angle = Mathf.Atan2(afterPos.y - beforePos.y, afterPos.x - afterPos.x) * Mathf.Rad2Deg;
        if (angle >= 90)
        {
            rig = GetComponent<Rigidbody2D>();
            rig.angularVelocity = speed;
        }
    }
}
