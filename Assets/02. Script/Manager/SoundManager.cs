using System.Collections;
using UnityEngine;


/// 게임의 사운드를 관리하는 싱글톤 매니저. BGM 재생, 정지, 페이드 효과 등을 담당합니다.

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;

    [Header("Default BGM")]
    public AudioClip defaultBGM;
    public float defaultBGMVolume = 0.5f;

    private Coroutine currentFadeCoroutine;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayDefaultBGM();
    }

  
    /// BGM을 즉시 재생합니다.

    public void PlayBGM(AudioClip clip, float volume = 0.7f, bool loop = true)
    {
        if (clip == null) return;

        // 즉시 BGM을 재생하므로 현재 진행 중인 페이드 코루틴을 중지합니다.
        if (currentFadeCoroutine != null)
        {
            StopCoroutine(currentFadeCoroutine);
        }

        bgmSource.clip = clip;
        bgmSource.volume = volume;
        bgmSource.loop = loop;
        bgmSource.Play();
    }

    /// 기본 BGM을 재생합니다. 이미 기본 BGM이 재생 중이면 중복 재생하지 않습니다.

 
    public void PlayDefaultBGM(float volume = -1f)
    {
        // 이미 기본 BGM이 재생 중이면 함수를 종료합니다.
        if (bgmSource.clip == defaultBGM && bgmSource.isPlaying) return;

        float targetVolume = (volume >= 0) ? volume : defaultBGMVolume;
        PlayBGM(defaultBGM, targetVolume);
    }


    /// BGM을 페이드 아웃하여 정지시킵니다.

    public Coroutine StopBGMWithFadeOut(float fadeTime)
    {
        if (currentFadeCoroutine != null)
        {
            StopCoroutine(currentFadeCoroutine);
        }
        currentFadeCoroutine = StartCoroutine(FadeOutBGM(fadeTime));
        return currentFadeCoroutine;
    }

    /// 현재 재생 중인 BGM을 부드럽게 페이드 아웃하고 새로운 BGM을 페이드 인합니다.

    public Coroutine FadeToBGM(AudioClip clip, float targetVolume, float fadeOutTime, float fadeInTime)
    {
        if (currentFadeCoroutine != null)
        {
            StopCoroutine(currentFadeCoroutine);
        }
        currentFadeCoroutine = StartCoroutine(FadeToBGMCoroutine(clip, targetVolume, fadeOutTime, fadeInTime));
        return currentFadeCoroutine;
    }


    /// BGM을 정지시킵니다.

    public void StopBGM()
    {
        bgmSource.Stop();
    }

    /// BGM을 일시정지합니다.
    public void PauseBGM()
    {
        bgmSource.Pause();
    }

    /// BGM을 재개합니다.
    public void ResumeBGM()
    {
        bgmSource.UnPause();
    }

    /// BGM 볼륨을 설정합니다.

    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    // 코루틴 메서드

    private IEnumerator FadeOutBGM(float fadeTime)
    {
        float startVolume = bgmSource.volume;
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            bgmSource.volume = Mathf.Lerp(startVolume, 0f, t / fadeTime);
            yield return null;
        }
        bgmSource.volume = 0f;
        bgmSource.Stop();
    }

    private IEnumerator FadeInBGM(AudioClip clip, float targetVolume, float fadeTime)
    {
        if (clip == null) yield break;

        bgmSource.clip = clip;
        bgmSource.volume = 0f;
        bgmSource.Play();

        float startVolume = 0f;
        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            bgmSource.volume = Mathf.Lerp(startVolume, targetVolume, t / fadeTime);
            yield return null;
        }
        bgmSource.volume = targetVolume;
    }

    private IEnumerator FadeToBGMCoroutine(AudioClip clip, float targetVolume, float fadeOutTime, float fadeInTime)
    {
        // 현재 BGM이 재생 중이면 페이드 아웃을 먼저 진행합니다.
        if (bgmSource.isPlaying)
        {
            yield return FadeOutBGM(fadeOutTime);
        }

        // 새 BGM을 페이드 인합니다.
        yield return FadeInBGM(clip, targetVolume, fadeInTime);

        currentFadeCoroutine = null;
    }
}