using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClueManager : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> spritesForChange;
    [SerializeField]
    private GameObject clue;
    private int _index;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>() ?? gameObject.AddComponent<SpriteRenderer>();
        _index = 0;

    }

    void OnMouseDown()
    {
        if (spritesForChange.Count > 0)
        {
            Sprite sprite = spritesForChange[_index];
            _index = (_index + 1) % spritesForChange.Count;
            spriteRenderer.sprite = sprite;
        }
        ShowClue();
    }

    public void ShowClue()
    {
        if(clue != null)
        {
            clue.SetActive(true);
        }
    }
}
