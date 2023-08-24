using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L_PuzzleObjects : MonoBehaviour
{
    public int num = 7;

    private P_Camera cameraController;

    private void Awake()
    {
        cameraController = FindObjectOfType<P_Camera>();
    }

    private P_PuzzleInfo CheckObj(RaycastHit2D hit)
    {
        GameObject clickObj = hit.collider.gameObject;
        for(int i=0; i<num; i++)
        {
            GameObject childObj = transform.GetChild(i).gameObject;

            int childNum = childObj.transform.childCount;
            if(childNum == 0)
            {
                if (System.Object.ReferenceEquals(childObj, clickObj))
                    return childObj.GetComponent<P_PuzzleInfo>();
            }
            else
            {
                for(int j=0; j<childNum; j++)
                {
                    if (System.Object.ReferenceEquals(childObj.transform.GetChild(j).gameObject, clickObj))
                        return childObj.GetComponent<P_PuzzleInfo>();
                }
            }
        }

        return null;
    }

    void Update()
    {
        if(L_GameManager.instance.isUp == true)
        {
            RaycastHit2D hit = L_GameManager.instance.upHit;
            P_PuzzleInfo clickPuzzle = CheckObj(hit);
            if (clickPuzzle != null)
                cameraController.PlayPuzzle(clickPuzzle);
        }
    }
}
