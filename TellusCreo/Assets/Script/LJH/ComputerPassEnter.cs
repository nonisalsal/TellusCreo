using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPassEnter : MonoBehaviour
{
    //public GameObject clearnumber1Prefab;
    public Vector3 position1 = new Vector3(0, 0, 0);
    public Vector3 position2 = new Vector3(0, 0, 1);
    public Vector3 position3 = new Vector3(1, 0, 0);

    public GameObject clearnumber1;//첫번 째 번호 암호
    public GameObject clearnumber2;
    public GameObject clearnumber3;
    public Camera cam;// 클리어 시 오작교 퍼즐 배경으로 이동시키는 메인 카메라
    public GameObject Ojack; //오작교 퍼즐로 이동시 활성화 시킬 변수
    public Vector3 teleportPosition; // 오작교 퍼즐로 이동시킬 좌표

    public bool check1;
    public bool check2;
    public bool check3;

    // Start is called before the first frame update
    void Start()
    {
        check1 = false;
        check2 = false;
        check3 = false;
        //clearnumber1 = Instantiate(clearnumber1Prefab, Vector3.zero, Quaternion.identity);
        Ojack.SetActive(false);
    }
    private void CheckCollisionAtPosition(Vector3 position, GameObject clearNumberObject) //클리어 판정하는 함수 오류 있음..
    {
        Collider[] colliders = Physics.OverlapSphere(position, 0.1f); // 주어진 좌표 주변의 콜라이더를 가져옴
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject == clearNumberObject)
            {
                Debug.Log("Check at position: " + position);
                if (clearNumberObject == clearnumber1)
                {
                    check1 = true;
                    Debug.Log("check1");
                }
                else if (clearNumberObject == clearnumber2)
                    check2 = true;
                else if (clearNumberObject == clearnumber3)
                    check3 = true;

                
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnMouseDown()
    {
        Debug.Log("click");
        CheckCollisionAtPosition(position1, clearnumber1);
        CheckCollisionAtPosition(position2, clearnumber2);
        CheckCollisionAtPosition(position3, clearnumber3);

        // 모든 클리어 넘버가 true일 경우 clearcheck 함수 호출
        if (check1 && check2 && check3)
        {
            clearcheck();
        }
        TeleportCamera(teleportPosition);
        Ojack.SetActive(true);

    }
    private void clearcheck()
    {
        // 클리어 넘버가 모두 true일 때 실행할 동작 구현
        Debug.Log("All clear numbers are true!");
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    void TeleportCamera(Vector3 position) 
    {
        // 카메라 위치를 지정한 좌표로 설정
        cam.transform.position = position;
    }
}
