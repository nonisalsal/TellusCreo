using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour
{
    [SerializeField] private Button gameStartButton;
    private void Awake()
    {
        gameStartButton.onClick.AddListener(() => SceneManager.LoadScene("livingroom"));
    }
}
