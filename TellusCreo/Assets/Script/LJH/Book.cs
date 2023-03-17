using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public GameObject BookChild;
    public Vector2 trans;
    public bool CollideCheck = false;
    void Start()
    {
        Vector2 pos;
        BookChild = this.gameObject;
        pos = this.gameObject.transform.position;

       CollideCheck= false;

        trans = pos;
       Debug.Log(pos);
       Debug.Log(pos.y);


    }

    // Update is called once per frame
    void Update()
    {
       NotCollide();
    }


    //}
    public void NotCollide()
    {
        if (this.gameObject.CompareTag("P_stop"))
        {
            transform.position = new Vector2(trans.x, trans.y);
        }
    }

    public void OnTriggerStay2D(Collider2D collider)
    {

        CollideCheck= true;


    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        //if (this.gameObject.CompareTag("P_stop")) //이동시키는 물체가 멈출 때
        //{
        //    if(collider == null)
        //    {
        //        transform.position = new Vector2(trans.x, trans.y);
        //    }
           

        //}
        CollideCheck= false;
    }



}

