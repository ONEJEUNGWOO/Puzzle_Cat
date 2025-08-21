using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;

    [Header("Default BGM")]
    public AudioClip defaultBGM;
    public float defaultBGMVolume = 0.5f;

    private bool isPlayingDefaultBGM = false;
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
        // 기본 BGM 재생
        PlayDefaultBGM();
    }

    // BGM 재생 메서드 (기본)
    public void PlayBGM(AudioClip clip, float volume = 0.7f, bool loop = true)
    {
        if (clip == null) return;

        // 현재 페이드 코루틴 중지
        if (currentFadeCoroutine != null)
        {
            StopCoroutine(currentFadeCoroutine);
        }

        bgmSource.clip = clip;
        bgmSource.volume = volume;
        bgmSource.loop = loop;
        bgmSource.Play();

        isPlayingDefaultBGM = (clip == defaultBGM);
    }

    // 기본 BGM 재생 (중복 방지)
    public void PlayDefaultBGM(float volume = -1f)
    {
        if (isPlayingDefaultBGM && bgmSource.isPlaying) return;

        float targetVolume = volume >= 0 ? volume : defaultBGMVolume;
        PlayBGM(defaultBGM, targetVolume);
        isPlayingDefaultBGM = true;
    }

    // 미니게임 BGM 재생
    public void PlayMiniGameBGM(MiniGame miniGame)
    {
        if (miniGame != null && miniGame.bgmClip != null)
        {
            PlayBGM(miniGame.bgmClip, miniGame.bgmVolume);
            isPlayingDefaultBGM = false;
        }
        else
        {
            // 미니게임에 BGM이 없으면 기본 BGM 재생
            PlayDefaultBGM();
        }
    }

    // 기본 BGM으로 복귀 (중복 방지)
    public void ReturnToDefaultBGM()
    {
        PlayDefaultBGM();
    }

    // 페이드 아웃
    public IEnumerator FadeOutBGM(float fadeTime)
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

    // 페이드 인
    public IEnumerator FadeInBGM(AudioClip clip, float targetVolume, float fadeTime)
    {
        if (clip != null)
        {
            bgmSource.clip = clip;
            bgmSource.volume = 0f;
            bgmSource.Play();

            for (float t = 0; t < fadeTime; t += Time.deltaTime)
            {
                bgmSource.volume = Mathf.Lerp(0f, targetVolume, t / fadeTime);
                yield return null;
            }

            bgmSource.volume = targetVolume;
            isPlayingDefaultBGM = (clip == defaultBGM);
        }
    }

    // 페이드 인 (현재 클립으로)
    public IEnumerator FadeInBGM(float targetVolume, float fadeTime)
    {
        if (bgmSource.clip != null)
        {
            bgmSource.volume = 0f;
            bgmSource.Play();

            for (float t = 0; t < fadeTime; t += Time.deltaTime)
            {
                bgmSource.volume = Mathf.Lerp(0f, targetVolume, t / fadeTime);
                yield return null;
            }

            bgmSource.volume = targetVolume;
        }
    }

    // 코루틴으로 페이드 전환
    public Coroutine FadeToBGM(AudioClip clip, float targetVolume, float fadeOutTime, float fadeInTime)
    {
        if (currentFadeCoroutine != null)
        {
            StopCoroutine(currentFadeCoroutine);
        }
        currentFadeCoroutine = StartCoroutine(FadeToBGMCoroutine(clip, targetVolume, fadeOutTime, fadeInTime));
        return currentFadeCoroutine;
    }

    private IEnumerator FadeToBGMCoroutine(AudioClip clip, float targetVolume, float fadeOutTime, float fadeInTime)
    {
        // 페이드 아웃
        if (bgmSource.isPlaying)
        {
            yield return FadeOutBGM(fadeOutTime);
        }

        // 새 BGM 페이드 인
        if (clip != null)
        {
            yield return FadeInBGM(clip, targetVolume, fadeInTime);
        }

        currentFadeCoroutine = null;
    }

    // BGM 정지
    public void StopBGM()
    {
        bgmSource.Stop();
        isPlayingDefaultBGM = false;
    }

    // BGM 일시정지
    public void PauseBGM()
    {
        bgmSource.Pause();
    }

    // BGM 재개
    public void ResumeBGM()
    {
        bgmSource.UnPause();
    }

    // 볼륨 설정
    public void SetBGMVolume(float volume)
    {
        bgmSource.volume = volume;
    }
}