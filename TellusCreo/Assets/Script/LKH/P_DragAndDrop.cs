using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_DragAndDrop : MonoBehaviour
{
    private void OnMouseDown()
    {
        //Debug.Log("태그변경: P_move");
        this.tag = "P_move";
    }

    private void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        this.transform.position = objectPosition;
    }

    private void OnMouseUp()
    {
        //Debug.Log("태그변경: P_stop");
        this.tag = "P_stop";
    }
}
