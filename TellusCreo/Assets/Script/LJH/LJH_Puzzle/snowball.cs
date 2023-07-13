using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snowball : MonoBehaviour
{
    // Start is called before the first frame update
    public bool check7;

    void Start()
    {
        check7 = false;

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {


        if (collider.gameObject.name == "snowball")
        {
            check7 = true;
            Debug.Log("snow");
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.name == "snowball")
        {
            check7 = false;
            //Debug.Log(0);
        }
    }
}
