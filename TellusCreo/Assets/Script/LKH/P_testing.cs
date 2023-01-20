using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_testing : MonoBehaviour
{
    public int length;

    private void Start()
    {
        length = 0;
    }

    private void Update()
    {
        if (GetComponent<P_PuzzleObject>().isActive == true)
        {
            if (GetComponent<P_PuzzleObject>().puzzleObj.name != "TopPuzzle" && GetComponent<P_PuzzleObject>().puzzleObj.name != "TowerPuzzle")
            {
                //GameObject[] clearObj = GameObject.FindObjectOfType("")
            }
        }
    }
}
