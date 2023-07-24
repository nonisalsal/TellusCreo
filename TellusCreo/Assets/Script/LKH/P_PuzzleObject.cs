using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PuzzleObject : MonoBehaviour
{
    public GameObject puzzleObj;
    public GameObject puzzleCopy;
    public GameObject puzzleClear;
    public bool isActive;
    public bool isClear;

    public GameObject rayControl;

    public GameObject dollPuzzle1;
    public GameObject dollPuzzle2;
    public GameObject parentObj;

    private int debugTest= 0;

    // 임시
    public bool hasClear;
    private bool isDoll2;

    void Start()
    {
        isActive = false;
        isClear = false;
        parentObj = transform.parent.gameObject;
        if (System.Object.ReferenceEquals(puzzleObj, parentObj.transform.GetChild(2).gameObject))
        {
            Debug.Log(this.name);
            this.gameObject.SetActive(false);
        }

        // 임시
        //if (puzzleObj.name == "ClockPuzzle" || puzzleObj.name == "ToyBox" || puzzleObj.name == "DollPuzzle1" || puzzleObj.name == "PicturePuzzle")
        //    hasClear = true;
        if (puzzleClear != null)
            hasClear = true;
        else
            hasClear = false;

        if (puzzleObj.name == "DollPuzzle2")
            isDoll2 = true;
        else
            isDoll2 = false;
    }

    private void ExitPuzzle()
    {
        if (FindObjectOfType<P_Camera>().playPuzzle == false && isActive == true)
        {
            if (isClear == false)
            {
                Destroy(puzzleCopy);
                isActive = false;
            }
            else
            {
                puzzleClear.SetActive(false);
                isActive = false;
            }
        }

        if (isClear == true)
        {
            DollPuzzle();
        }

        PlayerInput();
    }

    void Update()
    {
        ExitPuzzle();
    }

    private void ClearControl()
    {
        Collider2D[] colliders = puzzleClear.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }
    }

    private void PlayerInput()
    {
        if (rayControl.GetComponent<P_GameManager>().isUp == true)
        {
            //Debug.Log("uphit true");
            RaycastHit2D upHit = rayControl.GetComponent<P_GameManager>().upHit;
            if (upHit)
            {
                if (System.Object.ReferenceEquals(this.gameObject, upHit.collider.gameObject))
                {
                    FindObjectOfType<P_Camera>().playPuzzle = true;
                    FindObjectOfType<P_Camera>().puzzlePos_x = puzzleObj.transform.position.x;
                    FindObjectOfType<P_Camera>().puzzlePos_y = puzzleObj.transform.position.y;
                    //임시(2023.07/22)
                    if (isDoll2)
                    {
                        puzzleObj.SetActive(true);
                        isActive = true;
                        return;
                    }
                    if (isClear == false)
                    {
                        puzzleCopy = Instantiate(puzzleObj, puzzleObj.transform.position, puzzleObj.transform.rotation);
                        puzzleCopy.SetActive(true);
                    }
                    if (isClear == true)
                    {
                        puzzleClear.SetActive(true);
                    }
                    isActive = true;
                }
            }
        }
    }

    private void DollPuzzle()
    {
        if (puzzleObj == dollPuzzle1)
        {
            Destroy(puzzleCopy);
            puzzleObj = dollPuzzle2;
            //FindObjectOfType<P_Camera>().puzzlePos_x = puzzleObj.transform.position.x;
            //FindObjectOfType<P_Camera>().puzzlePos_y = puzzleObj.transform.position.y;
            //puzzleCopy = Instantiate(puzzleObj, puzzleObj.transform.position, puzzleObj.transform.rotation);
            //puzzleCopy.SetActive(true);
            puzzleObj.SetActive(true);
            isClear = false;
            this.gameObject.AddComponent<P_PuzzleClear>();
        }
        else
        {
            if (hasClear)
            {
                puzzleClear.SetActive(true);
                Destroy(puzzleCopy);
                return;
            }

            // 성공 시, 특수한 화면이 출력되어야하는 퍼즐: doll2 / tower? / clock 
            puzzleClear = puzzleCopy;
            ClearControl();
            if (debugTest == 0)
            {
                Debug.Log("퍼즐 클리어");
                debugTest = 1;
            }
            parentObj.transform.GetChild(2).gameObject.SetActive(true);
        }

        //if (hasClear)
        //{
        //    puzzleClear.SetActive(true);
        //    Destroy(puzzleCopy);
        //    return;
        //}

        //// 성공 시, 특수한 화면이 출력되어야하는 퍼즐: doll2 / tower? / clock 
        //puzzleClear = puzzleCopy;
        //ClearControl();
        //if (debugTest == 0)
        //{
        //    Debug.Log("퍼즐 클리어");
        //    debugTest = 1;
        //}
        //parentObj.transform.GetChild(2).gameObject.SetActive(true);
    }
}
