using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_PuzzleObject : MonoBehaviour
{
    public int num = 6;

    private P_PuzzleInfo CheckObj(RaycastHit2D hit)
    {
        GameObject clickObj = hit.collider.gameObject;
        for(int i=0; i<num; i++)
        {
            GameObject childObj = transform.GetChild(i).gameObject;
            if (System.Object.ReferenceEquals(childObj, clickObj))
                return childObj.GetComponent<P_PuzzleInfo>();
        }

        return null;
    }

    private void Update()
    {
        if (P_Camera.instance.isPlayPuzzle)
            return;

        if (P_GameManager.instance.isUp)
        {
            RaycastHit2D hit = P_GameManager.instance.upHit;
            P_PuzzleInfo clickPuzzle = CheckObj(hit);
            if (clickPuzzle != null)
                P_Camera.instance.PlayPuzzle(clickPuzzle);
        }
    }
}
