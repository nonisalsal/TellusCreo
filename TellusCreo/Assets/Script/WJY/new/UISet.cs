using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISet : MonoBehaviour
{
    public float targetXPosition = 0f; // 비활성화할 X 좌표 값
    public GameObject obj;
    private void Update()
    {
        // 현재 카메라의 위치를 얻기
        Vector3 cameraPosition = Camera.main.transform.position;

        // 카메라의 X 좌표 값 얻기
        float cameraXPosition = cameraPosition.x;

        // 카메라의 X 좌표 값이 0과 같을 때 오브젝트 활성화, 그렇지 않으면 비활성화
        if (cameraXPosition == 0f)
        {
            obj.SetActive(true); // 오브젝트 활성화
        }
        else
        {
            obj.SetActive(false); // 오브젝트 비활성화
        }
    }
}
