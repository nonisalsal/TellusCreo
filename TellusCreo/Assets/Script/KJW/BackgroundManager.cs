using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField]
    List<Sprite> backGroundSpriteList;
    SpriteRenderer backGroundSpriteRenderer;
    int currentSpriteIndex = 0;
    [SerializeField]
    Sprite defaultSprite;

    void Awake()
    {
        InitSpriteRenderer();
    }

    void InitSpriteRenderer()
    {
        if (backGroundSpriteRenderer == null)
        {
            backGroundSpriteRenderer = GetComponent<SpriteRenderer>();
            if(backGroundSpriteRenderer == null)
            {
                backGroundSpriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
            }
            defaultSprite = backGroundSpriteRenderer.sprite;
        }
    }

    public void ChangeBackgroundSprite()
    {
        InitSpriteRenderer();

        if (backGroundSpriteList.Count == 0)
        {
#if UNITY_EDITOR
            Debug.LogError("backGroundSpriteList Empty");
#endif
            return;
        }

        currentSpriteIndex = (currentSpriteIndex + 1) % backGroundSpriteList.Count;
        backGroundSpriteRenderer.sprite = backGroundSpriteList[currentSpriteIndex];

    }

    public void ChangeBackgroundSprite(Sprite sprite)
    {
        if (sprite == null)
        {
#if UNITY_EDITOR
            Debug.LogError("Sprite is NULL");
#endif
        }

        InitSpriteRenderer();
        backGroundSpriteRenderer.sprite = sprite;
    }
}

