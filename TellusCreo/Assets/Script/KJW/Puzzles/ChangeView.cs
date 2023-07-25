using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeView : ChangeSpriteObject
{
    [SerializeField]
    List<Sprite> changeWindowSprites;
    [SerializeField]
    List<Sprite> changeCircleSprties;
    [SerializeField]
    SpriteRenderer windowSpriteRenderer;

    private int _currentSpriteIndex = 0;

    protected override void ChangeObjectSprite()
    {
        if (changeWindowSprites == null || changeWindowSprites.Count <= 0)
        {
            return;
        }

        _spriteRenderer.sprite = changeCircleSprties[_currentSpriteIndex]; // 원판
        windowSpriteRenderer.sprite = changeWindowSprites[_currentSpriteIndex]; // 창문
        _currentSpriteIndex = (_currentSpriteIndex + 1) % changeWindowSprites.Count;
    }
}
