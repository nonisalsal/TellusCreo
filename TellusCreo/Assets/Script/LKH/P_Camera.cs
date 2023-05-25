using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Camera : MonoBehaviour
{
    // 다른 클래스에서 위치 변경하지말고 카메라는 그냥 위치 넘겨받으면 실행하는 함수 만들기
    public bool playPuzzle;
    public float puzzlePos_x;
    public float puzzlePos_y;

    public float thisPos_x;
    public float thisPos_y;
    public float thisPos_z;

    public GameObject button;
    private bool destroyButton;
    //private GameObject button_back;

    private void Start()
    {
        playPuzzle = false;

        thisPos_x = this.transform.position.x;
        thisPos_y = this.transform.position.y;
        thisPos_z = this.transform.position.z;

        destroyButton = false;
        //button_back = GameObject.Find("Button").transform.GetChild(2).gameObject;
        button.transform.GetChild(2).gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playPuzzle == true)
        {
            this.transform.position = new Vector3(puzzlePos_x, puzzlePos_y, thisPos_z);
            if (!destroyButton)
            {
                button.transform.GetChild(0).gameObject.SetActive(false);
                button.transform.GetChild(1).gameObject.SetActive(false);
                button.transform.GetChild(2).gameObject.SetActive(true);
                // 모바일에서 버튼이 생성되지 않는 오류, instantiate하여 생성하는 방식으로 하려 했으나 오류 발생.
                //GameObject.Instantiate(button_back, button_back.transform.position, button_back.transform.rotation);
                //button_back.transform.parent = GameObject.Find("Button").transform;
                destroyButton = true;
            }
        }
        else
        {
            if (destroyButton)
            {
                button.transform.GetChild(0).gameObject.SetActive(true);
                button.transform.GetChild(1).gameObject.SetActive(true);
                button.transform.GetChild(2).gameObject.SetActive(false);
                //Destroy(GameObject.Find("Button").transform.GetChild(4).gameObject);
                destroyButton = false;
            }
        }
    }
}