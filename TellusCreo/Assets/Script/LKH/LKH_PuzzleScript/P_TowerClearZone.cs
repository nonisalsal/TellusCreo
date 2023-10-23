using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_TowerClearZone : MonoBehaviour
{
    private bool isContect;
    private bool isColliderMove;
    private GameObject contectObj;

    private float time;
    private Vector3 colliderLastPos;

    private P_PuzzleClear clearController;

    private void Awake()
    {
        clearController = transform.GetComponentInParent<P_PuzzleClear>();
    }

    private void OnEnable()
    {
        //if (P_Camera.instance.nowPuzzle.Get_isClear())
        //    return;

        isContect = false;

        time = 0;
    }

    private void Start()
    {
        this.gameObject.layer = 30;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isContect)
        {
            colliderLastPos = collision.gameObject.transform.localPosition;
            isContect = true;
            contectObj = collision.gameObject;
            SoundManager.Instance.Play("playroom_timer", Sound.LoopEffect);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isContect = false;
        contectObj = null;
        isColliderMove = false;

        time = 0;
        SoundManager.Instance.StopLoopEffect();
    }

    private void Update()
    {
        if (isColliderMove && contectObj.CompareTag("P_building") && time > 1.5f)
        {
            if(colliderLastPos == contectObj.transform.position)
            {
                clearController.CheckClear_TowerPuzzle();
                Destroy(this);
            }
            else
            {
                colliderLastPos = contectObj.transform.position;
                time = 0;
            }
        }
    }

    private void LateUpdate()
    {
        if (isContect)
        {
            isColliderMove = true;
            time += Time.deltaTime;
        }
    }

    private void CheckPosition(Collider2D obj)
    {
        if (colliderLastPos != obj.transform.localPosition)
        {
            isColliderMove = true;
            colliderLastPos = obj.transform.localPosition;
        }
        else { isColliderMove = false; }
    }
}
