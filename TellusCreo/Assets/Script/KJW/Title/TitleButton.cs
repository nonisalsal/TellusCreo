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
            gameStartButton.onClick.AddListener(() => SceneManager.LoadScene("TitleCutscene"));
            earthMaterial.SetcutValue(true);
        }
        else
        {
            gameStartButton.onClick.AddListener(() => SceneManager.LoadScene("livingroom"));
        }

    }
}
