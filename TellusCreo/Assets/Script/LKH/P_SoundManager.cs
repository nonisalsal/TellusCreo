using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_SoundManager : MonoBehaviour
{
    public static P_SoundManager instance;

    [SerializeField] AudioClip getItem;
    [SerializeField] AudioClip puzzleClear;
    [SerializeField] AudioClip lockedDoor;
    [SerializeField] AudioClip openLockedDoor;
    [SerializeField] AudioClip openDoor;
    [SerializeField] AudioClip openDrawer;
    [SerializeField] AudioClip clickSwitch;

    private AudioSource audioSource;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void Play_getItem()
    {
        audioSource.clip = getItem;
        audioSource.Play();
    }

    public void Play_puzzleClear()
    {
        audioSource.clip = puzzleClear;
        audioSource.Play();
    }

    public void Play_openLockedDoor()
    {
        audioSource.clip = openLockedDoor;
        audioSource.Play();
    }

    public void Play_lockedDoor()
    {
        audioSource.clip = lockedDoor;
        audioSource.Play();
    }

    public void Play_openDrawer()
    {
        audioSource.clip = openDrawer;
        audioSource.Play();
    }

    public void Play_clickSwitch()
    {
        audioSource.clip = clickSwitch;
        audioSource.Play();
    }
}
