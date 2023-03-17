using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPassButton : MonoBehaviour
{
    public Vector3 position1 = new Vector3(0, 0, 0);
    public Vector3 position2 = new Vector3(0, 0, 1);
    public Vector3 position3 = new Vector3(1, 0, 0);
    public Vector3 position4 = new Vector3(1, 0, 1);
    public GameObject objectToCreate;

    private void OnMouseDown()
    {
        if (!GameObjectAtPosition(position1))
        {
            Instantiate(objectToCreate, position1, Quaternion.identity);
        }
        else if (!GameObjectAtPosition(position2))
        {
            Instantiate(objectToCreate, position2, Quaternion.identity);
        }
        else if (!GameObjectAtPosition(position3))
        {
            Instantiate(objectToCreate, position3, Quaternion.identity);
        }
        else if (!GameObjectAtPosition(position4))
        {
            Instantiate(objectToCreate, position4, Quaternion.identity);
        }
    }

   
    private bool GameObjectAtPosition(Vector3 position)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            if (collider.gameObject != gameObject)
            {
                return true;
            }
        }
        return false;
    }
}