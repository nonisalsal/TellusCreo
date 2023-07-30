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

    public GameObject button;
    private bool destroyButton;

    private void Start()
    {
        playPuzzle = false;

        thisPos_x = this.transform.position.x;
        thisPos_y = this.transform.position.y;
        thisPos_z = this.transform.position.z;

        destroyButton = false;
        button.transform.GetChild(2).gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playPuzzle == true)
        {
            this.transform.position = new Vector3(puzzlePos_x, puzzlePos_y, thisPos_z);
            if (!destroyButton)
            {
                button.transform.GetChild(0).gameObject.SetActive(false);
                button.transform.GetChild(1).gameObject.SetActive(false);
                button.transform.GetChild(2).gameObject.SetActive(true);
                destroyButton = true;
            }
        }
        else
        {
            if (destroyButton)
            {
                button.transform.GetChild(0).gameObject.SetActive(true);
                button.transform.GetChild(1).gameObject.SetActive(true);
                button.transform.GetChild(2).gameObject.SetActive(false);
                destroyButton = false;
            }
        }
    }
}