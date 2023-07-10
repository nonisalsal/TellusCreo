using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPuzzle : MonoBehaviour
{
    enum StandStatus
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

    public Sprite ChangeShadow(bool change = true) // chagne 할지에 따라 변경 default 는 true
    {
        if (GameManager.Instance.ShadowPuzzleChaeck() == true)
        {
            if(change)
            {
            _idx = (_idx + 1) % SHADOW_COUNT;
            }
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
            return standSprites[(int)StandStatus.ON];
        }
        else
        {
            return standSprites[(int)StandStatus.OFF];
        }
    }


}
