using UnityEngine;

public class EarthMaterial : MonoBehaviour
{
    

    private bool Sun = false;
    private bool Water = false;
    private bool Soil = false;

    private bool CutS = false;

    private static EarthMaterial instance;

    // 싱글톤 인스턴스를 가져오거나 생성하는 메서드
    public static EarthMaterial GetInstance()
    {
        if (instance == null)
        {
            // 씬에서 EarthMaterial 오브젝트를 찾아보고 없으면 생성
            instance = FindObjectOfType<EarthMaterial>();

            if (instance == null)
            {
                GameObject obj = new GameObject("EarthManager");
                instance = obj.AddComponent<EarthMaterial>();
            }

            DontDestroyOnLoad(instance.gameObject);
        }
        return instance;
    }
    private void Awake()
    {
        // 이미 인스턴스가 존재하면 현재 오브젝트를 파괴
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        // 씬 이동 시에도 파괴되지 않도록 설정
        DontDestroyOnLoad(gameObject);

        // 이 오브젝트를 인스턴스로 설정
        instance = this;
    }

    // 원하는 시점에 bool 변수를 변경할 수 있는 메서드를 추가할 수 있습니다.
    public void SetSunValue(bool newValue)
    {
        Sun = newValue;
        
    }

    // 원하는 시점에 bool 변수 값을 얻을 수 있는 메서드를 추가할 수 있습니다.
    public bool GetSunValue()
    {
        return Sun;
    }

    public void SetWaterValue(bool newValue)
    {
        Water = newValue;
        
    }

    // 원하는 시점에 bool 변수 값을 얻을 수 있는 메서드를 추가할 수 있습니다.
    public bool GetWaterValue()
    {
        return Water;
    }

    public void SetSoilValue(bool newValue)
    {
        Soil = newValue;
        
    }


    public bool GetSoilValue()
    {
        return Soil;
    }

    public void SetcutValue(bool newValue)
    {
        CutS = newValue;

    }


    public bool GetcutValue()
    {
        return CutS;
    }


}
