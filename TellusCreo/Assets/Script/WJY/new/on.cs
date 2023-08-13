using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class on : MonoBehaviour
{
    public static on Instance; // 싱글톤 인스턴스

    public SpriteRenderer puzzleGuitarRenderer;
    public SpriteRenderer puzzleViolinRenderer;
    public SpriteRenderer[] puzzledrumRenderer;
    public SpriteRenderer[] puzzleKeyARenderer;
    public SpriteRenderer[] puzzleKeyBRenderer;

    public SpriteRenderer[] puzzleTopSpinRenderer;


    public Collider2D myCollider;
    public Collider2D myCollider2;


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
    }

    public void SpriteOn1()
    {
        puzzleViolinRenderer.enabled = true;
    }

    public void SpriteOn2()
    {
        foreach (SpriteRenderer renderer in puzzledrumRenderer)
        {
            renderer.enabled = true;
        }
    }

    public void SpriteOn3()
    {
        foreach (SpriteRenderer renderer in puzzleKeyARenderer)
        {
            renderer.enabled = true;
        }
        myCollider.enabled = true;
    }

    public void SpriteOn4()
    {
        foreach (SpriteRenderer renderer in puzzleKeyBRenderer)
        {
            renderer.enabled = true;
        }
        myCollider2.enabled = true;
    }

    public void SpriteOn5()
    {
        puzzleTopSpinRenderer[0].enabled = true;
        
    }

    public void SpriteOn6()
    {
        puzzleTopSpinRenderer[1].enabled = true;
      
    }

    public void SpriteOn7()
    {
        puzzleTopSpinRenderer[2].enabled = true;
   
    }
}