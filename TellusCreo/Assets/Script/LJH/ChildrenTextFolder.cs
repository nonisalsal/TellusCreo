using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrenTextFolder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public bool ChildrenState=false;
    // Update is called once per frame
    void Update()
    {
        //void OnTriggerStay2D(Collider2D collision)
        //{
        //    Debug.Log("접촉중");
        //    if (collision.CompareTag("TextFolder"))
        //    {
        //        if (GetComponent<TextFolder>().state == true)
        //        {
        //            ChildrenState = true;
        //        }
        //    }

        //}
        if (ChildrenState == true)
        {
            transform.GetComponentInParent<TextFolder>().state = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("접촉중");
        if (collision.CompareTag("TextFolder"))
        {
            if (GetComponent<TextFolder>().state == true)
            {
                ChildrenState = true;
            }
        }

    }
}
