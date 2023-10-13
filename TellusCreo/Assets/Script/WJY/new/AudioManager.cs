using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider; 

    private AudioSource audioSource; 
    public AudioClip buttonClickSound; 
    public AudioClip menuClickSound;
    public AudioClip bagClickSound;

    private void Start()
    {
      
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;

        
        volumeSlider.onValueChanged.AddListener(ChangeVolume);

    
        volumeSlider.value = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        audioSource.volume = volumeSlider.value;


        AudioClip audioClip = Resources.Load<AudioClip>("Sound/leva-eternity-149473");
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }


    private void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }

    public void PlayMenuClickSound()
    {
        if (menuClickSound != null)
        {
            audioSource.PlayOneShot(menuClickSound);
        }
    }
    public void PlaybagClickSound()
    {
        if (bagClickSound != null)
        {
            
            audioSource.PlayOneShot(bagClickSound);
        }
    }
    public void MuteButton()
    {
        if (volumeSlider.value > 0)
        {

            volumeSlider.value = 0;
        }
        else
        {

            volumeSlider.value = PlayerPrefs.GetFloat("BGMVolume", 0.5f);
        }

        ChangeVolume(volumeSlider.value);
    }
}