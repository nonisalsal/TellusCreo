using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_testing : MonoBehaviour
{
    public float distance;
    private float speed = 500.0f;

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
        distance = Mathf.Sqrt(((afterPos.x - beforePos.x) * (afterPos.x - beforePos.x)) +
            ((afterPos.y - beforePos.y) * (afterPos.y - beforePos.y)));
        if (distance >= 5)
        {
            if ((afterPos.x - beforePos.x) >= 0)
            {
                if((afterPos.y - beforePos.y) <= 0) { turnRight(); }
                else { turnLeft(); }
            }
            else
            {
                if ((afterPos.y - beforePos.y) <= 0) { turnLeft(); }
                else { turnRight(); }
            }
        }
    }

    private void turnRight()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.angularVelocity = -speed;
    }

    private void turnLeft()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.angularVelocity = speed;
    }
}
