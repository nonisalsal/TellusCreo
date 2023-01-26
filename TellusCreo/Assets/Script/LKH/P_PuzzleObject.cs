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
    
    private int debugTest= 0;

    void Start()
    {
        isActive = false;
        isClear = false;
    }

    void Update()
    {
        if (rayControl.GetComponent<P_Camera>().playPuzzle == false && isActive == true)
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
        if (rayControl.GetComponent<P_Camera>().isUp == true)
        {
            RaycastHit2D upHit = rayControl.GetComponent<P_Camera>().upHit;
            if (upHit)
            {
                if (System.Object.ReferenceEquals(this.gameObject, upHit.collider.gameObject))
                {
                    //Debug.Log(upHit.collider.gameObject.name);
                    if (System.Object.ReferenceEquals(this.gameObject, upHit.collider.gameObject))
                    {
                        rayControl.GetComponent<P_Camera>().playPuzzle = true;
                        rayControl.GetComponent<P_Camera>().puzzlePos_x = puzzleObj.transform.position.x;
                        rayControl.GetComponent<P_Camera>().puzzlePos_y = puzzleObj.transform.position.y;
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
    }
}
