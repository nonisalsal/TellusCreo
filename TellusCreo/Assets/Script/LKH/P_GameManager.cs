using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_GameManager : MonoBehaviour
{
    public bool isDown;
    public bool isUp;
    public Ray2D downRay;
    public Ray2D upRay;
    public RaycastHit2D downHit;
    public RaycastHit2D upHit;

    //public GameObject down;
    //public GameObject up;

    //private GameObject dollObj;
    //private GameObject dollPuzzle1;
    //private GameObject dollPuzzle2;

    void Start()
    {
        isDown = false;
        isUp = false;

        //dollObj = GameObject.Find("doll_object");
        //dollPuzzle1 = transform.Find("DollPuzzle1").gameObject;
        //dollPuzzle2 = transform.Find("DollPuzzle2").gameObject;
    }

    void Update()
    {
        ShootRay();
        //ClearSeq();

        //if (upHit) { up = upHit.collider.gameObject; }
        //if (downHit) { down = downHit.collider.gameObject; }
    }

    private void ShootRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isDown = true;
            Vector2 downPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            downRay = new Ray2D(downPos, Vector2.zero);
            downHit = Physics2D.Raycast(downRay.origin, downRay.direction, 1 << 30);
        }
        else { isDown = false; }

        if (Input.GetMouseButtonUp(0))
        {
            isUp = true;
            Vector2 upPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            upRay = new Ray2D(upPos, Vector2.zero);
            upHit = Physics2D.Raycast(upRay.origin, upRay.direction);
        }
        else { isUp = false; }
    }

    //private void ClearSeq()
    //{
    //    if (GameObject.Find("doll_object").GetComponent<P_PuzzleObject>().isClear == true && GameObject.Find("doll_object").GetComponent<P_PuzzleObject>().puzzleObj == dollPuzzle1)
    //    {
    //        if (GameObject.Find("doll_object").GetComponent<P_PuzzleObject>().isActive == false)
    //        {
    //            GameObject.Find("doll_object").GetComponent<P_PuzzleObject>().puzzleObj = dollPuzzle2;
    //            GameObject.Find("doll_object").GetComponent<P_PuzzleObject>().isClear = false;
    //        }
    //        else
    //        {
    //            GameObject.Find("doll_object").GetComponent<P_PuzzleObject>().puzzleObj = dollPuzzle2;
    //            GameObject.Find("doll_object").GetComponent<P_PuzzleObject>().puzzleCopy = 
    //                Instantiate(GameObject.Find("doll_object"), GameObject.Find("doll_object").transform.position, GameObject.Find("doll_object").transform.rotation);
    //            GameObject.Find("doll_object").GetComponent<P_PuzzleObject>().puzzleCopy.SetActive(true);
    //            GameObject.Find("doll_object").GetComponent<P_PuzzleObject>().isClear = false;
    //        }
    //    }
    //}
}
