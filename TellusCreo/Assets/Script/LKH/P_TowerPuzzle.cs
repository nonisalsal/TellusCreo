using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_TowerPuzzle : MonoBehaviour
{
    private int layer_S;
    private int layer_NS;

    private Vector2 beforePos;
    private Rigidbody2D rig;

    public bool isRight;

    void Start()
    {
        layer_S = SortingLayer.NameToID("P_Select");
        layer_NS = SortingLayer.NameToID("P_NotSelect");
        ChangeLayer(8);
        isRight = false;

        rig = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (this.tag == "P_building" && this.transform.position.y >= 4)
        {
            isRight = true;
        }
        else { isRight = false; }

        //if (this.tag == "P_building")
        //{
        //    rig.bodyType = RigidbodyType2D.Kinematic;
        //}
        //else
        //{
        //    rig.bodyType = RigidbodyType2D.Dynamic;
        //}
    }

    private void ChangeLayer(int layerNum)
    {
        if (layerNum == 8)
        {
            this.gameObject.layer = 8;
            GetComponent<SpriteRenderer>().sortingLayerID = layer_NS;
        }
        else if (layerNum == 9)
        {
            this.gameObject.layer = 9;
            GetComponent<SpriteRenderer>().sortingLayerID = layer_S;
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "clearZone")
        {
            isRight = true;
        }
        else
        {
            if(collision.contacts[0].normal.y >= 0.9f && collision.gameObject.name == "platform")
            {
                beforePos = this.transform.position;
            }
            else if(collision.contacts[0].normal.y < 0.9f)
            {
                this.transform.position = beforePos;
            }

            if (collision.contacts[0].normal.y < 0.9f)
            {
                if (collision.contacts[0].normal.x < 0.9f)
                {
                    this.transform.position = beforePos;
                }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name =="platform" || collision.gameObject.tag == "P_building")
        {
            this.tag = "P_building";
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "clearZone")
        {
            isRight = false;
        }
    }
}
