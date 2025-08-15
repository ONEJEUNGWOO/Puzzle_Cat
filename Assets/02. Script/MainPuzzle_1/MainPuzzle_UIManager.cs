using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPuzzle_UIManager : MonoBehaviour
{
    public static MainPuzzle_UIManager Instance;

    public GameObject gameClearUI;
    public GameObject ballSpawnUI;

    private void Awake()
    {
        if (Instance == null)
        Instance = this;
        else
        {
            Instance = this;
            Destroy(gameObject);
        }
    }
}
