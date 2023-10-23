using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Muteall : MonoBehaviour
{
    private bool isEffectMuted = false;
    private float originalButtonVolume;
    private float originalMenuVolume;
    private float originalBagVolume;

    public Slider EffectSlider;
    public GameObject OnEffectmutebutton;
    public GameObject OffEffectmutebutton;
    public AudioManager audioManager; 

    private void Start()
    {
       
        originalButtonVolume = audioManager.buttonClickAudioSource.volume;
        originalMenuVolume = audioManager.menuClickAudioSource.volume;
        originalBagVolume = audioManager.bagClickAudioSource.volume;
        EffectSlider.value = 50;
    }

    public void Update()
    {

        if (EffectSlider.value == 0)
        {
            MuteEffects();
        }
        else
        {
            UnmuteEffects();
        }
    }

    public void ToggleMute()
    {
        isEffectMuted = !isEffectMuted;

        if (isEffectMuted)
        {
            MuteEffects();
            EffectSlider.value = 0;
        }
        else
        {
            UnmuteEffects();
            EffectSlider.value = 50;
        }
    }

    private void MuteEffects()
    {

        audioManager.buttonClickAudioSource.volume = 0;
        audioManager.menuClickAudioSource.volume = 0;
        audioManager.bagClickAudioSource.volume = 0;
        OnEffectmutebutton.SetActive(false);
        OffEffectmutebutton.SetActive(true);
    }

    private void UnmuteEffects()
    {
        
        audioManager.buttonClickAudioSource.volume = originalButtonVolume;
        audioManager.menuClickAudioSource.volume = originalMenuVolume;
        audioManager.bagClickAudioSource.volume = originalBagVolume;

        OnEffectmutebutton.SetActive(true);
        OffEffectmutebutton.SetActive(false);
    }
}