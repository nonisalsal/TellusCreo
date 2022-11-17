using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ChangePos : MonoBehaviour
{
    public Vector2 beforePos;
    public Vector2 afterPos;

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
        isSet = false;
        GetComponent<Collider2D>().isTrigger = false;
        Debug.Log("위치 저장");
        beforePos = this.transform.localPosition;
    }

    private void OnMouseExit()
    {
        GetComponent<Collider2D>().isTrigger = true;
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
}
