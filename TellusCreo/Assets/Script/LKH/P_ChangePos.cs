using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ChangePos : MonoBehaviour
{
    public Vector2 beforePos;
    Vector2 afterPos;

    //기존 오브젝트 위치를 저장
    private void OnMouseDown()
    {
        Debug.Log("위치 저장");
        beforePos = this.transform.localPosition;
    }

    /*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "P_stop")
        {
            Debug.Log("위치 변경");
            afterPos = other.transform.localPosition;
            this.transform.localPosition = afterPos;
            other.transform.localPosition = beforePos;
        }
    }
    */
}
