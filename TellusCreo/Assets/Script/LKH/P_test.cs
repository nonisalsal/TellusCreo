﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_test : MonoBehaviour
{
    public GameObject pair;
    public GameObject rayControl;

    private bool isDrawer;
    private bool isBedLeft;

    void Start()
    {
        if (this.gameObject.name == "drawer") { isDrawer = true; }
        else { isDrawer = false; }

        if (this.gameObject.name == "bed_left") { isBedLeft = true; }
        else { isBedLeft = false; }
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
                if (System.Object.ReferenceEquals(this.gameObject, rayControl.GetComponent<P_GameManager>().upHit.collider.gameObject))
                {
                    if (isDrawer)
                    {
                        if (!(rayControl.GetComponent<P_GameManager>().Get_isGetKeyB()))
                        {
                            Debug.Log("need keyB");
                            this.GetComponent<AudioSource>().Play();
                            return;
                        }
                    }
                    if (isBedLeft)
                    {
                        if (!(rayControl.GetComponent<P_GameManager>().Get_isGetKeyA()))
                        {
                            Debug.Log("need keyB");
                            this.GetComponent<AudioSource>().Play();
                            return;
                        }
                    }

                    pair.SetActive(true);
                    this.gameObject.SetActive(false);
                }
            }
        }
    }
}
