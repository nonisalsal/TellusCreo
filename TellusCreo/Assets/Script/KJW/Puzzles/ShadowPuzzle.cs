using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPuzzle : MonoBehaviour
{
    enum StandState
    {
        ON,
        OFF
    }

    enum Shadow
    {
        Cat,
        Dog,
        Rabbit
    }

    public bool IsOnStand = false;

    [SerializeField]
    Sprite[] shadowSprite;
    private const int SHADOW_COUNT = 3;
    private List<Sprite> standSprites;
    private int _idx;
    SpriteRenderer _spriteRenderer;
    Shadow shadow = Shadow.Cat;

    void Start()
    {
        _idx = -1;
    }

    void InitStandSprites()
    {
        standSprites = new List<Sprite>();
        standSprites.Add(Resources.Load<Sprite>("Sprites/KJW/Attic/Shadow/puzzle_shadow_light"));
        standSprites.Add(Resources.Load<Sprite>("Sprites/KJW/Attic/Shadow/puzzle_shadow_light_off"));
    }

    public Sprite ChangeShadow()
    {
        if (GameManager.Instance.ShadowPuzzleChaeck() == true)
        {
            _idx = (_idx + 1) % SHADOW_COUNT;
            shadow = (Shadow)_idx;
            return shadowSprite[_idx];
        }
        return null;
    }

    public Sprite Retunr2StandSprite()
    {
        if(standSprites==null)
        {
            InitStandSprites();
        }

        if(IsOnStand) // 켜져 있을 때
        {
            return standSprites[(int)StandState.ON];
        }
        else
        {
            return standSprites[(int)StandState.OFF];
        }
    }


}
