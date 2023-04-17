                using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (playPuzzle == true)
            {
<<<<<<< Updated upstream
                GameObject.Find("Button").transform.GetChild(0).gameObject.SetActive(false);
                GameObject.Find("Button").transform.GetChild(1).gameObject.SetActive(false);
                GameObject.Find("Button").transform.GetChild(2).gameObject.SetActive(true);
                //GameObject.Instantiate(button_back, button_back.transform.position, button_back.transform.rotation);
                //button_back.transform.parent = GameObject.Find("Button").transform;
                destroyButton = true;
=======

                this.transform.position = new Vector3(puzzlePos_x, puzzlePos_y, thisPos_z);
                //if (Input.GetKeyUp(KeyCode.UpArrow))
                //{
                //    this.transform.position = new Vector3(thisPos_x, thisPos_y, thisPos_z);
                //    playPuzzle = false;
                //}
                if (!destroyButton)
                {
                    GameObject.Find("Button").transform.GetChild(0).gameObject.SetActive(false);
                    GameObject.Find("Button").transform.GetChild(1).gameObject.SetActive(false);
                    GameObject.Find("Button").transform.GetChild(2).gameObject.SetActive(true);
                    //GameObject.Instantiate(button_back, button_back.transform.position, button_back.transform.rotation);
                    //button_back.transform.parent = GameObject.Find("Button").transform;
                    destroyButton = true;
                }
>>>>>>> Stashed changes
            }
            else
            {
<<<<<<< Updated upstream
                GameObject.Find("Button").transform.GetChild(0).gameObject.SetActive(true);
                GameObject.Find("Button").transform.GetChild(1).gameObject.SetActive(true);
                GameObject.Find("Button").transform.GetChild(2).gameObject.SetActive(false);
                //Destroy(GameObject.Find("Button").transform.GetChild(4).gameObject);
                destroyButton = false;
=======
                if (destroyButton)
                {
                    GameObject.Find("Button").transform.GetChild(0).gameObject.SetActive(true);
                    GameObject.Find("Button").transform.GetChild(1).gameObject.SetActive(true);
                    GameObject.Find("Button").transform.GetChild(2).gameObject.SetActive(false);
                    //Destroy(GameObject.Find("Button").transform.GetChild(4).gameObject);
                    destroyButton = false;
                }
>>>>>>> Stashed changes
            }
        }
    }
}
