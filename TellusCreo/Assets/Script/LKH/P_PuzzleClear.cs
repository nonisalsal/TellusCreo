using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PuzzleClear : MonoBehaviour
{
    [SerializeField] private GameObject puzzleObj;
    private P_PuzzleInfo puzzleInfo;

    private bool isDollPuzzle2;

    [SerializeField] private GameObject keyB;

    private void Awake()
    {
        puzzleInfo = puzzleObj.GetComponent<P_PuzzleInfo>();
    }

    private void Start()
    {
        if (gameObject.name == "DollPuzzle2")
            isDollPuzzle2 = true;
        else
            isDollPuzzle2 = false;
    }

    public void CheckClear_IsRightPos()
    {
        P_IsRightPos[] scripts = GetComponentsInChildren<P_IsRightPos>();
        int length = scripts.Length;

        foreach(P_IsRightPos script in scripts)
        {
            if (!script.Get_isRight())
                return;

            if (script == scripts[length - 1])
            {
                if (isDollPuzzle2 == true)
                    P_GameManager.instance.Set_dollClear();

                ClearCondition();
            }
        }
    }

    public void CheckClear_TopPuzzle()
    {
        P_Rotation[] scripts = transform.GetComponentsInChildren<P_Rotation>();
        int length = scripts.Length;

        foreach(P_Rotation script in scripts)
        {
            if (!script.Get_isRotation())
                return;

            else
            {
                if(script == scripts[length - 1])
                {
                    P_GameManager.instance.Set_topClear();

                    ClearCondition();
                }
            }
        }
    }

    public void CheckClear_TowerPuzzle()
    {
        Rigidbody2D[] rigs = GetComponentsInChildren<Rigidbody2D>();
        foreach (Rigidbody2D rig in rigs)
            Destroy(rig);

        keyB.SetActive(true);

        ClearCondition();
    }

    private void ClearCondition()
    {
        puzzleInfo.IsClear_true();

        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
            collider.enabled = false;

        Destroy(this);
    }
}
