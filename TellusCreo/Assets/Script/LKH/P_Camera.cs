using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Camera : MonoBehaviour
{
    public bool playPuzzle;
    public float puzzlePos_x;
    public float puzzlePos_y;

    public Ray2D downRay;
    public Ray2D upRay;
    public RaycastHit2D downHit;
    public RaycastHit2D upHit;

    private float thisPos_x;
    private float thisPos_y;
    private float thisPos_z;

    private void Start()
    {
        playPuzzle = false;

        thisPos_x = this.transform.position.x;
        thisPos_y = this.transform.position.y;
        thisPos_z = this.transform.position.z;
    }

    private void Update()
    {
        //ShootRay();

        if (playPuzzle == true)
        {
            this.transform.position = new Vector3(puzzlePos_x, puzzlePos_y, thisPos_z);
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                this.transform.position = new Vector3(thisPos_x, thisPos_y, thisPos_z);
                playPuzzle = false;
            }
        }
        else
        {
            test();
        }
    }

    private void ShootRay()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 downPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            downRay = new Ray2D(downPos, Vector2.zero);
            downHit = Physics2D.Raycast(downRay.origin, downRay.direction, 1 << 30);
            if (downHit)
            {
                Debug.Log(downHit.collider.gameObject.name);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 upPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            upRay = new Ray2D(upPos, Vector2.zero);
            upHit = Physics2D.Raycast(upRay.origin, upRay.direction);
            if (upHit)
            {
                Debug.Log(upHit.collider.gameObject.name);
            }
        }
    }

    private void test()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            thisPos_x += 20;
            if (thisPos_x > 30)
            {
                thisPos_x = -30;
            }
            this.transform.position = new Vector3(thisPos_x, thisPos_y, thisPos_z);
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            thisPos_x -= 20;
            if (thisPos_x < -30)
            {
                thisPos_x = 30;
            }
            this.transform.position = new Vector3(thisPos_x, thisPos_y, thisPos_z);
        }
    }
}
