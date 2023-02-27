﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ClickObj : MonoBehaviour
{
    private bool isUp;
    private Ray2D upRay;
    private RaycastHit2D upHit;

    private bool[] getItem;
    private bool getKey_A;
    private bool getKey_B;
    private bool getPattern;
    private bool contectWire;
    private bool getWire;

    void Start()
    {
        getItem = new bool[8] { false, false, false, false, false, false, false, false };
        //for (int i=0; i<8; i++) { Debug.Log(this.transform.GetChild(i).gameObject.name); }
    }

    void Update()
    {
        //if (FindObjectOfType<P_Camera>().playPuzzle == false)
        //{
        //    ShootRay();
        //    PlayerInput();
        //}
        ShootRay();
        PlayerInput();
    }

    private void ShootRay()
    {
        if (Input.GetMouseButtonUp(0))
        {
            isUp = true;
            Vector2 upPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            upRay = new Ray2D(upPos, Vector2.zero);
            upHit = Physics2D.Raycast(upRay.origin, upRay.direction);
        }
        else { isUp = false; }
    }

    private void PlayerInput()
    {
        if (isUp)
        {
            if (upHit)
            {
                if (getItem[0] == false && System.Object.ReferenceEquals(this.transform.GetChild(0).gameObject, upHit.collider.gameObject))
                {
                    if (!getKey_A) { Debug.Log("Need 'Key_A'"); }
                    else { 
                        Debug.Log("Get 'Wire'");
                        getWire = true;
                        getItem[0] = true;
                    }
                }
                if (getItem[1] == false && System.Object.ReferenceEquals(this.transform.GetChild(1).gameObject, upHit.collider.gameObject))
                {
                    Debug.Log("Get 'Guitar'");
                    getItem[1] = true;
                }
                if (getItem[2] == false && System.Object.ReferenceEquals(this.transform.GetChild(2).gameObject, upHit.collider.gameObject))
                {
                    Debug.Log("Get 'Key_A'");
                    getKey_A = true;
                    getItem[2] = true;
                }
                if (getItem[3] == false && System.Object.ReferenceEquals(this.transform.GetChild(3).gameObject, upHit.collider.gameObject))
                {
                    if (!getPattern) { Debug.Log("Need 'Pattern'"); }
                    else
                    {
                        Debug.Log("Get 'Fianl_Item'");
                        getItem[3] = true;
                    }
                }
                if (getItem[4] == false && System.Object.ReferenceEquals(this.transform.GetChild(4).gameObject, upHit.collider.gameObject))
                {
                    Debug.Log("Get 'Violin'");
                    getItem[4] = true;
                }
                if (getItem[5] == false && System.Object.ReferenceEquals(this.transform.GetChild(5).gameObject, upHit.collider.gameObject))
                {
                    if (!contectWire) { Debug.Log("Need 'Contect Wire'"); }
                    else
                    {
                        Debug.Log("Get 'Top_B'");
                        getItem[5] = true;
                    }
                }
                if (getItem[6] == false && System.Object.ReferenceEquals(this.transform.GetChild(6).gameObject, upHit.collider.gameObject))
                {
                    if (!getKey_B) { Debug.Log("Need 'Key_B'"); }
                    else
                    {
                        Debug.Log("Get 'Top_C'");
                        getItem[6] = true;
                    }
                }
                if (getItem[7] == false && System.Object.ReferenceEquals(this.transform.GetChild(7).gameObject, upHit.collider.gameObject))
                {
                    if (!getWire) { Debug.Log("Need 'Wire'"); }
                    else
                    {
                        Debug.Log("Use 'Lamp'");
                        contectWire = true;
                        getItem[7] = true;
                    }
                }
            }
        }
    }
}
