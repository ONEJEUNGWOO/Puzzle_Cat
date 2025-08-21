using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGameData : InteractableObject
{
    public MiniGame games;
    public Transform rewardSpawnPoint;

    [Header("BGM Settings")]
    public AudioClip miniGameBGM;
    public float bgmVolume = 0.7f;
    public float fadeInTime = 1.0f;
    public float fadeOutTime = 1.0f;

    private void Start()
    {
        InteractionText = "Press [F]";
    }

    public void CheckClear()
    {
        if (PuzzleDataManager.Instance.puzzleClearData.ContainsKey(games.GameID) &&
            PuzzleDataManager.Instance.puzzleClearData[games.GameID])
        {
            if (games.reward != null && rewardSpawnPoint != null)
            {
                Instantiate(games.reward, rewardSpawnPoint.position, rewardSpawnPoint.rotation);
            }
            Setactive();
        }
    }

    public void Setactive()
    {
        gameObject.SetActive(false);
    }

    public override void Interact()
    {
        base.Interact();

        // 미니게임 데이터를 PuzzleManager에 전달하기 전에 BGM 정보 설정
        if (miniGameBGM != null)
        {
            // MiniGame ScriptableObject에 BGM 정보 설정
            games.bgmClip = miniGameBGM;
            games.bgmVolume = bgmVolume;
            games.fadeInTime = fadeInTime;
            games.fadeOutTime = fadeOutTime;
        }

        PuzzleManager.Instance.PuzzleIn(games, rewardSpawnPoint);
        PuzzleDataManager.Instance.Clear += Setactive;
    }

    private void OnDestroy()
    {
        PuzzleDataManager.Instance.Clear -= Setactive;
    }
}