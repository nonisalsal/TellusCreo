using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ScenesMove : MonoBehaviour
{
    public string sceneName;
    private void Start()
    {
        Invoke("MyFunction", 18f);
    }

    private void MyFunction()
    {
        SceneManager.LoadScene(sceneName);
    }
   

   

}
