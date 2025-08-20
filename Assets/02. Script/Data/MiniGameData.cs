using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGameData : InteractableObject
{
    public MiniGame games;

    public Transform rewardSpawnPoint;

    private void Awake()
    {
        InteractionText = "Press [F]";
    }

    public override void Interact()
    {
        base.Interact();
        PuzzleManager.Instance.PuzzleIn(games, rewardSpawnPoint);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (!other.CompareTag("Player")) return;
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    gameObject.SetActive(false);
    //}
}
