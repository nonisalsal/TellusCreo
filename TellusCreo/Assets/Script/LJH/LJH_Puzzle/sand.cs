using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sand : MonoBehaviour
{
    public bool check5;

    void Start()
    {
        check5 = false;

    }

    public void OnTriggerEnter2D(Collider2D collider)
    {


        if (collider.gameObject.name == "sand")
        {
            check5 = true;
            //Debug.Log(1);
            Debug.Log("sand");
        }
    }

    public void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.gameObject.name == "sand")
        {
            check5 = false;
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
