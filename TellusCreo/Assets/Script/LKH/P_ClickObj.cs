﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ClickObj : MonoBehaviour
{
    public GameObject rayControl;

    private bool[] getItem;
    private bool getKey_A;
    private bool getKey_B;
    private bool getPattern;
    private bool contectWire;
    private bool getWire;

    void Start()
    {
        getItem = new bool[8] { false, false, false, false, false, false, false, false };
        getKey_A = true; ;
        getKey_B = false;
    }

    void Update()
    {
        PlayerInput();
    }

    private void PlayerInput()
    {
        if (rayControl.GetComponent<P_GameManager>().isUp)
        {
            if (rayControl.GetComponent<P_GameManager>().upHit)
            {
                if (getItem[0] == false && System.Object.ReferenceEquals(this.transform.GetChild(0).gameObject, rayControl.GetComponent<P_GameManager>().upHit.collider.gameObject))
                {
                    Debug.Log("Get 'Key_A'");
                    getKey_A = true;
                    getItem[2] = true;
                }
                if (getItem[1] == false && System.Object.ReferenceEquals(this.transform.GetChild(1).gameObject, rayControl.GetComponent<P_GameManager>().upHit.collider.gameObject))
                {
                    Debug.Log("Get 'Violin'");
                    getItem[3] = true;
                }
                if (getItem[2] == false && System.Object.ReferenceEquals(this.transform.GetChild(2).gameObject, rayControl.GetComponent<P_GameManager>().upHit.collider.gameObject))
                {
                    if (!contectWire) { Debug.Log("Need 'Contect Wire'"); }
                    else
                    {
                        Debug.Log("Get 'Top_B'");
                        getItem[4] = true;
                    }
                }
                if (getItem[3] == false && System.Object.ReferenceEquals(this.transform.GetChild(3).gameObject, rayControl.GetComponent<P_GameManager>().upHit.collider.gameObject))
                {
                    if (!getKey_B) { Debug.Log("Need 'Key_B'"); }
                    else
                    {
                        Debug.Log("Get 'Top_C'");
                        getItem[5] = true;
                    }
                }
                //if (getItem[4] == false && System.Object.ReferenceEquals(this.transform.GetChild(4).gameObject, upHit.collider.gameObject))
                //{
                    
                //}
                //if (getItem[5] == false && System.Object.ReferenceEquals(this.transform.GetChild(5).gameObject, upHit.collider.gameObject))
                //{
                    
                //}
                //if (getItem[6] == false && System.Object.ReferenceEquals(this.transform.GetChild(6).gameObject, upHit.collider.gameObject))
                //{

                //}
            }
        }
    }
}
