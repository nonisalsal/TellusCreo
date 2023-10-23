using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScenes : MonoBehaviour
{

    public void ScenesTitle()
    {
        SceneManager.LoadScene("livingroom");
    }

   public void ScenesTitle1()
    {
        SceneManager.LoadScene("Attic");
    }

    public void ScenesTitle2()
    {
        SceneManager.LoadScene("Playroom 1");
    }

   public void ScenesTitle3()
    {
        SceneManager.LoadScene("Title");
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }



}
