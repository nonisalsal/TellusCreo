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

    private int layerNum;
    private int layer_S;
    private int layer_NS;
    private int checkLayer;


    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
        layer_S = SortingLayer.NameToID("Select");
        layer_NS = SortingLayer.NameToID("NotSelect");
    }

    IEnumerator StartSet()
    {
        yield return null;
        SetObj();
        Debug.Log("SetObj 실행");
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
        if (this.tag == "P_move") { isMove = true; }
        else {
            isMove = false;
            //if (!isSet) { GetComponent<P_DragAndDrop>().enabled = false; }
            //else { GetComponent<P_DragAndDrop>().enabled = true; }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isSet && collision.tag == "P_stop")
        {
            afterPos = collision.transform.localPosition;
            collision.transform.localPosition = beforePos;
            beforePos = afterPos;
            if (beforePos == afterPos) { Debug.Log("collision위치 저장 완료"); }

            SetObj();
        }
    }

    private void OnMouseDown()
    {
        isSet = false;
        beforePos = this.transform.localPosition;

        layerNum = 9;
        ChangeLayer();
        checkLayer = 1;
    }

    private void OnMouseExit()
    {
        if (checkLayer == 1 && !isMove)
        {
            layerNum = 8;
            ChangeLayer();
            checkLayer = 2;
        }
    }

    private void ChangeLayer()
    {
        if (layerNum == 8)
        {
            this.gameObject.layer = 8;
            GetComponent<SpriteRenderer>().sortingLayerID = layer_NS;
            if (this.gameObject.layer == 8) { Debug.Log("레이어변경: 8"); }
        }
        else if (layerNum == 9)
        {
            this.gameObject.layer = 9;
            GetComponent<SpriteRenderer>().sortingLayerID = layer_S;
            if (this.gameObject.layer == 9) { Debug.Log("레이어변경: 9"); }
        }
    }

    public void SetObj()
    {
        if (!isSet && !isMove)
        {
            this.transform.localPosition = beforePos;
            isSet = true;
            startOnTrig = false;
            checkLayer = 0;
            Debug.Log("위치초기화");
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
