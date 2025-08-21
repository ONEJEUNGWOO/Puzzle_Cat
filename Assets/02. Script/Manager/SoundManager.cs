using System.Collections;
using UnityEngine;

// 게임의 사운드를 관리하는 싱글톤 매니저. BGM + SFX 관리
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("Volume Settings")]
    [Range(0f, 1f)]
    public float masterVolume = 1f;
    [Range(0f, 1f)]
    public float bgmVolume = 1f;
    [Range(0f, 1f)]
    public float sfxVolume = 1f;

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
        // 볼륨 초기 설정 적용
        ApplyVolumeSettings();
        PlayDefaultBGM();
    }

    /// 현재 볼륨 설정을 AudioSource에 적용
    private void ApplyVolumeSettings()
    {
        // BGM 볼륨 = 마스터 볼륨 × BGM 볼륨
        if (bgmSource != null)
        {
            bgmSource.volume = masterVolume * bgmVolume;
        }
    }

    /// 마스터 볼륨 설정
    public void SetMasterVolume(float volume)
    {
        masterVolume = Mathf.Clamp01(volume);
        ApplyVolumeSettings();
    }

    /// BGM 볼륨 설정
    public void SetBGMVolume(float volume)
    {
        bgmVolume = Mathf.Clamp01(volume);
        ApplyVolumeSettings();
    }

    /// SFX 볼륨 설정
    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
    }

    /// BGM 재생 (최종 볼륨 = 마스터 × BGM × 입력 볼륨)
    public void PlayBGM(AudioClip clip, float volume = 0.7f, bool loop = true)
    {
        if (clip == null) return;

        if (currentFadeCoroutine != null)
            StopCoroutine(currentFadeCoroutine);

        bgmSource.clip = clip;
        bgmSource.volume = masterVolume * bgmVolume * volume;
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

    // SFX 관련 메서드
    /// SFX 재생 (최종 볼륨 = 마스터 × SFX × 입력 볼륨)
    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        if (clip != null && sfxSource != null)
        {
            float finalVolume = masterVolume * sfxVolume * volume;
            sfxSource.PlayOneShot(clip, finalVolume);
        }
    }

    /// 미리 지정한 효과음 이름으로 호출
    public void PlaySFXByName(string name)
    {
        switch (name)
        {
            case "walk": PlaySFX(walkSFX); break;
            case "run": PlaySFX(runSFX); break;
            case "jump": PlaySFX(jumpSFX); break;
            default:
                Debug.LogWarning($"SFX '{name}' not found!");
                break;
        }
    }

    /// 특정 볼륨으로 SFX 재생
    public void PlaySFXByName(string name, float volume)
    {
        switch (name)
        {
            case "walk": PlaySFX(walkSFX, volume); break;
            case "run": PlaySFX(runSFX, volume); break;
            case "jump": PlaySFX(jumpSFX, volume); break;
            default:
                Debug.LogWarning($"SFX '{name}' not found!");
                break;
        }
    }

    // 코루틴 메서드들
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

        float finalTargetVolume = masterVolume * bgmVolume * targetVolume;

        for (float t = 0; t < fadeTime; t += Time.deltaTime)
        {
            bgmSource.volume = Mathf.Lerp(0f, finalTargetVolume, t / fadeTime);
            yield return null;
        }
        bgmSource.volume = finalTargetVolume;
    }

    private IEnumerator FadeToBGMCoroutine(AudioClip clip, float targetVolume, float fadeOutTime, float fadeInTime)
    {
        if (bgmSource.isPlaying)
            yield return FadeOutBGM(fadeOutTime);

        yield return FadeInBGM(clip, targetVolume, fadeInTime);
        currentFadeCoroutine = null;
    }

    /// 모든 사운드 일시정지
    public void PauseAll()
    {
        PauseBGM();
        if (sfxSource != null)
            sfxSource.Pause();
    }

    /// 모든 사운드 재개
    public void ResumeAll()
    {
        ResumeBGM();
        if (sfxSource != null)
            sfxSource.UnPause();
    }

    /// 모든 사운드 정지
    public void StopAll()
    {
        StopBGM();
        if (sfxSource != null)
            sfxSource.Stop();
    }
}