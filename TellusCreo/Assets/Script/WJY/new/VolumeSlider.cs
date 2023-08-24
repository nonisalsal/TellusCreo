using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider volumeSlider; // Inspector에서 슬라이더 연결
    public SoundManager soundManager; // SoundManager 스크립트 연결

    private void Start()
    {
        // 슬라이더의 초기 값을 SoundManager의 BGM 볼륨으로 설정
        volumeSlider.value = soundManager.GetBGMVolume();

        // 슬라이더 값 변경 시 호출될 이벤트 핸들러 연결
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
    }

    // 슬라이더 값이 변경될 때 호출되는 메서드
    private void OnVolumeChanged(float volume)
    {
        // SoundManager의 BGM 볼륨 조절 메서드 호출
        soundManager.SetBGMVolume(volume);
    }
}