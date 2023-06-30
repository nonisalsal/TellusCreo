using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    // Start is called before the first frame update
    public bool check3;

    void Start()
    {
        check3 = false;

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {


        if (collider.gameObject.name == "clock")
        {
            check3 = true;
            //Debug.Log(1);
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.name == "clock")
        {
            check3 = false;
            //Debug.Log(0);
        }
    }
   
}
