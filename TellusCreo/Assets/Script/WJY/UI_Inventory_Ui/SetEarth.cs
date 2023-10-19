using UnityEngine;

public class SetEarth : MonoBehaviour
{
    public GameObject Sunobj;
    public GameObject Soilobj;
    public GameObject Waterobj;

    public bool sunbool;
    public bool soilobj;
    public bool waterbool;
    void Start()
    {
        UpdateEarthObjects();
    }

    private void OnEnable()
    {
        UpdateEarthObjects();
    }

    public void UpdateEarthObjects()
    {
        EarthMaterial earthMaterial = EarthMaterial.GetInstance();

        if (earthMaterial.GetSoilValue())
        {
            Soilobj.SetActive(true);
        }
        else
        {
            Soilobj.SetActive(false);
        }

        if (earthMaterial.GetSunValue())
        {
            Sunobj.SetActive(true);
        }
        else
        {
            Sunobj.SetActive(false);
        }

        if (earthMaterial.GetWaterValue())
        {
            Waterobj.SetActive(true);
        }
        else
        {
            Waterobj.SetActive(false);
        }
    }
}

