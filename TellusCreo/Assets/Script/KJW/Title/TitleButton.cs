using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour
{
    [SerializeField] private Button gameStartButton;

    private void Awake()
    {
        EarthMaterial earthMaterial = EarthMaterial.GetInstance();

        if (!earthMaterial.GetcutValue())
        {
            gameStartButton.onClick.AddListener(() => {
                SceneManager.LoadScene("TitleCutscene");
                earthMaterial.SetcutValue(true);
            });
        }
        else
        {
         
            if (earthMaterial.GetSoilValue() && earthMaterial.GetWaterValue())
            {
                
                // 라이브러리룸으로 이동
                // SceneManager.LoadScene("Libraryroom");
            }
            else if (earthMaterial.GetSoilValue())
            {
                // Soil만 true인 경우
                // 애틱으로 이동
                SceneManager.LoadScene("Attic");
            }
            else
            {
                SceneManager.LoadScene("livingroom");
            }
        }
    }
}