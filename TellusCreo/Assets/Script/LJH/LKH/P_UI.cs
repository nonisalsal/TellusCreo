using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_UI : MonoBehaviour
{
    //void Start()
    //{

    //}

    //void Update()
    //{

    //}

    public void ClickLeftArrow()
    {
        if (FindObjectOfType<P_Camera>().playPuzzle == false)
        {
            FindObjectOfType<P_Camera>().thisPos_x -= 20;
            if (FindObjectOfType<P_Camera>().thisPos_x < -30)
            {
                FindObjectOfType<P_Camera>().thisPos_x = 30;
            }
            FindObjectOfType<P_Camera>().transform.position =
                new Vector3(FindObjectOfType<P_Camera>().thisPos_x, FindObjectOfType<P_Camera>().thisPos_y, FindObjectOfType<P_Camera>().thisPos_z);
        }
    }

    public void ClickRightArrow()
    {
        if (FindObjectOfType<P_Camera>().playPuzzle == false)
        {
            FindObjectOfType<P_Camera>().thisPos_x += 20;
            if (FindObjectOfType<P_Camera>().thisPos_x > 30)
            {
                FindObjectOfType<P_Camera>().thisPos_x = -30;
            }
            FindObjectOfType<P_Camera>().transform.position =
                new Vector3(FindObjectOfType<P_Camera>().thisPos_x, FindObjectOfType<P_Camera>().thisPos_y, FindObjectOfType<P_Camera>().thisPos_z);
        }
    }

    public void ClickBackArrow()
    {
        if (FindObjectOfType<P_Camera>().playPuzzle == true)
        {
            FindObjectOfType<P_Camera>().transform.position = 
                new Vector3(FindObjectOfType<P_Camera>().thisPos_x, FindObjectOfType<P_Camera>().thisPos_y, FindObjectOfType<P_Camera>().thisPos_z);
            FindObjectOfType<P_Camera>().playPuzzle = false;
        }
    }
}
