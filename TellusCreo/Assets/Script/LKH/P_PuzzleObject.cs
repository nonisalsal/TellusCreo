using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PuzzleObject : MonoBehaviour
{
    public GameObject puzzleObj;
    public GameObject puzzleCopy;
    private GameObject puzzleClear;
    public bool isActive;
    public bool isClear;

    public GameObject upHit;

    private int debugTest= 0;

    void Start()
    {
        isActive = false;
        isClear = false;
    }

    void Update()
    {
        if (GameObject.Find("MainCamera").GetComponent<P_Camera>().playPuzzle == false && isActive == true)
        {
            if (isClear == false) { 
                Destroy(puzzleCopy);
                isActive = false;
            }
            else { 
                puzzleClear.SetActive(false);
                isActive = false;
            }
        }
        //test
        //if (Input.GetKeyUp(KeyCode.DownArrow) && isActive == true)
        //{
        //    isClear = true;
        //}
        if (isClear == true)
        {
            puzzleClear = puzzleCopy;
            ClearControl();
            if (debugTest == 0)
            {
                Debug.Log("퍼즐 클리어");
                debugTest = 1;
            }
        }

        PlayerInput();
    }

    //private void OnMouseUp()
    //{
    //    GameObject.Find("MainCamera").GetComponent<P_Camera>().playPuzzle = true;
    //    GameObject.Find("MainCamera").GetComponent<P_Camera>().puzzlePos_x = puzzleObj.transform.position.x;
    //    GameObject.Find("MainCamera").GetComponent<P_Camera>().puzzlePos_y = puzzleObj.transform.position.y;
    //    if (isClear == false)
    //    {
    //        puzzleCopy = Instantiate(puzzleObj, puzzleObj.transform.position, puzzleObj.transform.rotation);
    //        puzzleCopy.SetActive(true);
    //    }
    //    if (isClear == true)
    //    {
    //        puzzleClear.SetActive(true);
    //        //GameObject.Find("MainCamera").GetComponent<P_Camera>().playPuzzle = false;
    //    }
    //    isActive = true;
    //}

    private void PlayerInput()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // 한 스크립트에서만 레이 쏘고 그 레이를 가져다 쓰는 방식 -> 왜 안되지?
            Vector2 upPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D upRay = new Ray2D(upPos, Vector2.zero);
            RaycastHit2D upHit = Physics2D.Raycast(upRay.origin, upRay.direction);
            if (upHit)
            {
                //Debug.Log(upHit.collider.gameObject.name);
                if (System.Object.ReferenceEquals(this.gameObject, upHit.collider.gameObject))
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
            }
        }
    }

    private void ClearControl()
    {
        // 오브젝트 콜라이더를 비활성화해서 조작하지 못하게 함
        GameObject puzzleClear = GetComponent<P_PuzzleObject>().puzzleClear;
        Collider2D[] colliders = puzzleClear.GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }
    }
}
