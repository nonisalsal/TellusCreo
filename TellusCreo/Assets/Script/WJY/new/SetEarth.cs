﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEarth : MonoBehaviour
{
    public GameObject Sunobj;
    public GameObject Soilobj;
    public GameObject Waterobj;
    void Start()
    {
        EarthMaterial earthMaterial = EarthMaterial.GetInstance();

        if (earthMaterial.GetSoilValue())
        {
            Soilobj.SetActive(true);
        }
        if (earthMaterial.GetSunValue())
        {
            Sunobj.SetActive(true);
        }
        if (earthMaterial.GetWaterValue())
        {
            Waterobj.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
