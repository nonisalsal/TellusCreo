using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearManager : MonoBehaviour
{
    public string sceneName;
    public bool trigger1 = false;
    public bool trigger2 = false;
    public bool trigger3 = false;

    // object1을 참조하는 변수
    public GameObject object1;
    public GameObject object2;
    public GameObject object3;

    public void Update()
    {
        // object1이 활성화되었는지 확인
        if (object1 != null && object1.activeSelf)
        {
            trigger1 = true;
        }

        if (object2 != null && object2.activeSelf)
        {
            trigger2 = true;
        }

        if (object3 != null && object3.activeSelf)
        {
            trigger3 = true;
        }

        
        
        
    }
    private void OnMouseDown()
    {
        if (trigger1 && trigger2 && trigger3)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
