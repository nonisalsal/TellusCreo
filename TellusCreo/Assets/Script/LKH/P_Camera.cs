using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Camera : MonoBehaviour
{
    public bool playPuzzle;
    public float puzzlePos_x;
    public float puzzlePos_y;

    public float thisPos_x;
    public float thisPos_y;
    public float thisPos_z;

    private bool destroyButton;

    private void Start()
    {
        playPuzzle = false;

        thisPos_x = this.transform.position.x;
        thisPos_y = this.transform.position.y;
        thisPos_z = this.transform.position.z;

        destroyButton = false;
        GameObject.Find("Button").transform.GetChild(2).gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playPuzzle == true)
        {
            this.transform.position = new Vector3(puzzlePos_x, puzzlePos_y, thisPos_z);
            //if (Input.GetKeyUp(KeyCode.UpArrow))
            //{
            //    this.transform.position = new Vector3(thisPos_x, thisPos_y, thisPos_z);
            //    playPuzzle = false;
            //}
            if (!destroyButton)
            {
                GameObject.Find("Button").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.Find("Button").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.Find("Button").transform.GetChild(2).gameObject.SetActive(true);
                destroyButton = true;
            }
        }
        else
        {
            if (destroyButton)
            {
                GameObject.Find("Button").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("Button").transform.GetChild(1).gameObject.SetActive(true);
                GameObject.Find("Button").transform.GetChild(2).gameObject.SetActive(false);
                destroyButton = false;
            }
        }
    }
}
