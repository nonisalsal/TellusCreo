using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    public void testtest()
    {
        EarthMaterial earthMaterial = EarthMaterial.GetInstance();
        earthMaterial.SetSunValue(true);
    }
}