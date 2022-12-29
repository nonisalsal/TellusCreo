using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Camera : MonoBehaviour
{
    public bool playPuzzle;
    public float puzzlePos_x;
    public float puzzlePos_y;

    private float thisPos_x;
    private float thisPos_y;
    private float thisPos_z;

    private void Start()
    {
        playPuzzle = false;

        thisPos_x = this.transform.position.x;
        thisPos_y = this.transform.position.y;
        thisPos_z = this.transform.position.z;
    }

    private void Update()
    {
        if (playPuzzle == true)
        {
            this.transform.position = new Vector3(puzzlePos_x, puzzlePos_y, thisPos_z);
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                this.transform.position = new Vector3(thisPos_x, thisPos_y, thisPos_z);
                playPuzzle = false;
            }
        }
        else
        {
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                thisPos_x += 20;
                if (thisPos_x > 30)
                {
                    thisPos_x = -30;
                }
                this.transform.position = new Vector3(thisPos_x, thisPos_y, thisPos_z);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                thisPos_x -= 20;
                if (thisPos_x < -30)
                {
                    thisPos_x = 30;
                }
                this.transform.position = new Vector3(thisPos_x, thisPos_y, thisPos_z);
            }
        }
    }
}
