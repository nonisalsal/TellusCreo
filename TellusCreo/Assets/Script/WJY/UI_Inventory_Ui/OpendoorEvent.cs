using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpendoorEvent : MonoBehaviour
{
    public string textContent; // Public로 변경하여 Inspector에서 설정 가능

    private void OnMouseDown()
    {
        if (gameObject.CompareTag(textContent))
        {
            if (textContent == "Playroom")
            {
                OpenPlayroom();
            }
            else if (textContent == "Attic")
            {
                OpenAttic();
            }
        }
    }

    public void OpenPlayroom()
    {
        SceneManager.LoadScene("Playroom1");
    }

    public void OpenAttic()
    {
        SceneManager.LoadScene("Attic");
    }
}