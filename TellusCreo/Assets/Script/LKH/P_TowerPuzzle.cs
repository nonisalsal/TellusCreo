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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("P_building") && this.gameObject.CompareTag("P_building") == false)
        {
            if (collision.contacts[0].normal.y < 0.7f)
            {
                this.transform.position = beforePos;
            }
        }
        if (collision.gameObject.name == "platform" && collision.contacts[0].normal.y >= 1f  && this.gameObject.CompareTag("P_building") == false)
        {
            beforePos = this.transform.position;
            this.tag = "P_building";
        }
        if (collision.gameObject.CompareTag("P_building") && this.gameObject.CompareTag("P_building") == false)
        {
            this.tag = "P_building";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "clearZone") { isRight = true; }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "clearZone") { isRight = false; }
    }
}
