using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    public float blinkDuration = 0.5f; 
   [SerializeField] private SpriteRenderer _title;

    private void Start()
    {
        StartCoroutine(BlinkCoroutine());
        SoundManager.Instance.Play("Title_bgm", Sound.Bgm);
    }

    private IEnumerator BlinkCoroutine()
    {
        Color originalColor = _title.color;
        while (true) 
        {
            float timer = 0f;
            while (timer < blinkDuration)
            {
                float normalizedTime = timer / blinkDuration;
                Color fadedColor = originalColor;
                fadedColor.a = Mathf.Lerp(1f, 0f, normalizedTime);
                _title.color = fadedColor;

                timer += Time.deltaTime;
                yield return null;
            }

            timer = 0f;
            while (timer < blinkDuration)
            {
                float normalizedTime = timer / blinkDuration;
                Color fadedColor = originalColor;
                fadedColor.a = Mathf.Lerp(0f, 1f, normalizedTime);
                _title.color = fadedColor;

                timer += Time.deltaTime;
                yield return null;
            }
        }
    }
}

