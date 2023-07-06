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
       _backGround2.GetComponent<SpriteRenderer>().sprite =  puzzle.ChangeShadow();
    }

}
