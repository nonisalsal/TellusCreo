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

    private Vector2 beforePos, afterPos;

    private Rigidbody2D rig;

    [SerializeField] private Sprite rotationImg;
    private bool isSet;
    private bool isSetAll;

    private bool isRotation;
    private bool rotateRight = false;
    private bool rotateLeft = false;

    private P_PuzzleClear clearController;
    private Sprite originImg;
    private Quaternion originRotation;

    private void Awake()
    {
        isSet = false;
        isSetAll = false;

        rig = GetComponent<Rigidbody2D>();
        clearController = transform.GetComponentInParent<P_PuzzleClear>();

        originImg = GetComponent<SpriteRenderer>().sprite;
        originRotation = transform.rotation;
    }

    private void OnEnable()
    {
        if (P_Camera.instance.nowPuzzle.Get_isClear())
            return;

        if (!isSetAll)
            return;

        GetComponent<SpriteRenderer>().sprite = originImg;
        isDrag = false;
        transform.rotation = originRotation;

        isRotation = false;
        rotateRight = false;
        rotateLeft = false;
    }

    private void Start()
    {
        speed = 250.0f;
        sum_x = 0;
        sum_y = 0;
        road_x = new float[10];
        road_y = new float[10];
        count = 0;

        GetComponent<SpriteRenderer>().enabled = false;
    }

    private void Update()
    {
        if (!isSetAll)
            return;

        if (rotateRight) 
        {
            turnRight();
            return;
        }

        if (rotateLeft)
        {
            turnLeft();
            return;
        }

        PlayerInput();
    }

    public void CheckTrigger()
    {
        isSet = true;
        Collider2D collider = GetComponent<Collider2D>();
        collider.offset = Vector2.zero;
        ((CapsuleCollider2D)collider).size = new Vector2(2.5f, 2.5f);

        P_Rotation[] scripts = transform.parent.GetComponentsInChildren<P_Rotation>();
        int length = scripts.Length;

        foreach (P_Rotation script in scripts)
        {
            if (!script.Get_isSet())
                break;

            else
            {
                if (script == scripts[length - 1])
                {
                    foreach (P_Rotation script2 in scripts)
                        script2.Set_isSetAll();
                }
            }
        }
    }

    private void RotateObj()
    {
        distance = Mathf.Sqrt(((afterPos.x - beforePos.x) * (afterPos.x - beforePos.x)) +
            ((afterPos.y - beforePos.y) * (afterPos.y - beforePos.y)));

        if (distance >= 5)
        {
            this.GetComponent<SpriteRenderer>().sprite = rotationImg;

            for (int i = 0; i < 10; i++)
            {
                sum_x += (road_x[i] - beforePos.x);
                sum_y += (road_y[i] - beforePos.y);
            }
            if (sum_x >= 0)
            {
                if (sum_y <= 0)
                    rotateRight = true;
                else
                    rotateLeft = true;
            }
            else
            {
                if (sum_y <= 0)
                    rotateLeft = true;
                else
                    rotateRight = true;
            }
        }

        isRotation = true;
        clearController.CheckClear_TopPuzzle();
    }

    private void PlayerInput()
    {
        if (P_GameManager.instance.isDown)
        {
            GameObject downHit = P_GameManager.instance.downHit.collider.gameObject;
            if (System.Object.ReferenceEquals(gameObject, downHit))
            {
                isDrag = true;
                beforePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        if (P_GameManager.instance.isUp_nonCollider)
        {
            if (isDrag)
            {
                afterPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RotateObj();
            }
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

    private void turnRight() { rig.angularVelocity = -speed; }

    private void turnLeft() { rig.angularVelocity = speed; }

    public bool Get_isSet() { return isSet; }

    public void Set_isSetAll()
    {
        isSetAll = true;
        Debug.Log("Set all tops");
    }

    public bool Get_isRotation() { return isRotation; }
}
