using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_DollPuzzle : MonoBehaviour
{
    private Vector2 beforePos;
    private Vector2 afterPos;

    public bool isMove = false;
    public bool isSet = true;
    private bool startOnTrig = false;

    private int checkLayer;

    public GameObject rayControl;
    public GameObject parentObj;

    void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
        parentObj = transform.parent.gameObject;
    }

    public void SetObj()
    {
        if (!isSet && !isMove)
        {
            this.transform.localPosition = beforePos;
            isSet = true;
            startOnTrig = false;
            checkLayer = 0;
        }
    }

    IEnumerator StartSet()
    {
        yield return null;
        SetObj();
    }

    private void FixedUpdate()
    {
        if (startOnTrig)
        {
            StartCoroutine(StartSet());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(System.Object.ReferenceEquals(parentObj, collision.transform.parent.gameObject))
        {
            if (!isSet && collision.CompareTag("P_stop"))
            {
                afterPos = collision.transform.localPosition;
                collision.transform.localPosition = beforePos;
                beforePos = afterPos;
            }
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
                if (checkLayer == 1 && !isMove) { checkLayer = 2; }
            }
        }
    }

    void Update()
    {
        if (this.CompareTag("P_move")) { isMove = true; }
        else { isMove = false; }

        PlayerInput();
    }

    public void LateUpdate()
    {
        if (checkLayer == 2)
        {
            startOnTrig = true;
        }
    }
}
