using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorKnob : MonoBehaviour
{
    public string sceneName;

    
    private void OnMouseDown()
    {
        EarthMaterial earthMaterial = EarthMaterial.GetInstance();
        if (CheckRoomOrder()) SceneManager.LoadScene(sceneName);
      
        // 클리어 아닐 때만 입장
        if (!EarthMaterial.GetInstance().GetSunValue() && string.Equals(sceneName, "Attic"))
        {
            SceneManager.LoadScene(sceneName);
            earthMaterial.SetcutValue(true);
        }
        else if (!EarthMaterial.GetInstance().GetSoilValue() && string.Equals(sceneName, "Playroom 1"))
        {
            SceneManager.LoadScene(sceneName);
            earthMaterial.SetcutValue(true);
        }
    }


    bool CheckRoomOrder() // 방 순서 체크
    {
        if(!EarthMaterial.GetInstance().GetSoilValue() && string.Equals(sceneName, "Playroom 1"))
        {
            return true;
        }
        else if(EarthMaterial.GetInstance().GetSoilValue())
        {
            if (!EarthMaterial.GetInstance().GetSunValue() && string.Equals(sceneName, "Attic"))
            {
                return true;
            }
        }

        return false;
    }
}
