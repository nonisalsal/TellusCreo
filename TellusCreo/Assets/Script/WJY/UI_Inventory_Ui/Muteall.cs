using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Muteall : MonoBehaviour
{
    private bool isMuted = false;

    public Slider EffectSlider;
    public GameObject OnEffectmutebutton;
    public GameObject OffEffectmutebutton;

    private void Start()
    {
        // 초기 음소거 상태를 확인하고 설정합니다.
        isMuted = AudioListener.pause;
    }

    public void Update()
    {
        if (EffectSlider.value > 0)
        {
            if (isMuted) // 현재 음소거 상태인 경우에만 토글합니다.
            {
                OnEffectmutebutton.SetActive(true);
                OffEffectmutebutton.SetActive(false);
                ToggleMute();
            }
        }
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;

        // 볼륨을 기준으로 음소거를 설정합니다.
        AudioListener.pause = isMuted;

        if(AudioListener.pause == true)
        EffectSlider.value = 0;
    }
}