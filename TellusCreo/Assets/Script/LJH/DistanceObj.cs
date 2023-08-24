using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DistanceObj : MonoBehaviour
{
    private float Dist; //양초 오브젝트와의 거리
    public GameObject candle; //양초 오브젝트

    SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Dist = Vector2.Distance(candle.transform.position, transform.position);

        ObjDist();
    }

    private void ObjDist()// 오브젝트의 거리에 따라 숨겨진 글씨의 투명도가 조절되는 함수
    {
        if(Dist > 9)
        {
            sr.material.color = new Color(1.0f, 1f, 1f, 0f);
        }
        if (8 < Dist && Dist <= 9)
        {
            sr.material.color = new Color(1.0f, 1f, 1f, 0.2f);
        }
        if (7 < Dist && Dist <= 8)
        {
            sr.material.color = new Color(1.0f, 1f, 1f, 0.3f);
        }

        if (6 < Dist && Dist <= 7)
        {
            sr.material.color = new Color(1.0f, 1f, 1f, 0.4f);
        }

        if (5 < Dist && Dist <= 6)
        {
            sr.material.color = new Color(1.0f,1f,1f,0.5f);
        }

        if (4 < Dist && Dist <= 5)
        {
            sr.material.color = new Color(1.0f, 1f, 1f, 0.6f);
        }
        if (3 < Dist && Dist <= 4)
        {
            sr.material.color = new Color(1.0f, 1f, 1f, 0.7f);
        }
        if (2 < Dist && Dist <= 3)
        {
            sr.material.color = new Color(1.0f, 1f, 1f, 0.8f);
        }

        if (0 < Dist && Dist <= 2)
        {
            sr.material.color = new Color(1.0f, 1f, 1f, 1f);
        }
    }
}
