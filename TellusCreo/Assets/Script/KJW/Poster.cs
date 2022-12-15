using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poster : MonoBehaviour
{
    LineRenderer _lr;
    [SerializeField]
    int _idx;
    void Start()
    {
        _idx = 0;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 좌표 바꾸기
            RaycastHit2D hit = Physics2D.Raycast(mousPos, mousPos, 10f); // 레이캐스트
            if (hit.collider == null) // null이면 
                return;
            if (hit.collider.gameObject.layer == 8) // 레이어 8 (point인지)
            {
                //if (transform.GetChild(_idx).GetComponent<PosterPoint>().isClick)
                //{
                //   // transform.GetChild(_idx).GetComponent<PosterPoint>().PointEnabled();
                //}
                //else
                //{
                    hit.collider.gameObject.GetComponent<PosterPoint>().PointEnabled();
                    _idx = hit.collider.transform.GetSiblingIndex();
              //  }

              
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {

            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<PosterPoint>().isClick)
                    transform.GetChild(i).GetComponent<PosterPoint>().PointEnabled();
            }
            _idx = 0;
        }
    }
}
