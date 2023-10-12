using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    private void Start()
    {
        // 게임 시작 시, 불러오기 함수를 호출하여 데이터를 불러옵니다.
        
    }

    public void save()
    {
        // 각 변수를 PlayerPrefs에 저장합니다.
        PlayerPrefs.SetInt("Sun", EarthMaterial.GetInstance().GetSunValue() ? 1 : 0);
        PlayerPrefs.SetInt("Water", EarthMaterial.GetInstance().GetWaterValue() ? 1 : 0);
        PlayerPrefs.SetInt("Soil", EarthMaterial.GetInstance().GetSoilValue() ? 1 : 0);
        PlayerPrefs.SetInt("CutS", EarthMaterial.GetInstance().GetcutValue() ? 1 : 0);

        PlayerPrefs.Save(); // 저장을 확실히 하려면 Save() 메서드를 호출
    }

    public void Load()
    {
        // PlayerPrefs에서 데이터를 불러와서 게임 상태를 업데이트합니다.
        bool sunValue = PlayerPrefs.GetInt("Sun", 0) == 1; // 0은 기본값 (false)
        EarthMaterial.GetInstance().SetSunValue(sunValue);

        bool waterValue = PlayerPrefs.GetInt("Water", 0) == 1;
        EarthMaterial.GetInstance().SetWaterValue(waterValue);

        bool soilValue = PlayerPrefs.GetInt("Soil", 0) == 1;
        EarthMaterial.GetInstance().SetSoilValue(soilValue);

        bool cutValue = PlayerPrefs.GetInt("CutS", 0) == 1;
        EarthMaterial.GetInstance().SetcutValue(cutValue);
    }
}