using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Poster : MonoBehaviour
{

    LineRenderer _lr;

    int _prevIdx;
    int _curIdx;
    int _lineIdx;

    bool isStart;
    [SerializeField]
    bool correct;
    bool clearPuzzle;

    [SerializeField]
    int cnt;


    void Start()
    {
        clearPuzzle = false;
        correct = true;
        isStart = false;
        _lineIdx = 0;
        _prevIdx = -1;
        _curIdx = -1;
        cnt = 0;
        _lr = GetComponent<LineRenderer>();
    }



    // Update is called once per frame
    //void Update()
    //{

    //    if (cnt == transform.childCount && !clearPuzzle) // 만약 
    //    {
    //        if (correct)
    //        {
    //            Debug.Log("Clear");
    //            GameManager.Instance[(int)GameManager.Puzzle.Poster - 10] = true;
    //            clearPuzzle = true;
    //        }
    //        else
    //        {
    //            Invoke("InitPuzzle", 1f);
    //            Debug.Log("Fail");
    //        }
    //    }

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // 마우스 좌표 바꾸기
    //        RaycastHit2D hit = Physics2D.Raycast(mousPos, mousPos, 10f); // 레이캐스트
    //        if (hit.collider == null) // null이면 return
    //            return;
    //        if (hit.collider.gameObject.layer == 8 && !hit.collider.GetComponent<PosterPoint>().isClick) // 레이어 8 (point인지) 선택안된거라면
    //        {
    //            cnt++;

    //            if (_prevIdx != hit.collider.transform.GetSiblingIndex()) // 눌렀는데 자기 자신이 아니라면
    //            {
    //                _curIdx = hit.collider.transform.GetSiblingIndex();// 현재 선택

    //                if (correct && _prevIdx != -1) // 처음이 아니고 이전에 false가 아니면
    //                {
    //                    if (_curIdx != _prevIdx + 1) // 순서가 아니면
    //                    {
    //                        correct = false;
    //                    }
    //                }
    //                _prevIdx = _curIdx;
    //                _lr.positionCount++;
    //                _lr.SetPosition(_lineIdx++, hit.collider.transform.position);
    //                hit.collider.gameObject.GetComponent<PosterPoint>().PointEnabled();
    //                isStart = false;
    //            }

    //        }
    //    }
    //    else if (Input.GetMouseButtonDown(1))
    //    {
    //        InitPuzzle();
    //    }
    //}

    void Update()
    {
        if (clearPuzzle) return;

        if (cnt == transform.childCount && !clearPuzzle)
        {
            if (correct)
            {
                Debug.Log("Clear");
                GameManager.Instance[(int)GameManager.Puzzle.Poster - 10] = true;
                clearPuzzle = true;
            }
            else
            {
                Invoke("InitPuzzle", 1f);
                Debug.Log("Fail");
            }
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, mousePos, 10f);
            if (hit.collider == null || hit.collider.gameObject.layer != 8 || hit.collider.GetComponent<PosterPoint>().isClick)
            {
                return;
            }

            cnt++;
            _curIdx = hit.collider.transform.GetSiblingIndex();
            if (_prevIdx != -1 && _curIdx != _prevIdx + 1)
            {
                correct = false;
            }
            _prevIdx = _curIdx;
            _lr.positionCount++;
            _lr.SetPosition(_lineIdx++, hit.collider.transform.position);
            hit.collider.gameObject.GetComponent<PosterPoint>().PointEnabled();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            InitPuzzle();
        }
    }

    void InitPuzzle()
    {

        //for (int i = 0; i < transform.childCount; i++)
        //{
        //    if (transform.GetChild(i).GetComponent<PosterPoint>().isClick)
        //        transform.GetChild(i).GetComponent<PosterPoint>().PointEnabled();
        //}

        foreach (Transform child in transform)
        {
            if (child.GetComponent<PosterPoint>().isClick)
            {
                child.GetComponent<PosterPoint>().PointEnabled();
            }
        }

        _lr.positionCount = 0;
        _lineIdx = 0;
        _prevIdx = -1;
        _curIdx = -1;
        correct = true;
        cnt = 0;
    }
}
