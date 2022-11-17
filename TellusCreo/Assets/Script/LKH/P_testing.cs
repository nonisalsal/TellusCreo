using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_testing : MonoBehaviour
{
    public Vector2 beforePos;
    public Vector2 afterPos;

    public bool isMove = false;
    public bool isSet = true;

    void Start()
    {
        beforePos = this.transform.localPosition;
        GetComponent<Collider2D>().isTrigger = true;
    }

    void Update()
    {
        if (this.tag == "P_move") { isMove = true; }
        else { isMove = false; }

        ResetPos();
    }

    private void OnMouseDown()
    {
        isSet = false;
        beforePos = this.transform.localPosition;
        this.gameObject.layer = 9;
        Debug.Log("레이어변경: 9");
    }

    private void OnMouseExit()
    {
        this.gameObject.layer = 8;
        Debug.Log("레이어변경: 8");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isSet && collision.tag == "P_stop")
        {
            isSet = true;
            Debug.Log("위치 변경");
            afterPos = collision.transform.localPosition;
            this.transform.localPosition = afterPos;
            collision.transform.localPosition = beforePos;
        }
    }

    private void ResetPos()
    {
        if (!isMove&&!isSet)
        {
            Debug.Log("초기화");
            this.transform.localPosition = beforePos;
            isSet = true;
        }
    }
}
