using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Puzzle : MonoBehaviour
{
    public GameObject puzzleObj;
    private Vector3 puzzlePos;
    private Vector3 beforePos;

    private GameObject cam;

    void Start()
    {
        cam = GameObject.Find("P_MainCamera");
        puzzlePos = puzzleObj.transform.position;
    }

    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        // 퍼즐 기능까지 이걸 활용할거면 쓰고 아니면 이거 굳이 필요없음. puzzleFunciton 함수 하나 더 만들어야함.
        if (P_GameManager.isUp)
        {
            DownFunction();
        }

        if (P_GameManager.isDown)
        {
            UpFunction();
        }
    }

    public virtual void DownFunction()
    {

    }

    public virtual void UpFunction()
    {
        if (System.Object.ReferenceEquals(this.gameObject, P_GameManager.upHit.collider.gameObject))
        {
            // 원래 하던대로 카메라 class에 있는 정보 가져가는 방식으로 수정하기
            beforePos = cam.transform.position;
        }
    }
}
