using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUIController : MonoBehaviour
{
    public Slider bgmSlider;
    public Slider sfxSlider;


    public float bgmAudioTest;
    public float sfxAudioTest;

    private void Awake()
    {
        bgmAudioTest = bgmSlider.value;
        sfxAudioTest = sfxSlider.value;
    }

    public void ONChangerBGM()
    {
        bgmAudioTest = bgmSlider.value;
    }

    public void ONChangerSFX()
    {
        sfxAudioTest = sfxSlider.value;
    }

    public void ONGameExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
