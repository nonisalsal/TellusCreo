using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_testing : MonoBehaviour
{
    public bool playPuzzle = false;
    public float puzzlePos_x;
    public float puzzlePos_y;

    private void Start()
    {
        //playPuzzle = false;
    }

    private void Update()
    {
        if (playPuzzle == true)
        {
            this.transform.position = new Vector3(puzzlePos_x, puzzlePos_y, -10);
        }
    }
}
