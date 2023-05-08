using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Camera : MonoBehaviour
{
    public bool playPuzzle;
    public float puzzlePos_x;
    public float puzzlePos_y;

    public float thisPos_x;
    public float thisPos_y;
    public float thisPos_z;

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
        GameObject.Find("Button").transform.GetChild(2).gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playPuzzle == true)
        {
            this.transform.position = new Vector3(puzzlePos_x, puzzlePos_y, thisPos_z);
            if (!destroyButton)
            {
                GameObject.Find("Button").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.Find("Button").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.Find("Button").transform.GetChild(2).gameObject.SetActive(true);
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
                GameObject.Find("Button").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("Button").transform.GetChild(1).gameObject.SetActive(true);
                GameObject.Find("Button").transform.GetChild(2).gameObject.SetActive(false);
                //Destroy(GameObject.Find("Button").transform.GetChild(4).gameObject);
                destroyButton = false;
            }
        }
    }
}