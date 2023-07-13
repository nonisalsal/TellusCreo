using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lyingbook : MonoBehaviour
{
    public bool check6;

    void Start()
    {

        check6 = false;

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {


        if (collider.gameObject.name == "lyingbook")
        {
            check6 = true;
            Debug.Log(1);
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.name == "lyingbook")
        {

            check6 = false;
            Debug.Log("book");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
