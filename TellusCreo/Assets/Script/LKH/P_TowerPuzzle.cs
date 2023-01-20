using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_TowerPuzzle : MonoBehaviour
{
    private Vector2 beforePos;
    private Rigidbody2D rig;

    public bool isRight;

    void Start()
    {
        isRight = false;
        rig = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (this.CompareTag("P_stop"))
        {
            if (this.transform.position.y < -6 || this.transform.position.x < -10 || this.transform.position.x > 10)
            {
                this.transform.position = beforePos;
            }
        }
    }

    private void OnMouseDown()
    {
        this.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
    }

    private void OnMouseDrag()
    {
        this.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "platform" && collision.contacts[0].normal.y >= 1f)
        {
            beforePos = this.transform.position;
            this.tag = "P_building";
        }
        if (this.transform.position.x > collision.transform.position.x - 0.3 && this.transform.position.x < collision.transform.position.x + 0.3)
        {
            if (this.transform.position.y > collision.transform.position.y - 0.3 && this.transform.position.y < collision.transform.position.y + 0.3)
            {
                this.transform.position = beforePos;
            }
        }
        //    else
        //    {
        //        if(collision.contacts[0]s.normal.y >= 0.9f && collision.gameObject.name == "platform")
        //        {
        //            beforePos = this.transform.position;
        //        }
        //        else if(collision.contacts[0].normal.y < 0.9f)
        //        {
        //            this.transform.position = beforePos;
        //        }

        //        if (collision.contacts[0].normal.y < 0.9f)
        //        {
        //            if (collision.contacts[0].normal.x < 0.9f)
        //            {
        //                this.transform.position = beforePos;
        //            }
        //        }
        //    }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("P_building"))
        {
            this.tag = "P_building";
        }
    }

    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    if (collision.gameObject.name == "clearZone")
    //    {
    //        isRight = false;
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "clearZone") { isRight = true; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "clearZone") { isRight = false; }
    }
}
