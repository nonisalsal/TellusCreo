using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Rotation : MonoBehaviour
{
    private float distance;
    private float speed, sum_x, sum_y;
    private float[] road_x, road_y;
    private int count;

    private bool isDrag = false;
    public bool isRotation = false;

    private Vector2 beforePos, afterPos;

    private Rigidbody2D rig;

    public Sprite rotationImg;
    public GameObject pairTrigger;
    public bool isSet;
    public bool isSetAll;

    public GameObject rayControl;

    private void Start()
    {
        speed = 250.0f;
        sum_x = 0;
        sum_y = 0;
        road_x = new float[10];
        road_y = new float[10];
        count = 0;

        isSet = false;
        isSetAll = false;

        this.GetComponent<SpriteRenderer>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(System.Object.ReferenceEquals(collision.gameObject, pairTrigger))
        {
            isSet = true;
            this.GetComponent<SpriteRenderer>().enabled = true;
            collision.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (isSetAll == false) { CheckTrigger(); }
        if (isSetAll == true) {
            PlayerInput();
            RotateObj();
        }
    }

    private void CheckTrigger()
    {
        MonoBehaviour[] scripts = transform.parent.GetComponentsInChildren<P_Rotation>();
        int length = scripts.Length;
        foreach (MonoBehaviour script in scripts)
        {
            if (script.GetComponent<P_Rotation>().isSet == false) { break; }
            else
            {
                if (script == scripts[length - 1])
                {
                    GetComponent<P_Rotation>().isSetAll = true;
                }
            }
        }
    }

    private void RotateObj()
    {
        //saveRoad(count);
        //count += 1;
        distance = Mathf.Sqrt(((afterPos.x - beforePos.x) * (afterPos.x - beforePos.x)) +
            ((afterPos.y - beforePos.y) * (afterPos.y - beforePos.y)));
        if (isRotation && distance >= 5)
        {
            this.GetComponent<SpriteRenderer>().sprite = rotationImg;

            for (int i = 0; i < 10; i++)
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

    private void PlayerInput()
    {
        if (rayControl.GetComponent<P_GameManager>().isDown == true)
        {
            RaycastHit2D downHit = rayControl.GetComponent<P_GameManager>().downHit;
            if (downHit)
            {
                if (System.Object.ReferenceEquals(this.gameObject, downHit.collider.gameObject))
                {
                    isDrag = true;
                    beforePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (isDrag)
            {
                afterPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                isRotation = true;
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

    private void OnMouseDrag()
    {
        if (isSet && count < 10)
        {
            Vector2 thisPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            road_x[count] = thisPos.x;
            road_y[count] = thisPos.y;

            count += 1;
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
