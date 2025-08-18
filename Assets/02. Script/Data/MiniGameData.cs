using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGameData : MonoBehaviour
{
    public MiniGame games;

    public Transform rewardSpawnPoint;


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        PuzzleManager.Instance.PuzzleIn(games, rewardSpawnPoint);
    }

    private void OnTriggerExit(Collider other)
    {
        gameObject.SetActive(false);
    }
}
