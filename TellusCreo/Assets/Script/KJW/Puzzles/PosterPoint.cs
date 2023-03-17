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
        spriteRenderer.color = isClicked ? Color.blue : Color.red;
    }

    //public void PointEnabled() // 클릭시 색깔 변경
    //{
    //    if (isClick == false)
    //    {
    //        isClick = true;
    //        render.color = new Color(0, 0, 1);

    //    }
    //    else
    //    {
    //        isClick = false;
    //        render.color = new Color(1, 0, 0);
    //    }
    //}
}
