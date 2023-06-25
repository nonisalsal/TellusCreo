using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{

    [SerializeField]
    List<Sprite> backGroundSpriteList;
    [SerializeField]
    ShadowPuzzle shadowPuzzle;
    SpriteRenderer backGroundSpriteRenderer;
    int currentSpriteIndex = 0;

    
    void Awake()
    {
        backGroundSpriteRenderer = GetComponent<SpriteRenderer>();
    }
  
    public void ChangeBackgroundSprite()
    {
        if(backGroundSpriteRenderer==null)
        {
            backGroundSpriteRenderer = GetComponent<SpriteRenderer>();
        }
        currentSpriteIndex = (currentSpriteIndex + 1) % backGroundSpriteList.Count;
        backGroundSpriteRenderer.sprite = backGroundSpriteList[currentSpriteIndex]; 
    }

    public void ChagneBackgroundsForShadow() // 그림자 변경
    {
        if(shadowPuzzle==null)
        {
            shadowPuzzle = FindObjectOfType<ShadowPuzzle>();
        }

        Sprite shadowSprite = shadowPuzzle.ChangeShadow();
        if (shadowSprite != null)
        {
            backGroundSpriteRenderer.sprite = shadowSprite;
        }    
    }
}
