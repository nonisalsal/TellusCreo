using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public string sceneName; 

    public void Movescene()
    {
        SceneManager.LoadScene(sceneName);
    }

}
