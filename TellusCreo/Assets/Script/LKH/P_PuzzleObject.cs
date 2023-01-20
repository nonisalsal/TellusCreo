using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PuzzleObject : MonoBehaviour
{
    public GameObject puzzleObj;

    //void Start()
    //{
        
    //}

    //void Update()
    //{

    //}

    private void OnMouseUp()
    {
        GameObject.Find("MainCamera").GetComponent<P_testing>().playPuzzle = true;
        GameObject.Find("MainCamera").GetComponent<P_testing>().puzzlePos_x = puzzleObj.transform.position.x;
        GameObject.Find("MainCamera").GetComponent<P_testing>().puzzlePos_y = puzzleObj.transform.position.y;
        puzzleObj.SetActive(true);
    }
}
