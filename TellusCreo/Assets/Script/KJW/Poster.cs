using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poster : MonoBehaviour
{
    LineRenderer _lr;
    [SerializeField]
    int _prevIdx;
    int _lineIdx;
    bool isStart;

    int cnt;
    Vector2 _prevPos;
    void Start()
    {
        isStart = false;
        _lineIdx = 0;
        _prevIdx = 0;
        cnt = 0;
        _lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cnt == transform.childCount)
            Debug.Log("Clear");

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 좌표 바꾸기
            RaycastHit2D hit = Physics2D.Raycast(mousPos, mousPos, 10f); // 레이캐스트
            if (hit.collider == null) // null이면 
                return;
            if (hit.collider.gameObject.layer == 8 && !hit.collider.GetComponent<PosterPoint>().isClick) // 레이어 8 (point인지)
            {
                cnt++;
                if (!isStart)
                {

                    _prevIdx = hit.collider.transform.GetSiblingIndex(); // 이전 선택 인덱스
                    isStart = true; // 시작퍼즐 판단
                    _lr.positionCount++; // 라인렌더러 ++
                    _lr.SetPosition(_lineIdx++, hit.collider.transform.position);
                    hit.collider.gameObject.GetComponent<PosterPoint>().PointEnabled();
                }
                else
                {
                    if (_prevIdx != hit.collider.transform.GetSiblingIndex())
                    {

                        _lr.positionCount++;
                        _lr.SetPosition(_lineIdx++, hit.collider.transform.position);
                        hit.collider.gameObject.GetComponent<PosterPoint>().PointEnabled();
                        //   hit.collider.gameObject.GetComponent<PosterPoint>().node.Add(_prevIdx); // 시작 위치의 노드를 리스트에 넣음

                        isStart = false;
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {

            for (int i = 0; i < transform.childCount; i++)
            {
                if (transform.GetChild(i).GetComponent<PosterPoint>().isClick)
                    transform.GetChild(i).GetComponent<PosterPoint>().PointEnabled();
            }
            _lr.positionCount = 0;
            _lineIdx = 0;
            _prevIdx = 0;
        }
    }
}
