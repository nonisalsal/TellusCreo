using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour
{
    [SerializeField] private Button gameStartButton;
    public GameObject yesButton;
    public GameObject yesPanel;
    public bool buttonSet;
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
                yesPanel.SetActive(true);

                if(yesButton.activeSelf == true)
                {

                }
            
            // 라이브러리룸으로 이동
            // SceneManager.LoadScene("Libraryroom");
        }
            else if (earthMaterial.GetSoilValue())
            {
                // Soil만 true인 경우
                // 애틱으로 이동
                yesButton.SetActive(true);
                SceneManager.LoadScene("Attic");
            }
            else
            {
                SceneManager.LoadScene("livingroom");
            }
        }
    }

    public void ClickEvent()
    {

    }
}