using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_IsRightPos : MonoBehaviour
{
    public GameObject correctObj;

    public bool isTrigger;
    public bool isRight;

    void Start()
    {
        isRight = false;
        this.gameObject.layer = 30;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTrigger = true;

        if (System.Object.ReferenceEquals(collision.gameObject, correctObj))
            isRight = true;
        else 
            isRight = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         isTrigger = false;

        if (System.Object.ReferenceEquals(collision.gameObject, correctObj))
            isRight = false;
    }

    public void setIsRight()
    {
        isRight = true;
    }
}
