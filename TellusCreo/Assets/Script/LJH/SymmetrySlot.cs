using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SymmetrySlot : MonoBehaviour
{
    public bool check;

    void Start()
    {
       check = false;

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        

        if (collider.gameObject.name == "123")
        {
            check = true;
            //Debug.Log(123);
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
       
        if (collider.gameObject.name == "123")
        {
            check = false;
            //Debug.Log(1);
        }
    }


}
