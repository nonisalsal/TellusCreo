using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEarthMaterialEvent : MonoBehaviour
{
    // Start is called before the first frame update
  public void GetSoilEvnet()
    {
        EarthMaterial.GetInstance().SetSoilValue(true);
    }
}
