using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PuzzleInfo : MonoBehaviour
{
    public GameObject puzzleObj;
    public GameObject puzzleClear;

    public GameObject puzzleWindow;

    private bool isClear;
    private bool hasClear;

    [SerializeField] private GameObject dollClear;

    private void Start()
    {
        puzzleWindow = puzzleObj;
        puzzleWindow.SetActive(false);

        isClear = false;
        if (puzzleClear != null)
        {
            hasClear = true;
            puzzleClear.SetActive(false);
        }
        else
            hasClear = false;
    }

    public void IsActive_true() { puzzleWindow.SetActive(true); }

    public void IsActive_false() { puzzleWindow.SetActive(false); }

    public void IsClear_true()
    {
        isClear = true;
        if (hasClear)
        {
            puzzleWindow.SetActive(false);
            puzzleWindow = puzzleClear;
            puzzleWindow.SetActive(true);
        }

        if (dollClear != null)
        {
            isClear = false;
            hasClear = true;
            puzzleClear = dollClear;
            dollClear = null;
        }
    }

    public bool Get_isClear() { return isClear; }
}
