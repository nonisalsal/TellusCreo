using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : MonoBehaviour
{
   
    public bool check1;
   
    void Start()
    {
        check1 = false;

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {


        if (collider.gameObject.name == "trophy")
        {
            check1 = true;
            Debug.Log("trophy");
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.name == "trophy")
        {
            check1 = false;
            //Debug.Log(0);
        }
    }
    
}
