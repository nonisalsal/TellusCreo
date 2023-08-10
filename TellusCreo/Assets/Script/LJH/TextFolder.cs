using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFolder : MonoBehaviour
{
    // Start is called before the first frame update
    public bool state = false; 

    void Start()
    {
        
        
    }


    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("StartFolder"))
        {
            state = false;
           // Debug.Log("꺼졌어요");

        }

        if (collision.CompareTag("TextFolder"))
        {
            if (state == true)
            {
                collision.gameObject.GetComponent<TextFolder>().state = false;
                //Debug.Log("bad");
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("StartFolder"))
        {
            state = true;
           
           
        }
        

        //if (collision.CompareTag("TextFolder"))
        //{
        //    if (state == true)
        //    {
        //        collision.gameObject.GetComponent<TextFolder>().state = true;
        //        Debug.Log("good");
        //    }
        //}
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("TextFolder"))
        {
            if (state == true)
            {
                collision.gameObject.GetComponent<TextFolder>().state = true;
                //Debug.Log("good");
            }
        }

    }

    


}
