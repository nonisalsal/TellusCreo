using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public string sceneName;
    public bool PlayRoomKey;
    public bool AtticKey;
    public bool LibraryKey;

    public void Movescene()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void PlayRoomScene()
    {

    }
}
