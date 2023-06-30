using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basket : MonoBehaviour
{
    // Start is called before the first frame update
    public bool check4;

    void Start()
    {
        check4 = false;

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {


        if (collider.gameObject.name == "basket")
        {
            check4 = true;
            //Debug.Log(1);
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.name == "basket")
        {
            check4 = false;
            //Debug.Log(0);
        }
    }
    void Update()
    {
        
    }
}
