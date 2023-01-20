using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterPoint : MonoBehaviour
{
    public bool isClick;
    SpriteRenderer render;


    LineRenderer _lr;
    [SerializeField]
    Transform _startPos;
    Vector2 _prevPos;

    public List<int> node = new List<int>();

    void Start()
    {
        render = GetComponent<SpriteRenderer>();

        isClick = false;

    }


    public void PointEnabled() // 클릭시 색깔 변경
    {
        if (isClick == false)
        {
            isClick = true;
            render.color = new Color(0, 0, 1);

        }
        else
        {
            isClick = false;
            render.color = new Color(1, 0, 0);
        }
    }
}
