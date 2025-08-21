using System.Collections;
using UnityEngine;

// 게임의 사운드를 관리하는 싱글톤 매니저. BGM + SFX 관리
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Audio Sources")]
    public AudioSource bgmSource;
    public AudioSource sfxSource; 

    [Header("Default BGM")]
    public AudioClip defaultBGM;
    public float defaultBGMVolume = 0.5f;

    [Header("SFX Clips")]
    public AudioClip walkSFX;
    public AudioClip runSFX;
    public AudioClip jumpSFX;

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

    public void PlayBGM(AudioClip clip, float volume = 0.7f, bool loop = true)
    {
        if (clip == null) return;

        if (currentFadeCoroutine != null)
            StopCoroutine(currentFadeCoroutine);

        bgmSource.clip = clip;
        bgmSource.volume = volume;
        bgmSource.loop = loop;
        bgmSource.Play();
    }

    public void PlayDefaultBGM(float volume = -1f)
    {
        if (bgmSource.clip == defaultBGM && bgmSource.isPlaying) return;
        float targetVolume = (volume >= 0) ? volume : defaultBGMVolume;
        PlayBGM(defaultBGM, targetVolume);
    }

    public Coroutine StopBGMWithFadeOut(float fadeTime)
    {
        if (currentFadeCoroutine != null)
            StopCoroutine(currentFadeCoroutine);

        currentFadeCoroutine = StartCoroutine(FadeOutBGM(fadeTime));
        return currentFadeCoroutine;
    }

    public Coroutine FadeToBGM(AudioClip clip, float targetVolume, float fadeOutTime, float fadeInTime)
    {
        if (currentFadeCoroutine != null)
            StopCoroutine(currentFadeCoroutine);

        currentFadeCoroutine = StartCoroutine(FadeToBGMCoroutine(clip, targetVolume, fadeOutTime, fadeInTime));
        return currentFadeCoroutine;
    }

    public void StopBGM() => bgmSource.Stop();
    public void PauseBGM() => bgmSource.Pause();
    public void ResumeBGM() => bgmSource.UnPause();
    public void SetBGMVolume(float volume) => bgmSource.volume = volume;

    // SFX
    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        if (clip != null)
            sfxSource.PlayOneShot(clip, volume);
    }

    // 미리 지정한 효과음 이름으로 호출
    public void PlaySFXByName(string name)
    {
        switch (name)
        {
            case "walk": PlaySFX(walkSFX); break;
            case "run": PlaySFX(runSFX); break;
            case "jump": PlaySFX(jumpSFX); break;
        }
    }

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

        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            bgmSource.volume = Mathf.Lerp(0f, targetVolume, t / fadeTime);
            yield return null;
        }
        bgmSource.volume = targetVolume;
    }

    private IEnumerator FadeToBGMCoroutine(AudioClip clip, float targetVolume, float fadeOutTime, float fadeInTime)
    {
        if (bgmSource.isPlaying)
            yield return FadeOutBGM(fadeOutTime);

        yield return FadeInBGM(clip, targetVolume, fadeInTime);
        currentFadeCoroutine = null;
    }
    
}