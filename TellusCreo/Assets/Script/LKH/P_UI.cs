using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_UI : MonoBehaviour
{
    public void ClickLeftArrow()
    {
        P_Camera.instance.MoveSide(0);
        PlayMenuClickSound();
    }

    public void ClickRightArrow()
    {
        P_Camera.instance.MoveSide(1);
        PlayMenuClickSound();
    }

    public void ClickBackArrow()
    {
        P_Camera.instance.ExtiPuzzle();
        PlayMenuClickSound();
    }

    private void PlayMenuClickSound()
    {
        AudioManager audioManager = FindObjectOfType<AudioManager>(); // AudioManager 스크립트를 찾아야 합니다.

        if (audioManager != null)
        {
            audioManager.PlayMenuClickSound();
        }
        else
        {
            Debug.LogWarning("AudioManager not found.");
        }
    }
}