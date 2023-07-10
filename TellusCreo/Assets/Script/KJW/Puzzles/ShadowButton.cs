using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowButton : MonoBehaviour
{
    [SerializeField]
    private ShadowPuzzle puzzle;
    GameObject _backGround2;

    private void Start()
    {
        _backGround2 = GameObject.FindGameObjectWithTag("Background2");
    }

    private void OnMouseDown() // 오류 수정하기
    {
        if (puzzle.IsOnStand && GameManager.Instance.ShadowPuzzleChaeck() &&
           !GameManager.Instance.GetCurtainStatus()) // 스탠드 켜짐, 어두움, 커튼이 닫힘 
        {
            _backGround2.GetComponent<SpriteRenderer>().sprite = puzzle.ChangeShadow();
        }
        else
        {
#if UNITY_EDITOR
            Debug.LogError("스탠드 ON or 밝음 or 커튼 열림");
#endif
        }
    }

}
