using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PuzzleClear : MonoBehaviour
{
    private int length;
    // 퍼즐 오브젝트 변수 정의 
    //private GameObject doll1;
    //private GameObject doll2;
    //private GameObject picture;
    //private GameObject clock;
    public GameObject tower;
    public GameObject top;
    public GameObject puzzleObj;
    private GameObject puzzleCopy;

    private void Start()
    {
        length = 0;
        puzzleObj = GetComponent<P_PuzzleObject>().puzzleObj;
    }

    private void Update()
    {
        if (GetComponent<P_PuzzleObject>().isActive == true)
        {
            ClearCondition();
        }
    }

    private void ClearCondition()
    {
        puzzleCopy = GetComponent<P_PuzzleObject>().puzzleCopy;
        // 오브젝트 비교해서 각각 퍼즐 클리어 조건 넣어주기 
        if (System.Object.ReferenceEquals(puzzleObj, tower))
        {
            if (puzzleCopy.transform.Find("clearZone").GetComponent<P_TowerClearZone>().isRight == true)
            {
                GetComponent<P_PuzzleObject>().isClear = true;
                Rigidbody2D[] rigs = GetComponent<P_PuzzleObject>().puzzleClear.GetComponentsInChildren<Rigidbody2D>();
                foreach (Rigidbody2D rig in rigs)
                {
                    Destroy(rig);
                }
            }
        }
        else if (System.Object.ReferenceEquals(puzzleObj, top))
        {
            MonoBehaviour[] scripts = puzzleCopy.GetComponentsInChildren<P_Rotation>();
            length = scripts.Length;
            foreach (MonoBehaviour script in scripts)
            {
                if (script.GetComponent<P_Rotation>().isRotation == false) { break; }
                else
                {
                    if (script == scripts[length - 1])
                    {
                        GetComponent<P_PuzzleObject>().isClear = true;
                    }
                }
            }
        }
        else
        {
            MonoBehaviour[] scripts = puzzleCopy.GetComponentsInChildren<P_IsRightPos>();
            length = scripts.Length;
            foreach (MonoBehaviour script in scripts)
            {
                if (script.GetComponent<P_IsRightPos>().isRight == false) { break; }
                else
                {
                    if (script == scripts[length - 1])
                    {
                        //Debug.Log("last script");
                        GetComponent<P_PuzzleObject>().isClear = true;
                        Destroy(this.GetComponent<P_PuzzleClear>());
                    }
                }
            }
        }
    }
}
