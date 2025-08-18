using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameData : MonoBehaviour
{
    public MiniGame games;

    [SerializeField] int level;

    private void OnTriggerEnter(Collider other)
    {
        PuzzleManager.Instance.SetPuzzle(games,level);
    }
}
