using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterPoint : MonoBehaviour
{
    public bool isClicked;
    SpriteRenderer spriteRenderer;


    LineRenderer _lr;
    [SerializeField]
    Transform _startPos;
    Vector2 _prevPos;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        isClicked = false;
    }


    public void OnPointClick()
    {
        isClicked = !isClicked;
    }
}
