using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPuzzle : MonoBehaviour
{

    public bool IsOnStand = false;

    [SerializeField]
    Sprite[] shadowSprite;
    List<Sprite> standSprites;
    int idx;
    const int SHADOW_COUNT = 3;
    SpriteRenderer spriteRenderer;


    void Start()
    {
       
        idx = -1;
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
            idx = (idx + 1) % SHADOW_COUNT;
            return shadowSprite[idx];
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
            return standSprites[0];
        }
        else
        {
            return standSprites[1];
        }
    }


}
