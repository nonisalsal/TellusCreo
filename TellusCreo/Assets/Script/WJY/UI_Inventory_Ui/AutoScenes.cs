using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoScenes : MonoBehaviour
{
    public GameObject eventObject;
    public string sceneName;

    public void Update()
    {
        if(eventObject.activeSelf == true)
        {
           SceneManager.LoadScene(sceneName);
        }
        
    }

}
