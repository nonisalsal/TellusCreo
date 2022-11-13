using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_testing : MonoBehaviour
{
    public Vector3 beforePos;
    public Vector3 afterPos;

    public bool isSet = true;
    public bool isMove = false;


    void Update()
    {
        if (this.tag == "P_move") { isMove = true; }
        else { isMove = false; }

        if (!isMove && !isSet)
        {
            Debug.Log("초기화");
            this.transform.localPosition = beforePos;
            isSet = true;
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("태그변경: P_move");
        gameObject.tag = "P_move";

        isSet = false;
        Debug.Log("위치 저장");
        beforePos = this.transform.localPosition;
    }

    private void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        this.transform.position = objectPosition;
    }

    private void OnMouseUp()
    {
        //Debug.Log("태그변경: P_stop");
        gameObject.tag = "P_stop";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isMove)
        {
            isSet = true;
            Debug.Log("위치 변경");
            afterPos = collision.transform.localPosition;
            this.transform.localPosition = afterPos;
            collision.transform.localPosition = beforePos;
        }
    }

    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isMove)
        {
            isSet = true;
            afterPos = collision.transform.localPosition;
            Debug.Log("위치 변경");
            this.transform.localPosition = afterPos;
            collision.transform.localPosition = beforePos;
        }
    }
    */
}
