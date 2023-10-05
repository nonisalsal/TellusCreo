using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowButton : MonoBehaviour
{
    [SerializeField]
    private ShadowPuzzle puzzle;

    private void OnMouseDown()
    {
        SoundManager.Instance.Play("light_switch");
        if (puzzle.IsOnStand)
        {
            UpdateShadowSprite();
        }
        else
        {

#if UNITY_EDITOR
            Debug.Log("스탠드 ON or 밝음 or 커튼 열림");
#endif
        }
    }

    void UpdateShadowSprite()
    {
        Sprite shadowSprite = puzzle?.ChangeShadow(); // 그림자만 변경 sprite 변경은 x
        if (GameManager.Instance.ShadowPuzzleChaeck()) // 전선 연결, 스탠드 켜짐, 어두움, 커튼이 닫힘 
        {
            GameManager.Instance.Curtain.GetComponent<SpriteRenderer>().sprite = shadowSprite;
        }
    }

}
