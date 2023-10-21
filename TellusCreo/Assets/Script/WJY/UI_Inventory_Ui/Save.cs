using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{


    private static Save instance;

    // 싱글톤 인스턴스를 가져오거나 생성하는 메서드
    public static Save GetInstance()
    {
        if (instance == null)
        {
            // 씬에서 EarthMaterial 오브젝트를 찾아보고 없으면 생성
            instance = FindObjectOfType<Save>();

            if (instance == null)
            {
                GameObject obj = new GameObject("SaveManager");
                instance = obj.AddComponent<Save>();
            }

            DontDestroyOnLoad(instance.gameObject);
        }
        return instance;
    }

    public void save()
    {
        
        PlayerPrefs.SetInt("Sun", EarthMaterial.GetInstance().GetSunValue() ? 1 : 0);
        PlayerPrefs.SetInt("Water", EarthMaterial.GetInstance().GetWaterValue() ? 1 : 0);
        PlayerPrefs.SetInt("Soil", EarthMaterial.GetInstance().GetSoilValue() ? 1 : 0);
        PlayerPrefs.SetInt("CutS", EarthMaterial.GetInstance().GetcutValue() ? 1 : 0);
        
        PlayerPrefs.Save(); 
    }

    public void Load()
    {
        

        

        bool sunValue = PlayerPrefs.GetInt("Sun", 0) == 1; 
        EarthMaterial.GetInstance().SetSunValue(sunValue);

        bool waterValue = PlayerPrefs.GetInt("Water", 0) == 1;
        EarthMaterial.GetInstance().SetWaterValue(waterValue);

        bool soilValue = PlayerPrefs.GetInt("Soil", 0) == 1;
        EarthMaterial.GetInstance().SetSoilValue(soilValue);

        bool cutValue = PlayerPrefs.GetInt("CutS", 0) == 1;
        EarthMaterial.GetInstance().SetcutValue(cutValue);

        Debug.Log("Sun Value: " + sunValue);
        Debug.Log("Water Value: " + waterValue);
        Debug.Log("Soil Value: " + soilValue);
        Debug.Log("Cut Value: " + cutValue);
    }
}