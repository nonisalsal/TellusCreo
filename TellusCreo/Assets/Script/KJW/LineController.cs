using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{

    LineRenderer lr;
    [SerializeField]
    Transform _startPos;
    int idx = 1;
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, _startPos.transform.position);
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(_startPos.transform.position, mousPos, 10f);

            if (hit.collider)
            {
                if (lr.positionCount > idx)
                {
                    lr.SetPosition(idx, hit.collider.transform.position);
                  //  lr.enabled = false;
                    lr.numPositions++;
                    idx++;
                }

            }
            else
            {
                if (lr.positionCount > idx)
                    lr.SetPosition(idx, mousPos);
                //lr.enabled = true;
            }
        }
        else if (Input.GetMouseButtonDown(1))
        {
            for (int i = 0; i < lr.positionCount; i++)
            {
                lr.SetPosition(i, _startPos.position);
            }
            lr.numPositions = 2;
            idx = 1;
        }

    }


}
