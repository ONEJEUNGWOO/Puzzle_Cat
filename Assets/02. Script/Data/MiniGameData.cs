using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MiniGameData : MonoBehaviour
{
    public MiniGame games;

    public bool isMain;

    [SerializeField] int level;


    private void Awake()
    {
        PuzzleManager.Instance.miniGameData = this;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        PuzzleManager.Instance.PuzzleIn(games);

        PuzzleManager.Instance.SetPuzzle(games,level);
    }
}
