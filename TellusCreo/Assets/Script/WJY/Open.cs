using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Open : MonoBehaviour
{
    public GameObject bag;


    public void bagSetActive()
    {
        bag.SetActive(!bag.active);
    }
}
