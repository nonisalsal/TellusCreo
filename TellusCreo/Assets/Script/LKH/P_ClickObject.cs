using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class P_ClickObject : MonoBehaviour
{
    [SerializeField] private GameObject pair;
    private bool hasPair = false;

    private bool isToyboxPuzzle = false;
    private P_PuzzleInfo toyInfo;

    private bool isLockedDrawer = false;
    private bool isLockedBedLeft = false;
    private bool isLockedLamp = false;

    private bool isFinalDoor = false;

    private void Awake()
    {
        if (pair != null)
        {
            hasPair = true;
            if (pair.name == "ToyBoxAfter")
            {
                isToyboxPuzzle = true;
                toyInfo = GameObject.Find("toybox_object").GetComponent<P_PuzzleInfo>();
            }
        }
    }

    void Start()
    {
        if (name == "drawer")
            isLockedDrawer = true;
        else if (name == "bed_left")
            isLockedBedLeft = true;
        else if (name == "switch_before")
            isLockedLamp = true;
        else if (name == "finalDoor_object")
            isFinalDoor = true;
    }

    private void PlayerInput()
    {
        if (P_GameManager.instance.isUp)
        {
            GameObject upHit = P_GameManager.instance.upHit.collider.gameObject;
            if (System.Object.ReferenceEquals(gameObject, upHit))
            {
                if (isToyboxPuzzle)
                {
                    Click_toyboxCover();
                    return;
                }

                if (isFinalDoor)
                {
                    Click_finalDoor();
                    return;
                }

                if (isLockedDrawer)
                    return;

                if (isLockedBedLeft)
                    return;

                if (isLockedLamp)
                {
                    if (!P_GameManager.instance.Get_wireConnect())
                        return;
                }

                if (hasPair)
                    pair.SetActive(true);

                gameObject.SetActive(false);
            }
        }
    }

    private void Click_toyboxCover()
    {
        toyInfo.IsActive_false();
        toyInfo.puzzleWindow = pair;
        toyInfo.IsActive_true();
    }

    private void Click_finalDoor()
    {
        bool isPlayroomClear = P_GameManager.instance.Get_isGetFinalItem();
        if (isPlayroomClear)
            SceneManager.LoadScene("livingroom");
        else
            Debug.Log("Need final item");
    }

    void Update()
    {
        PlayerInput();
    }
}
