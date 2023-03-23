using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{

    [SerializeField]
    List<Sprite> backGroundSpriteList;
    
    SpriteRenderer backGroundSpriteRenderer;
    int currentSpriteIndex = 0;

    
    void Start()
    {
        backGroundSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ChangeBackgroundSprite()
    {
        currentSpriteIndex = (currentSpriteIndex + 1) % backGroundSpriteList.Count;
        backGroundSpriteRenderer.sprite = backGroundSpriteList[currentSpriteIndex]; 
    }
}
