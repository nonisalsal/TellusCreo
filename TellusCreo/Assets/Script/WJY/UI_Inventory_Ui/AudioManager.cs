using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Slider volumeSlider;
 

    private AudioSource audioSource;

    public GameObject Onmutebutton;
    public GameObject Offmutebutton;




    public AudioClip backgroundSound;

    public AudioSource buttonClickAudioSource;
    public AudioSource menuClickAudioSource;
    public  AudioSource bagClickAudioSource;

    public AudioClip buttonClickSound; 
    public AudioClip menuClickSound;
    public AudioClip bagClickSound;

    private Muteall muteallScript;

    private void Start()
    {

        muteallScript = GetComponent<Muteall>();

       

        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        

        
        volumeSlider.onValueChanged.AddListener(ChangeVolume);

    
        volumeSlider.value = PlayerPrefs.GetFloat("BGMVolume", 0.1f);
        audioSource.volume = volumeSlider.value;


        AudioClip audioClip = backgroundSound;
        if (audioClip != null)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }

        buttonClickAudioSource = gameObject.AddComponent<AudioSource>();
        menuClickAudioSource = gameObject.AddComponent<AudioSource>();
        bagClickAudioSource = gameObject.AddComponent <AudioSource>();

        if (buttonClickSound != null)
        {
            buttonClickAudioSource.clip = buttonClickSound;
        }

        if (menuClickSound != null)
        {
            menuClickAudioSource.clip = menuClickSound;
        }

        if (bagClickSound != null)
        {
            bagClickAudioSource.clip = bagClickSound;
        }


    }

    public void Update()
    {
        if (volumeSlider.value > 0)
        {
            Onmutebutton.SetActive(true);
            Offmutebutton.SetActive(false);
        }

        
    }
    private void ChangeVolume(float volume)
    {
        audioSource.volume = volume / 100f;
        PlayerPrefs.SetFloat("BGMVolume", volume);
    }

    public void PlayButtonClickSound()
    {
        if (buttonClickAudioSource != null)
        {
            buttonClickAudioSource.Play();
        }
    }

    public void PlayMenuClickSound()
    {
        if (menuClickAudioSource != null)
        {
            menuClickAudioSource.Play();
        }
    }

    public void PlayBagClickSound()
    {
        if (bagClickAudioSource != null)
        {
            bagClickAudioSource.Play();
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

            volumeSlider.value = PlayerPrefs.GetFloat("BGMVolume", 0.1f);
            
        }

        ChangeVolume(volumeSlider.value);
    }

    

}