using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_TowerPuzzle : MonoBehaviour
{
    private Vector2 beforePos;
    public GameObject standard;
    private float standard_x;
    private float standard_y;

    private Vector3 originPos;

    private void Awake()
    {
        originPos = transform.position;
    }

    private void OnEnable()
    {
        if (P_Camera.instance.nowPuzzle.Get_isClear())
            return;

        transform.position = originPos;
    }

    void Start()
    {
        standard_x = standard.transform.position.x;
        standard_y = standard.transform.position.y;
    }

    void Update()
    {
        if (CompareTag("P_stop"))
        {
            if (transform.position.y < standard_y - 6 || transform.position.x < standard_x - 10 || transform.position.x > standard_x + 10)
            {
                transform.position = beforePos;
            }
        }
    }

    private void OnMouseDown()
    {
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
    }

    private void OnMouseDrag()
    {
        transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "platform" && collision.contacts[0].normal.y >= 1f  && !gameObject.CompareTag("P_building"))
        {
            beforePos = transform.position;
            tag = "P_building";
        }
        if (collision.gameObject.CompareTag("P_building") && !gameObject.CompareTag("P_building"))
            tag = "P_building";
    }
}
