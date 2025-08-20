using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGameData : InteractableObject
{
    public MiniGame games;

    public Transform rewardSpawnPoint;

    private void Start()
    {
        InteractionText = "Press [F]";

        if (PuzzleDataManager.Instance.puzzleClearData.ContainsKey(games.GameID) &&
            PuzzleDataManager.Instance.puzzleClearData[games.GameID])
        {
            PuzzleManager.Instance.SpawnReward();
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
        PuzzleManager.Instance.PuzzleIn(games, rewardSpawnPoint);
        PuzzleDataManager.Instance.Clear += Setactive;
    }

    private void OnDestroy()
    {
        PuzzleDataManager.Instance.Clear -= Setactive;
    }
}
