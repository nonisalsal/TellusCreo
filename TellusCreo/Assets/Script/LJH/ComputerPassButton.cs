using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPassButton : MonoBehaviour
{
    //position1~3번호가 나올 오브젝트 좌표
    public Vector3 position1 = new Vector3(0, 0, 0);
    public Vector3 position2 = new Vector3(0, 0, 1);
    public Vector3 position3 = new Vector3(1, 0, 0);

   
    public GameObject objectToCreate;

    private void OnMouseDown()// 마우스 클릭 시 1번에 오브젝트가 없으면 생성, 있으면 2번에 생성하는 코드
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