using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class P_ChangePos : MonoBehaviour
{
    public Vector2 beforePos;
    public Vector2 afterPos;

    public bool isMove = false;
    public bool isSet = true;
    private bool startOnTrig = false;

    private int checkLayer;

    public GameObject rayControl;

    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void FixedUpdate()
    {
        if (startOnTrig)
        {
            StartCoroutine(StartSet());
        }
    }

    IEnumerator StartSet()
    {
        yield return null;
        SetObj();
    }

    public void SetObj()
    {
        if (!isSet && !isMove)
        {
            Debug.Log("SetObj");
            this.transform.localPosition = beforePos;
            isSet = true;
            startOnTrig = false;
            checkLayer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isSet && collision.CompareTag("P_stop"))
        {
            //Debug.Log("OnTriggerEnter");
            afterPos = collision.transform.localPosition;
            collision.transform.localPosition = beforePos;
            beforePos = afterPos;
            //if (beforePos == afterPos) { Debug.Log("collision위치 저장 완료"); }
            //SetObj();
        }
    }

    private void Update()
    {
        if (this.CompareTag("P_move")) { isMove = true; }
        else { isMove = false; }

        if (!EventSystem.current.IsPointerOverGameObject())
        {
            PlayerInput();
        }
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
                    isSet = false;
                    beforePos = this.transform.localPosition;
                    checkLayer = 1;
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
                //    if (checkLayer == 1 && !isMove) { checkLayer = 2; }
                //}
                if (checkLayer == 1 && !isMove) { checkLayer = 2; }
            }
        }
    }

    public void LateUpdate()
    {
        if (checkLayer == 2)
        {
            //Debug.Log("LateUpdate");
            startOnTrig = true;
        }
    }
}