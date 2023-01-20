using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PuzzleObject : MonoBehaviour
{
    public GameObject puzzleObj;
    private GameObject puzzleCopy;
    private bool isActive;
    public bool isClear;

    void Start()
    {
        isActive = false;
        isClear = false;
    }

    void Update()
    {
        if (GameObject.Find("MainCamera").GetComponent<P_Camera>().playPuzzle == false && isActive == true)
        {
            if (isClear == false) { Destroy(puzzleCopy); }
            else { puzzleCopy.SetActive(false); }
        }
        //test
        //if (Input.GetKeyUp(KeyCode.DownArrow))
        //{
        //    isClear = true;
        //}
    }

    private void OnMouseUp()
    {
        GameObject.Find("MainCamera").GetComponent<P_Camera>().playPuzzle = true;
        GameObject.Find("MainCamera").GetComponent<P_Camera>().puzzlePos_x = puzzleObj.transform.position.x;
        GameObject.Find("MainCamera").GetComponent<P_Camera>().puzzlePos_y = puzzleObj.transform.position.y;
        if (isClear == false)
        {
            puzzleCopy = Instantiate(puzzleObj, puzzleObj.transform.position, puzzleObj.transform.rotation);
        }
        //if (isClear == true)
        //{
            //puzzleObj = puzzleCopy;
            //GameObject.Find("MainCamera").GetComponent<P_Camera>().playPuzzle = false;
        //}
        puzzleCopy.SetActive(true);
        isActive = true;
    }
}
