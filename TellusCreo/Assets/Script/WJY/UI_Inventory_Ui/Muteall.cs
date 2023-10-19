using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muteall : MonoBehaviour
{
    private bool isMuted = false;

    private void Start()
    {
        // 초기 음소거 상태를 확인하고 설정합니다.
        isMuted = AudioListener.pause;
    }

    public void ToggleMute()
    {
        // 현재 음소거 상태를 토글합니다.
        isMuted = !isMuted;

        // 모든 AudioListener를 음소거 상태로 설정합니다.
        AudioListener.pause = isMuted;
    }
}
