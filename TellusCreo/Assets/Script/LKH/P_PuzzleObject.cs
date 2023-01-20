using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PuzzleObject : MonoBehaviour
{
    public GameObject puzzleObj;
    private GameObject puzzleCopy;
    private GameObject puzzleClear;
    public bool isActive;
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
            else { puzzleClear.SetActive(false); }
        }
        //test
        if (Input.GetKeyUp(KeyCode.DownArrow) && isActive == true)
        {
            isClear = true;
            puzzleClear = puzzleCopy;
        }

        disableScripts();
    }

    private void OnMouseUp()
    {
        GameObject.Find("MainCamera").GetComponent<P_Camera>().playPuzzle = true;
        GameObject.Find("MainCamera").GetComponent<P_Camera>().puzzlePos_x = puzzleObj.transform.position.x;
        GameObject.Find("MainCamera").GetComponent<P_Camera>().puzzlePos_y = puzzleObj.transform.position.y;
        if (isClear == false)
        {
            puzzleCopy = Instantiate(puzzleObj, puzzleObj.transform.position, puzzleObj.transform.rotation);
            puzzleCopy.SetActive(true);
        }
        if (isClear == true)
        {
            puzzleClear.SetActive(true);
            //GameObject.Find("MainCamera").GetComponent<P_Camera>().playPuzzle = false;
        }
        isActive = true;
    }

    private void disableScripts()
    {
        if (isClear == true)
        {
            Transform[] objList = puzzleClear.GetComponentsInChildren<Transform>();
            foreach (Transform obj in objList)
            {
                MonoBehaviour[] scripts = obj.GetComponents<MonoBehaviour>();
                foreach (MonoBehaviour script in scripts)
                {
                    script.enabled = false;
                }
            }
        }
    }
}
