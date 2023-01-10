using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Rotation : MonoBehaviour
{
    public float distance;
    private float speed, sum_x, sum_y;
    private float[] road_x, road_y;
    private int count;

    public bool isDrag = false;

    public Vector2 beforePos, afterPos;

    private Rigidbody2D rig;

    private void Start()
    {
        speed = 500.0f;
        sum_x = 0;
        sum_y = 0;
        road_x = new float[10];
        road_y = new float[10];
        count = 0;
    }

    private void Update()
    {
        PlayerInput();

        saveRoad(count);
        count += 1;

        distance = Mathf.Sqrt(((afterPos.x - beforePos.x) * (afterPos.x - beforePos.x)) +
            ((afterPos.y - beforePos.y) * (afterPos.y - beforePos.y)));
        if (distance >= 5)
        {
            for (int i=0; i<10; i++)
            {
                sum_x += (road_x[i] - beforePos.x);
                sum_y += (road_y[i] - beforePos.y);
            }
            if (sum_x >= 0)
            {
                if (sum_y <= 0) { turnRight(); }
                else { turnLeft(); }
            }
            else
            {
                if (sum_y <= 0) { turnLeft(); }
                else { turnRight(); }
            }
        }
    }

    //private void OnMouseDown()
    //{
    //    beforePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //}

    //private void OnMouseUp()
    //{
    //    afterPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //}

    private void PlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 downPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D downRay = new Ray2D(downPos, Vector2.zero);
            RaycastHit2D downHit = Physics2D.Raycast(downRay.origin, downRay.direction, 1 << 30);
            if (downHit)
            {
                beforePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 upPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D upRay = new Ray2D(upPos, Vector2.zero);
            RaycastHit2D upHit = Physics2D.Raycast(upRay.origin, upRay.direction);
            if (upHit)
            {
                afterPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
    }

    private void saveRoad(int count)
    {
        if (count < 10)
        {
            Vector2 thisPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            road_x[count] = thisPos.x;
            road_y[count] = thisPos.y;
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
