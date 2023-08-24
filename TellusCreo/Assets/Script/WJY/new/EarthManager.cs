using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EarthManager")) // "Earth" 태그를 가진 오브젝트와 충돌 판정
        {
            // 충돌 시 실행할 코드 (예: 오브젝트 비활성화)
            Debug.Log("Collision with Earth detected");
            // 여기에 충돌 시 실행할 코드를 추가하세요.
            collision.gameObject.SetActive(false); // 충돌한 오브젝트 비활성화
        }
    }
}