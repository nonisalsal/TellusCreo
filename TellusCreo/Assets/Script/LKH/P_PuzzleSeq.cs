using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PuzzleSeq: MonoBehaviour
{
    private GameObject[] puzzleObj;
    private bool[] isActive;
    private bool[] isClear;

    public GameObject rayControl;

    void Start()
    {
        isActive = new bool[6] { false, false, false, false, false, false }; 
        isClear = new bool[6] { false, false, false, false, false, false };
    }

    void Update()
    {
        
    }
}
