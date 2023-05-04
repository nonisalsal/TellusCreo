using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PuzzleInfo: MonoBehaviour
{
    public GameObject window;

    public void moveCamera()
    {
        FindObjectOfType<P_Camera>().puzzlePos_x = window.transform.position.x;
        FindObjectOfType<P_Camera>().puzzlePos_y = window.transform.position.y;
        FindObjectOfType<P_Camera>().playPuzzle = true;
    }
}
