using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterPoint : MonoBehaviour
{
    public bool isClick;
    SpriteRenderer render;
    CapsuleCollider2D capsule;

    LineRenderer _lr;
    [SerializeField]
    Transform _startPos;
    Vector2 _prevPos;
    int _idx = 0;

    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        capsule = GetComponent<CapsuleCollider2D>();
        isClick = false;
        _startPos = transform;
        _lr = GetComponent<LineRenderer>();
        _lr.SetPosition(0, _startPos.position);
        _prevPos = _startPos.position;
    }


    public void PointEnabled()
    {
        if (isClick == false)
        {
            isClick = true;
            render.color = new Color(0, 0, 1);
            capsule.enabled = false;
        }
        else
        {
            isClick = false;
            render.color = new Color(1, 0, 0);
            capsule.enabled = true;
        }
    }

    void Update()
    {
        if (isClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 좌표 바꾸기
                RaycastHit2D hit = Physics2D.Raycast(_startPos.position, mousPos, 10f); // 레이캐스트
                Debug.Log(transform.name);
                if (hit.collider == null) // null이면 
                    return;
                if (hit.collider.gameObject.layer == 8) // 레이어 8 (point인지)
                {
                  //  hit.collider.gameObject.GetComponent<PosterPoint>().PointEnabled();
                    //  hit.collider.gameObject.GetComponent<PosterPoint>().isPoint = true;

                    if (_lr.positionCount > _idx)
                    {
                        _lr.positionCount++;
                        _lr.SetPosition(_idx, hit.collider.transform.position);
                        _idx++;
                    }

                    if (_idx - 1 >= 0)
                    {
                        _lr.SetPosition(_idx - 1, _prevPos);
                        _prevPos = hit.collider.transform.position;

                    }


                }
            }

        }
        else
        { }
        //{
        //    if (Input.GetMouseButtonDown(1))
        //    {
        //        int cnt = _lr.positionCount;

        //        for (int i = 0; i < cnt - 1; i++)
        //        {
        //            _lr.positionCount--;
        //        }

        //        _lr.SetPosition(0, _startPos.position);
        //        _idx = 0;
        //    }
        
    }
}
