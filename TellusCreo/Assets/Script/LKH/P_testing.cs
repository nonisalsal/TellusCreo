using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_testing : MonoBehaviour
{
    private int layer_S;
    private int layer_NS;

    private Vector2 beforePos;

<<<<<<< HEAD
    public bool isRight;

    private void Start()
=======
    public Vector2 beforePos, afterPos;
    private struct AfterPositions
    {
        float afterX;
        float afterY;
    }

    private Rigidbody2D rig;

    private void Start()
    {
        
    }

    private void OnMouseDown()
>>>>>>> b6731a5df71ef6bcf71b5e938a3f5c552ed22731
    {
        layer_S = SortingLayer.NameToID("P_Select");
        layer_NS = SortingLayer.NameToID("P_NotSelect");
        ChangeLayer(8);
        isRight = false;
    }

    private void Update()
    {
        if(this.transform.position.y >= 4)
        {
            isRight = true;
        }
        if(isRight==true &&this.transform.position.y < 4)
        {
            isRight = false;
        }
    }

    private void OnMouseDown()
    {
        ChangeLayer(9);
        this.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
    }

    private void OnMouseDrag()
    {
        this.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
    }

    private void OnMouseUp()
    {
        ChangeLayer(8);
        if (this.transform.position.y < beforePos.y)
        {
            this.transform.position = beforePos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "platform")
        {
            if (collision.contacts[0].normal.y > 0.7f)
            {
                beforePos = this.transform.position;
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "platform" )
        {
            if (collision.contacts[0].normal.y > 0.7f)
            {
                this.tag = "P_building";
            }
            else
            {
                if (collision.contacts[0].normal.x <= 0.7f)
                {
                    this.transform.position = beforePos;
                }
            }
        }

        if (collision.gameObject.name == "wall")
        {
            if (collision.contacts[0].normal.x <= 0.7f)
            {
                this.transform.position = beforePos;
            }
        }

        if (collision.gameObject.tag == "P_building")
        {
            if (collision.contacts[0].normal.y < 0.7f)
            {
                if (collision.contacts[0].normal.x <= 0.7f)
                {
                    this.transform.position = beforePos;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        this.tag = "P_stop";
    }

    private void ChangeLayer(int layerNum)
    {
        if (layerNum == 8)
        {
            this.gameObject.layer = 8;
            GetComponent<SpriteRenderer>().sortingLayerID = layer_NS;
            //if (this.gameObject.layer == 8) { Debug.Log("레이어변경: 8"); }
        }
        else if (layerNum == 9)
        {
            this.gameObject.layer = 9;
            GetComponent<SpriteRenderer>().sortingLayerID = layer_S;
            //if (this.gameObject.layer == 9) { Debug.Log("레이어변경: 9"); }
        }
    }
}
