using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_TowerClearZone : MonoBehaviour
{
    public bool isRight;
    public bool isContect;
    public bool isColliderMove;

    public float time;
    public Vector3 colliderLastPos;

    private void Start()
    {
        isRight = false;
        isContect = false;
        isColliderMove = false;

        time = 0;

        this.gameObject.layer = 30;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isContect == false)
        {
            colliderLastPos = collision.transform.localPosition;
            isContect = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isRight == false && collision.gameObject.CompareTag("P_building"))
        {
            //Debug.Log("asdf");
            CheckPosition(collision);
            if (isColliderMove == false)
            {
                time += Time.deltaTime;
                if (time >= 3)
                {
                    isRight = true;
                }
                else { time = 0; }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isContect = false;
        isColliderMove = false;
    }

    private void CheckPosition(Collider2D obj)
    {
        if (colliderLastPos != obj.transform.localPosition)
        {
            isColliderMove = true;
            colliderLastPos = obj.transform.localPosition;
        }
        else { isColliderMove = false; }
    }
}
