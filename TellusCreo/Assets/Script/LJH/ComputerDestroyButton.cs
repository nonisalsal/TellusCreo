using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerDestroyButton : MonoBehaviour
{
    public Vector3 position1 = new Vector3(0, 0, 0);
    public Vector3 position2 = new Vector3(0, 0, 1);
    public Vector3 position3 = new Vector3(1, 0, 0);
    

    private void OnMouseDown()
    {
        DeleteObjectsAtPosition(position1);
        DeleteObjectsAtPosition(position2);
        DeleteObjectsAtPosition(position3);
       
    }

    private void DeleteObjectsAtPosition(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            Destroy(collider.gameObject);
        }
    }
}
