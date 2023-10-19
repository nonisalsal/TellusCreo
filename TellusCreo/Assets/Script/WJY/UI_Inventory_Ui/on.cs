using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class on : MonoBehaviour
{
    public static on Instance; // 싱글톤 인스턴스

    public SpriteRenderer puzzleGuitarRenderer;
    public SpriteRenderer puzzleViolinRenderer;
    public SpriteRenderer[] puzzledrumRenderer;
    public SpriteRenderer[] puzzleConcentRenderer;
    public SpriteRenderer[] puzzleTopSpinRenderer;

    public P_ClickObject puzzleKeyAScript;
    public P_ClickObject puzzleKeyBScript;

    public Collider2D myCollider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // 인스턴스를 설정
        }
        else
        {
            Destroy(gameObject); // 이미 인스턴스가 있으면 이 객체를 파괴하여 중복 생성 방지
        }
    }

    public void SpriteOn()
    {
        puzzleGuitarRenderer.enabled = true;
        puzzleGuitarRenderer.GetComponent<P_IsRightPos>().IsRight_true();
    }

    public void SpriteOn1()
    {
        puzzleViolinRenderer.enabled = true;
        puzzleViolinRenderer.GetComponent<P_IsRightPos>().IsRight_true();
    }

    public void SpriteOn2()
    {
        foreach (SpriteRenderer renderer in puzzledrumRenderer)
        {
            renderer.enabled = true;
        }
        puzzledrumRenderer[0].transform.parent.gameObject.GetComponent<P_IsRightPos>().IsRight_true();
    }

    public void SpriteOn3()
    {
        puzzleKeyAScript.Open_lockedBedLeft();
    }

    public void SpriteOn4()
    {
        puzzleKeyBScript.Open_lockedDrawer();
    }

    public void SpriteOn5()
    {
        puzzleTopSpinRenderer[0].enabled = true;
        puzzleTopSpinRenderer[0].GetComponent<P_Rotation>().CheckTrigger();
        SoundManager.Instance.Play("p_drop");
    }

    public void SpriteOn6()
    {
        puzzleTopSpinRenderer[1].enabled = true;
        puzzleTopSpinRenderer[1].GetComponent<P_Rotation>().CheckTrigger();
        SoundManager.Instance.Play("p_drop");
    }

    public void SpriteOn7()
    {
        puzzleTopSpinRenderer[2].enabled = true;
        puzzleTopSpinRenderer[2].GetComponent<P_Rotation>().CheckTrigger();
        SoundManager.Instance.Play("p_drop");
    }

    public void SpriteOn8()
    {
        puzzleConcentRenderer[0].enabled = false;
        puzzleConcentRenderer[1].enabled = true;
        P_GameManager.instance.Set_wireConnect();
        SoundManager.Instance.Play("light_switch");
    }
}