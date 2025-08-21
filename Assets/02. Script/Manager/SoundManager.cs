using System.Collections;
using UnityEngine;

/// <summary>
/// 게임의 사운드를 관리하는 싱글톤 매니저. BGM 재생, 정지, 페이드 효과 등을 담당합니다.
/// </summary>
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

    /// <summary>
    /// BGM을 즉시 재생합니다.
    /// </summary>
    /// <param name="clip">재생할 오디오 클립.</param>
    /// <param name="volume">재생 볼륨.</param>
    /// <param name="loop">반복 재생 여부.</param>
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

    /// <summary>
    /// 기본 BGM을 재생합니다. 이미 기본 BGM이 재생 중이면 중복 재생하지 않습니다.
    /// </summary>
    /// <param name="volume">재생 볼륨. 기본값(-1f) 사용 시 defaultBGMVolume을 따릅니다.</param>
    public void PlayDefaultBGM(float volume = -1f)
    {
        // 이미 기본 BGM이 재생 중이면 함수를 종료합니다.
        if (bgmSource.clip == defaultBGM && bgmSource.isPlaying) return;

        float targetVolume = (volume >= 0) ? volume : defaultBGMVolume;
        PlayBGM(defaultBGM, targetVolume);
    }

    /// <summary>
    /// BGM을 페이드 아웃하여 정지시킵니다.
    /// </summary>
    /// <param name="fadeTime">페이드 아웃에 걸리는 시간.</param>
    public Coroutine StopBGMWithFadeOut(float fadeTime)
    {
        if (currentFadeCoroutine != null)
        {
            StopCoroutine(currentFadeCoroutine);
        }
        currentFadeCoroutine = StartCoroutine(FadeOutBGM(fadeTime));
        return currentFadeCoroutine;
    }

    /// <summary>
    /// 현재 재생 중인 BGM을 부드럽게 페이드 아웃하고 새로운 BGM을 페이드 인합니다.
    /// </summary>
    /// <param name="clip">새로 재생할 오디오 클립.</param>
    /// <param name="targetVolume">새 BGM의 목표 볼륨.</param>
    /// <param name="fadeOutTime">현재 BGM 페이드 아웃에 걸리는 시간.</param>
    /// <param name="fadeInTime">새 BGM 페이드 인에 걸리는 시간.</param>
    public Coroutine FadeToBGM(AudioClip clip, float targetVolume, float fadeOutTime, float fadeInTime)
    {
        if (currentFadeCoroutine != null)
        {
            StopCoroutine(currentFadeCoroutine);
        }
        currentFadeCoroutine = StartCoroutine(FadeToBGMCoroutine(clip, targetVolume, fadeOutTime, fadeInTime));
        return currentFadeCoroutine;
    }

    /// <summary>
    /// BGM을 정지시킵니다.
    /// </summary>
    public void StopBGM()
    {
        bgmSource.Stop();
    }

    /// <summary>
    /// BGM을 일시정지합니다.
    /// </summary>
    public void PauseBGM()
    {
        bgmSource.Pause();
    }

    /// <summary>
    /// BGM을 재개합니다.
    /// </summary>
    public void ResumeBGM()
    {
        bgmSource.UnPause();
    }

    /// <summary>
    /// BGM 볼륨을 설정합니다.
    /// </summary>
    /// <param name="volume">설정할 볼륨 값.</param>
    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    //
    // 코루틴 메서드
    //

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