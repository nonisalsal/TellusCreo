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
        Save save = Save.GetInstance();

        // Load the 'cutsceneShown' flag from PlayerPrefs
        bool cutsceneShown = PlayerPrefs.GetInt("CutsceneShown", 0) == 1;

        if (!cutsceneShown)
        {
            gameStartButton.onClick.AddListener(() =>
            {
                // Set the 'cutsceneShown' flag to true and save it in PlayerPrefs
                PlayerPrefs.SetInt("CutsceneShown", 1);
                PlayerPrefs.Save();

                SceneManager.LoadScene("TitleCutscene");
                earthMaterial.SetcutValue(true);
                save.Load();
            });
        }
        else
        {
            gameStartButton.onClick.AddListener(() =>
            {
                save.Load();
                SceneManager.LoadScene("livingroom");
                if (earthMaterial.GetSoilValue())
                {
                    SceneManager.LoadScene("Attic");
                }
                else
                {
                    SceneManager.LoadScene("livingroom");
                }
            });
        }
    }
}



