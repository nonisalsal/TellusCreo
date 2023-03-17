using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _testing : MonoBehaviour
{
    //Sorting Layer를 P_Select로 지정하는 변수.
    private int layer_S;
    //Sorting Layer를 P_NotSelect로 지정하는 변수.
    private int layer_NS;

    //레이어와 Sorting Layer를 함께 변경해주는 함수.
    private void ChangeLayer(int layerNum)
    {
        if (layerNum == 30)
        {
            //레이어 변경: 30 -> P_NotSelect.
            this.gameObject.layer = 30;
            //Sorting Layer를 P_NotSelect로 변경.
            GetComponent<SpriteRenderer>().sortingLayerID = layer_NS;
        }
        else if (layerNum == 31)
        {
            //레이어 변경: 31 -> P_Select.
            this.gameObject.layer = 31;
            //Sorting Layer를 P_Select로 변경.
            GetComponent<SpriteRenderer>().sortingLayerID = layer_S;
        }
    }

    private void Start()
    {
        //태그 초기화.
        this.tag = "P_stop";
        //layer_S에 P_Select 저장.
        layer_S = SortingLayer.NameToID("P_Select");
        //layer_NS에 P_NotSelect 저장.
        layer_NS = SortingLayer.NameToID("P_NotSelect");
        //레이어 30번으로 지정.
        //
        //ChangeLayer(30);
    }

    //PlayerInput함수로 수정.
    //private void OnMouseDown()
    //{
    //    this.tag = "P_move";
    //    ChangeLayer(31);
    //}

    //화면을 드래그하고 있을 때.
    private void OnMouseDrag()
    {
        //mousePosition에 현재 터치하고 있는 위치를 저장.
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //objectPosition에 mousePosition을 화면좌표에서 월드좌표로 변경하여 저장.(공부 필요)
        Vector2 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //오브젝트의 위치를 objectPosition로 변경.
        this.transform.position = objectPosition;
    }

    //PlayerInput함수로 수정.
    //private void OnMouseUp()
    //{
    //    this.tag = "P_stop";
    //    ChangeLayer(30);
    //}

    //플레이어의 터치 입력을 감지하는 함수.
    private void PlayerInput()
    {
        //화면을 터치할 때.
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 downPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D downRay = new Ray2D(downPos, Vector2.zero);
            RaycastHit2D downHit = Physics2D.Raycast(downRay.origin, downRay.direction);
            if (downHit)
            {
                if (System.Object.ReferenceEquals(this.gameObject, downHit.collider.gameObject))
                {
                    this.tag = "P_move";
                    //ChangeLayer(31);
                }
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 upPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Ray2D upRay = new Ray2D(upPos, Vector2.zero);
            RaycastHit2D upHit = Physics2D.Raycast(upRay.origin, upRay.direction);
            if (upHit)
            {
                if (System.Object.ReferenceEquals(this.gameObject, upHit.collider.gameObject))
                {
                    this.tag = "P_stop";
                    //ChangeLayer(30);
                }
            }
        }
    }

    private void Update()
    {
        PlayerInput();
    }
}