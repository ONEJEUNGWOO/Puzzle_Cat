using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Game", order = 1)]
public class MiniGame : ScriptableObject
{
    /// 게임 이름
    [Header("메인 게임 인지")]
    public bool isMain;

    /// 게임의 고유 아이디
    [Header("게임의 고유 아이디")]
    public string GameID;

    /// 게임의 고유 번호
    [Header("게임의 고유 번호")]
    public int GameIndex;

    /// 중력의 영향이 필요한지
    [Header("중력을 사용하는지")]
    public bool isGravityUse;

    /// 필요한 고칠 중력의 양
    [Header("중력의 값")]
    public Vector3 GravityScale;

    /// 각 레벨 값들
    [Header("Levels")]
    public GameObject levels;

    [Header("Reward")]
    public GameObject reward;

    [Header("BGM")]

    /// 미니게임 전용 BGM
    [Tooltip("이 미니게임에서 사용할 BGM")]
    public AudioClip bgmClip;

    /// BGM 볼륨 (0.0 ~ 1.0)
    [Tooltip("BGM 볼륨 (0.0 ~ 1.0)")]
    [Range(0f, 1f)]
    public float bgmVolume = 0.7f;

    /// BGM 페이드 인 시간 (초)
    [Tooltip("BGM 페이드 인 시간 (초)")]
    public float fadeInTime = 1.0f;

    /// BGM 페이드 아웃 시간 (초)
    [Tooltip("BGM 페이드 아웃 시간 (초)")]
    public float fadeOutTime = 1.0f;
}