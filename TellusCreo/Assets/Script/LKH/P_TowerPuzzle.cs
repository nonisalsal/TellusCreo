using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_TowerPuzzle : MonoBehaviour
{
    private Vector2 beforePos;
    public GameObject standard;
    private float standard_x;
    private float standard_y;

    void Start()
    {
        //standard = GameObject.Find("TowerPuzzle");
        standard_x = standard.transform.position.x;
        //standard_x = GameObject.Find("TowerPuzzle").transform.position.x;
        standard_y = standard.transform.position.y;
        //standard_y = GameObject.Find("TowerPuzzle").transform.position.y;
    }

    void Update()
    {
        //PlayerInput();

        if (this.CompareTag("P_stop"))
        {
            if (this.transform.position.y < standard_y - 6 || this.transform.position.x < standard_x - 10 || this.transform.position.x > standard_x + 10)
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

    //private void PlayerInput()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        this.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
    //    }
    //}

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
}
