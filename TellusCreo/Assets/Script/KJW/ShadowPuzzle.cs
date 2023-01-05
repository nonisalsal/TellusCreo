using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowPuzzle : MonoBehaviour
{


    public Sprite[] shadowObj = new Sprite[3];// 그림자 3개

    int idx;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = shadowObj[0];
        idx = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeShadow()
    {
        idx = (idx + 1) % 3;
        spriteRenderer.sprite = shadowObj[idx];
    }
}
