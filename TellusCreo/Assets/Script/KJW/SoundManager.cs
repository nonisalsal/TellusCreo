using System;
using System.Collections.Generic;
using UnityEngine;

public enum Sound
{
    Bgm,
    LoopEffect, // 2023.10.12 추가
    Effect,
    MaxCount,
}

public class SoundManager : MonoBehaviour
{
    static SoundManager instance = null;
    public static SoundManager Instance => instance;

    private float bgmVolume = 0.5f;

    AudioSource[] _audioSources = new AudioSource[(int)Sound.MaxCount]; // 사운드 재생 수 관련
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    void Awake()
    {
        Init();
        instance = this;
    }

    //void Start()
    //{

    //}

    public void Init()
    {
        GameObject root = GameObject.Find("SoundManager"); // 씬에 사운드 매니저 찾기
        if (root == null)
        {
#if UNITY_EDITOR
            Debug.Log("사운드 매니저가 씬에 없습니다.");
#endif
            return;
        }

        string[] soundNames = Enum.GetNames(typeof(Sound)); // "Bgm", "Effect"
        for (int i = 0; i < soundNames.Length - 1; i++) // 마지막은 안들어가게 하기 위해서
        {
            GameObject go = new GameObject { name = soundNames[i] };
            _audioSources[i] = go.AddComponent<AudioSource>();
            go.transform.parent = root.transform;
        }

        _audioSources[(int)Sound.Bgm].loop = true; // bgm 재생기는 무한 반복 재생 
        _audioSources[(int)Sound.LoopEffect].loop = true;   // 2023.10.12 추가s
    }


    void Play(AudioClip audioClip, Sound type = Sound.Effect, float pitch = 1.0f)
    {
        if (audioClip == null)
            return;

        if (type == Sound.Bgm) // BGM 배경음악 재생
        {

            PlayBGM(audioClip, pitch);
        }
        else if (type == Sound.LoopEffect)          // 2023.10.12 추가
        {
            PlayLoopEffect(audioClip, pitch);
        }
        else // Effect 효과음 재생
        {
            PlaySoundEffect(audioClip, pitch);
        }
    }

    public void Play(string path, Sound type = Sound.Effect, float pitch = 1.0f)
    {
        AudioClip audioClip = GetOrAddAudioClip(path, type);
        Play(audioClip, type, pitch);
    }


    AudioClip GetOrAddAudioClip(string path, Sound type = Sound.Effect)
    {
        if (path.Contains("Sound/") == false)
            path = $"Sound/{path}"; // Sound 폴더 안에 저장될 수 있도록

        AudioClip audioClip = null;

        // 2023.10.12 || 뒤 추가
        if (type == Sound.Bgm || type == Sound.LoopEffect) // BGM 배경음악 클립 붙이기
        {
            audioClip = Resources.Load<AudioClip>(path);
        }
        else // Effect 효과음 클립 붙이기
        {
            if (_audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = Resources.Load<AudioClip>(path);
                _audioClips.Add(path, audioClip);
            }
        }

        if (audioClip == null)
        {
#if UNITY_EDITOR
            Debug.LogWarning($"AudioClip 없음. {path}");
#endif
        }

        return audioClip;
    }

    void PlayBGM(AudioClip audioClip, float pitch = 1.0f)
    {
        if (audioClip == null)
            return;

        AudioSource bgmSource = _audioSources[(int)Sound.Bgm];

        if (bgmSource.isPlaying && bgmSource.clip == audioClip) // 이미 재생 중이거나 아니면 같은 BGM이라면
            return;

        bgmSource.Stop();
        bgmSource.pitch = pitch;
        bgmSource.clip = audioClip;
        bgmSource.volume = 0.5f;
        bgmSource.Play();
    }

    void PlayLoopEffect(AudioClip audioClip, float pitch = 1.0f)    // 2023.10.12 추가
    {
        if (audioClip == null)
            return;

        AudioSource loopEffectSource = _audioSources[(int)Sound.LoopEffect];

        if (loopEffectSource.isPlaying && loopEffectSource.clip == audioClip) // 이미 재생 중이거나 아니면 같은 BGM이라면
            return;

        loopEffectSource.Stop();
        loopEffectSource.pitch = pitch;
        loopEffectSource.volume = 0.5f;
        loopEffectSource.PlayOneShot(audioClip);
    }

    public void StopLoopEffect()    // 2023.10.12 추가
    {
        AudioSource loopEffectSource = _audioSources[(int)Sound.LoopEffect];
        loopEffectSource.Stop();
        loopEffectSource.clip = null;
    }

    void PlaySoundEffect(AudioClip audioClip, float pitch = 1.0f)
    {
        if (audioClip == null)
            return;

        AudioSource effectSource = _audioSources[(int)Sound.Effect];
        effectSource.pitch = pitch;
        effectSource.PlayOneShot(audioClip);
    }

    public float GetBGMVolume()
    {
        return bgmVolume;
    }


    public void SetBGMVolume(float volume)
    {
        bgmVolume = volume;
        UpdateBGMVolume();
    }


    private void UpdateBGMVolume()
    {
        AudioSource bgmSource = _audioSources[(int)Sound.Bgm];
        bgmSource.volume = bgmVolume;
    }

    public void SetBgmVolumeBasic(float volume)
    {
        // BGM 볼륨 조절
        if (_audioSources[(int)Sound.Bgm] != null)
        {
            _audioSources[(int)Sound.Bgm].volume = Mathf.Clamp(volume, 0.0f, 1.0f);
        }
    }
}
