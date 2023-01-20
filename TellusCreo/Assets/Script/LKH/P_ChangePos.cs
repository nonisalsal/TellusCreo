using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ChangePos : MonoBehaviour
{
    public Vector2 beforePos;
    public Vector2 afterPos;

    private bool isMove = false;
    public bool isSet = true;
    private bool startOnTrig = false;

    private int checkLayer;

    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    IEnumerator StartSet()
    {
        yield return null;
        SetObj();
        //Debug.Log("SetObj 실행");
    }

    private void FixedUpdate()
    {
        if (startOnTrig)
        {
            StartCoroutine(StartSet());
        }
    }

    private void Update()
    {
        if (this.CompareTag("P_move")) { isMove = true; }
        else { isMove = false; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isSet && collision.CompareTag("P_stop"))
        {
            afterPos = collision.transform.localPosition;
            collision.transform.localPosition = beforePos;
            beforePos = afterPos;
            //if (beforePos == afterPos) { Debug.Log("collision위치 저장 완료"); }

            SetObj();
        }
    }

    private void OnMouseDown()
    {
        isSet = false;
        beforePos = this.transform.localPosition;
        checkLayer = 1;
    }

    private void OnMouseExit()
    {
        if (checkLayer == 1 && !isMove) { checkLayer = 2; }
    }

    public void SetObj()
    {
        if (!isSet && !isMove)
        {
            this.transform.localPosition = beforePos;
            isSet = true;
            startOnTrig = false;
            checkLayer = 0;
            //Debug.Log("위치초기화");
        }
    }

    public void LateUpdate()
    {
        if (checkLayer == 2)
        {
            startOnTrig = true;
        }
    }
}
