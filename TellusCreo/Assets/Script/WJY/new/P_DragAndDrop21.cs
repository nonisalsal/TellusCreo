using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_DragAndDrop21 : MonoBehaviour
{
    private int layer_S;
    private int layer_NS;

    public GameObject rayControl;

    private void ChangeLayer(int layerNum)
    {
        if (layerNum == 30)
        {
            this.gameObject.layer = 30;
            GetComponent<SpriteRenderer>().sortingLayerID = layer_NS;
        }
        else if (layerNum == 31)
        {
            this.gameObject.layer = 31;
            GetComponent<SpriteRenderer>().sortingLayerID = layer_S;
        }
    }

    private void Start()
    {
        this.tag = "P_stop";
        layer_S = SortingLayer.NameToID("P_Select");
        layer_NS = SortingLayer.NameToID("P_NotSelect");
        ChangeLayer(30);
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // 혹시라도 z 좌표를 변경한 경우를 대비하여 z 값을 0으로 설정

        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("puzzle_final_soil"))
        {
            Vector2 objectPosition = hit.point;
            this.transform.position = objectPosition;
        }
    }

    private void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (rayControl.GetComponent<P_GameManager>().isDown == true)
        {
            RaycastHit2D downHit = rayControl.GetComponent<P_GameManager>().downHit;
            if (downHit)
            {
                if (System.Object.ReferenceEquals(this.gameObject, downHit.collider.gameObject))
                {
                    Debug.Log("dragAndDrop Down start");
                    this.tag = "P_move";
                    ChangeLayer(31);
                }
            }
        }
        if (rayControl.GetComponent<P_GameManager>().isUp == true)
        {
            RaycastHit2D upHit = rayControl.GetComponent<P_GameManager>().upHit;
            if (upHit)
            {
                //if (System.Object.ReferenceEquals(this.gameObject, upHit.collider.gameObject))
                //{
                //    //Debug.Log("dragAndDrop Up start");
                //    this.tag = "P_stop";
                //    ChangeLayer(30);
                //}
                //Debug.Log("dragAndDrop Up start");
                this.tag = "P_stop";
                ChangeLayer(30);
            }
        }
    }
}
