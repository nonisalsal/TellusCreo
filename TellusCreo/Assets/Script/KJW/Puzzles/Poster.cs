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
    bool clearPuzzle;
    [SerializeField]
    bool correct;
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

    //void Update()
    //{
    //    if (clearPuzzle) return;

    //    if (cnt == transform.childCount && !clearPuzzle)
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
    //        return;
    //    }

    //    if (Input.GetMouseButton(0))
    //    {
    //        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        RaycastHit2D hit = Physics2D.Raycast(mousePos, mousePos, 10f);
    //        if (hit.collider == null || hit.collider.gameObject.layer != 8 || hit.collider.GetComponent<PosterPoint>().isClicked)
    //        {
    //            return;
    //        }
    //        cnt++;
    //        _curIdx = hit.collider.transform.GetSiblingIndex();
    //        if (_prevIdx != -1 && _curIdx != _prevIdx + 1)
    //        {
    //            correct = false;
    //        }
    //        _prevIdx = _curIdx;
    //        _lr.positionCount++;
    //        _lr.SetPosition(_lineIdx++, hit.collider.transform.position);
    //        hit.collider.gameObject.GetComponent<PosterPoint>().OnPointClick();
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
            return;
        }

        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero); 
            if (hit.collider == null || hit.collider.gameObject.layer != 8 || hit.collider.GetComponent<PosterPoint>().isClicked)
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
            hit.collider.GetComponent<PosterPoint>().OnPointClick();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            InitPuzzle();
        }
    }

    void InitPuzzle()
    {
        foreach (PosterPoint point in GetComponentsInChildren<PosterPoint>()) // PosterPoint 컴포넌트를 가진 자식 객체들을 반복합니다.
        {
            if (point.isClicked)
            {
                point.OnPointClick();
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
