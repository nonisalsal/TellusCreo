using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePiece : MonoBehaviour
{
    Vector2 mousPos;
    GameObject pos;

    WirePuzzle wirePuzzle;

    


    private void Start()
    {
        wirePuzzle = GameObject.FindObjectOfType<WirePuzzle>();
    }

    private void OnMouseDrag()
    {
        mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 좌표 바꾸기
        transform.position = mousPos;
    }

    private void OnMouseUp()
    {
        if (pos != null)
        {
            if (pos.transform.childCount == 0)
            {
                transform.SetParent(pos.transform);
                transform.localPosition = Vector2.zero;
                wirePuzzle.cnt++;
                SoundManager.Instance.Play("puzzle_wire_connect"); // 와이어 연결음
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        pos = collision.gameObject;

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        pos = null;
    }

}
