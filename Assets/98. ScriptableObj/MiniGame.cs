using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Game", order = 1)]
public class MiniGame : ScriptableObject
{
    /// <summary>
    /// 게임 이름
    /// </summary>
    [Header("메인 게임 인지")]
    public bool isMain;

    /// <summary>
    /// 게임의 고유 번호
    /// </summary>
    [Header("게임의 고유 번호")]
    public int GameIndex;

    /// <summary>
    /// 중력의 영향이 필요한지
    /// </summary>
    [Header("중력을 사용하는지")]
    public bool isGravityUse;

    /// <summary>
    /// 필요한 고칠 중력의 양
    /// </summary>
    [Header("중력의 값")]
    public Vector3 GravityScale;

    /// <summary>
    /// 각 레벨 값들
    /// </summary>
    [Header("Levels")]
    public GameObject levels;

    [Header("Reward")]
    public GameObject reward;
}
