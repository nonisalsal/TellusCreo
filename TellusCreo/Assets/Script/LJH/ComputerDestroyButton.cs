using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerDestroyButton : MonoBehaviour
{
    public Vector3 position1 = new Vector3(0, 0, 0); //첫번째 번호 위치
    public Vector3 position2 = new Vector3(0, 0, 1); //두번째 번호 위치
    public Vector3 position3 = new Vector3(1, 0, 0); //세번쨰 번호 위치


    private void OnMouseDown()// 클릭 시 함수 작동
    {
        DeleteObjectsAtPosition(position1);
        DeleteObjectsAtPosition(position2);
        DeleteObjectsAtPosition(position3);
       
    }

    private void DeleteObjectsAtPosition(Vector3 position)//해당 위치에 충돌 판정 나는 오브젝트 파괴하는 함수 
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, 0.1f);
        foreach (Collider2D collider in colliders)
        {
            Destroy(collider.gameObject);
        }
    }
}
