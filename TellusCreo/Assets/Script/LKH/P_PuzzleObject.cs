using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PuzzleObject : MonoBehaviour
{
    // 스크립트 수정(05/18)
    // puzzleObj&Copy&Clear > P_puzzleInfo의 멤버변수로 옮긴다 + isClear도
    // P_PuzzleObject는 P_PuzzleObjects 오브젝트에서만 사용하도록
    // isActive를 꼭 안 사용해도 될듯
    // 카메라 이동도 P_Camera의 멤버 함수를 만들어서 그걸 실행하는 식으로 수정. >> static 사용해보기?
    // 퍼즐 보상(아이템) 추가
    // P_ClickObj랑 비교해가면서 퍼즐&오브젝트 순서 지정

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
            FindObjectOfType<P_Camera>().puzzlePos_x = puzzleObj.transform.position.x;
            FindObjectOfType<P_Camera>().puzzlePos_y = puzzleObj.transform.position.y;
            puzzleCopy = Instantiate(puzzleObj, puzzleObj.transform.position, puzzleObj.transform.rotation);
            puzzleCopy.SetActive(true);
            isClear = false;
        }
        else
        {
            puzzleClear = puzzleCopy;
            ClearControl();
            if (debugTest == 0)
            {
                Debug.Log("퍼즐 클리어");
                debugTest = 1;
            }
            parentObj.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    //private void ClockPuzzle()
    //{
    //    if (puzzleObj == clockPuzzle)
    //}
}
