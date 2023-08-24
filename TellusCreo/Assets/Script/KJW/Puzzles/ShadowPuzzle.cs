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

    public enum Shadow
    {
        Cat,
        Dog,
        Rabbit
    }

    public bool IsOnStand = false;
    public Shadow CurrentShadow { get => shadow; }
    public Item Jupiter;

    [SerializeField]
    List<Sprite> shadowSprites;
    [SerializeField]
    List<Sprite> dogShadowSprites;
    private const int SHADOW_COUNT = 3;
    private const float DogShadowAnimInterval = 1.5f;
    private List<Sprite> standSprites;
    private int _idx;
    private SpriteRenderer _spriteRenderer;
    private Shadow shadow = Shadow.Cat;

    private void Start()
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
        if (change)
        {
            _idx = (_idx + 1) % SHADOW_COUNT;
        }
        shadow = (Shadow)_idx;
        return shadowSprites[_idx];
    }

    public Sprite Return2StandSprite()
    {
        if (standSprites == null)
        {
            InitStandSprites();
        }

        if (IsOnStand) // 켜져 있을 때
        {
            return standSprites[(int)StandStatus.ON];
        }
        else
        {
            return standSprites[(int)StandStatus.OFF];
        }
    }

    public IEnumerator DogShadowCatchBall() // 강아지가 공을 가져오는 퍼즐
    {
        for (int i = 0; i < dogShadowSprites.Count; i++)
        {
            GameManager.Instance.Curtain.GetComponent<SpriteRenderer>().sprite = dogShadowSprites[i];
            yield return new WaitForSeconds(DogShadowAnimInterval);
        }
        GameManager instance = GameManager.Instance;
        Item jupiter = instance.Puzzles[(int)GameManager.Puzzle.ShadowLight - instance.NUMBER_OF_PUZZLES].GetComponent<ShadowPuzzle>().Jupiter;
        if(jupiter!= null)
        {
            InventoryManager.Instance.Add(jupiter);
        }
    }
}
