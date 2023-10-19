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
}
