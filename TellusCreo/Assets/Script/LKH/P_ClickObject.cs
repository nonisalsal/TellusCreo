using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

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

    private bool isPicturePuzzle = false;

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
        else if (name == "pieces")
            isPicturePuzzle = true;
    }

    private void PlayerInput()
    {
        if (P_GameManager.instance.isUp)
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;

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
                {
                    SoundManager.Instance.Play("Door_locked");
                    return;
                }

                if (isLockedBedLeft)
                {
                    SoundManager.Instance.Play("door_locked");
                    return;
                }

                if (isLockedLamp)
                {
                    if (!P_GameManager.instance.Get_wireConnect())
                        return;

                    SoundManager.Instance.Play("light_switch");
                }

                if (hasPair)
                    pair.SetActive(true);

                gameObject.SetActive(false);

                if (isLockedLamp) return;

                if (isPicturePuzzle)
                {
                    SoundManager.Instance.Play("open_lockedDoor");
                    return;
                }

                SoundManager.Instance.Play("door_sliding");
            }
        }
    }

    private void Click_toyboxCover()
    {
        SoundManager.Instance.Play("open_lockedDoor");
        toyInfo.IsActive_false();
        toyInfo.puzzleWindow = pair;
        toyInfo.IsActive_true();
    }

    private void Click_finalDoor()
    {
        bool isPlayroomClear = P_GameManager.instance.Get_isGetFinalItem();
        if (isPlayroomClear)
        {
            SceneManager.LoadScene("livingroom");
            EarthMaterial.GetInstance().SetSoilValue(true);
        }
            
       
        else
            SoundManager.Instance.Play("door_locked");

        return;
    }

    void Update()
    {
        PlayerInput();
    }

    public void Open_lockedBedLeft()
    {
        SoundManager.Instance.Play("open_lockedDoor");
        isLockedBedLeft = false;
    }

    public void Open_lockedDrawer()
    {
        SoundManager.Instance.Play("open_lockedDoor");
        isLockedDrawer = false;
    }
}
